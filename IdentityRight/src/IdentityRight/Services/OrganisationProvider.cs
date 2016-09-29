using System.Collections.Generic;
using System.Linq;
using IdentityRight.Models;
using IdentityRight.ViewModels.Organisations;

namespace IdentityRight.Services
{
    public class OrganisationProvider : ApplicationDbContext
    {
        private readonly ApplicationDbContext _dbContext;

        // Create instance of the organisation provider
        public OrganisationProvider()
        {
            _dbContext = new ApplicationDbContext();
        }

        #region Organisation Context
        /// <summary>
        /// Gets all of the users that are currently linked with an organisation
        /// </summary>
        /// <param name="organisationId"></param>
        /// <returns>A list of users</returns>
        public List<ApplicationUser> GetAllUsersInOrganisation(int organisationId)
        {
            return _dbContext.UserOrganisationLinks.Where(a => a.ApplicationOrganisationsId == organisationId).Select(l => l.ApplicationUser).ToList();
        }

        /// <summary>
        /// Gets the details of a particular organisation, including the list of linked users
        /// </summary>
        /// <param name="organisationId"></param>
        /// <returns>The organisationdetailsviewmodel containing Organisation Name, Address and List of linked users</returns>
        public OrganisationDetailsViewModel GetOrganisationDetails(int organisationId)
        {
            var org = _dbContext.ApplicationOrganisations.FirstOrDefault(z => z.Id == organisationId);
            if (org == null) return null;
            var model = new OrganisationDetailsViewModel
            {
                OrganisationName = org.organisationName,
                OrganisationAddress = org.organisationAddress,
                LinkedUsers = GetAllUsersInOrganisation(organisationId)
            };
            return model;
        }

        /// <summary>
        /// Gets a list of all the organisations
        /// </summary>
        /// <returns>The organisationviewmodel containing a list of organisations</returns>
        public OrganisationsViewModel GetAllOrganisations()
        {
            return new OrganisationsViewModel
            {
                Organisations = _dbContext.ApplicationOrganisations.ToList()
            };
        }

        /// <summary>
        /// Gets user details for a particular user, including address, phone numbers and emails
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The userdetailmodel with user details</returns>
        public UserDetailsViewModel GetUserDetails(string userId)
        {
            var user = _dbContext.Users.First(z => z.Id == userId);
            var addressIds = _dbContext.UserAddress.Where(z => z.ApplicationUserId == userId).ToList();

            var addresses = addressIds.Select(address => _dbContext.Location.First(z => z.Id == address.LocationsId)).ToList();

            return new UserDetailsViewModel
            {
                User = user,
                UserAddresses = addresses,
                AddressIds = addressIds,
                UserEmails = _dbContext.UserEmailAddress.Where(z => z.ApplicationUserId == userId).ToList(),
                UserPhoneNumbers = _dbContext.UsersPhoneNumbers.Where(z => z.ApplicationUserId == userId).ToList()
            };
        }
        #endregion

        #region User Context
        /// <summary>
        /// Get all the Organisations that are linked to the current user.
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>A list of Organisastions that are linked to the user.</returns>
        public List<ApplicationOrganisations> getAllLinkedOrganisations(ApplicationUser user)
        {
            //Get a list of all links with a particular User ID
            var links = _dbContext.UserOrganisationLinks.Where(x => x.ApplicationUserId == user.Id).ToList();
            //Get the name of the Organisation by the ID
            List<ApplicationOrganisations> linkedOrganisations = new List<Models.ApplicationOrganisations>();
            foreach(var link in links)
            {
                linkedOrganisations.Add(getOrganisation(link.ApplicationOrganisationsId));
            }
            return linkedOrganisations;
        }

        /// <summary>
        /// Get all the organisations that are not linked to the current user
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>A list of organisations that are not linked to an User</returns>
        public List<ApplicationOrganisations> getAllUnlinkedOrganisations(ApplicationUser user, List<ApplicationOrganisations> linkedOrgs)
        {
            //Get a list of all not linked organisation with a particular User ID
            var notLink = _dbContext.ApplicationOrganisations.ToList().Except(linkedOrgs).ToList();
            return notLink;
        }

        public ApplicationOrganisations getOrganisation(int id)
        {
            var organisation = _dbContext.ApplicationOrganisations.FirstOrDefault(x => x.Id == id);
            if (organisation == null) return null;
            var model = new ApplicationOrganisations
            {
                Id = id,
                organisationName = organisation.organisationName
            };
            return model;
        }
        #endregion
    }
}
