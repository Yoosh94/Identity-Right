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

        #region Create Methods

        /// <summary>
        /// Create a 
        /// </summary>
        /// <param name="UserAddressID"></param>
        /// <param name="organisationsID"></param>
        /// <param name="user"></param>
        public void CreateUserAddress_UserOrganisationLink(int UserAddressID, List<int> organisationsID, string userId)
        {
            //If the list in empty initialise it.
            if(organisationsID == null)
            {
                organisationsID = new List<int>();
            }
            //List of old links.
            var allLinks = getAllAddressOrganisationLinks(UserAddressID);
            //For each UserAddress_UserOrganisation link that was previously there check if the current list contains the organisation ID,
            //If it doesn't, it means the user has removed the link with that organisation
            foreach (var c in allLinks)
            {
                var orgID = getUserOrganisationLink(c.UserOrganisationLinksId).ApplicationOrganisationsId;
                if (!organisationsID.Contains(orgID))
                {
                    _dbContext.UserAddress_UserOrganisationLink.Remove(c);
                }
                //If the new list contains a organisation ID that was in the old list, just remove it from the new list so we do not add
                //redundant objects into the db.
                organisationsID.Remove(organisationsID.SingleOrDefault(s => s == orgID));
                //If the current list does not contain a value from the old list, it means that the user has deleted it.
            }
            //Foreach id that is in the new List add the object to a list.
            List<UserAddresses_CustomerOrganisationLinks> ListOfLinks = new List<UserAddresses_CustomerOrganisationLinks>();
            foreach (var id in organisationsID)
            {
                ListOfLinks.Add(new UserAddresses_CustomerOrganisationLinks
                {
                    UserAddressesId = UserAddressID,
                    UserOrganisationLinksId = getUserOrganisationLink(userId, id).Id
                });
            }
            //save the data into the database.
            _dbContext.UserAddress_UserOrganisationLink.AddRange(ListOfLinks);
            _dbContext.SaveChanges();
        }
        #endregion

        #region Read Methods
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
            foreach (var link in links)
            {
                linkedOrganisations.Add(getOrganisation(link.ApplicationOrganisationsId));
            }
            return linkedOrganisations;
        }

        /// <summary>
        /// Get a list of UserAddress_UserOrganisationLink objects. 
        /// </summary>
        /// <param name="user"></param>
        public List<UserAddresses_CustomerOrganisationLinks> getAllAddressOrganisationLinks(int userAddressID)
        {
            return _dbContext.UserAddress_UserOrganisationLink.Where(x => x.UserAddressesId == userAddressID).ToList();
        }

        public List<ApplicationOrganisations> convertUserAddressLinkToApplicationOrganisation(List<UserAddresses_CustomerOrganisationLinks> links)
        {
            List<ApplicationOrganisations> orgList = new List<ApplicationOrganisations>();
            foreach (var userAddresslink in links)
            {
                var c = _dbContext.UserOrganisationLinks.First(x => x.Id == userAddresslink.UserOrganisationLinksId);
                var organisation = getOrganisation(c.ApplicationOrganisationsId);
                orgList.Add(organisation);
            }
            return orgList;
        }

        /// <summary>
        /// Get a UserOrganisationLink object
        /// </summary>
        /// <param name="userID">User Id for the link</param>
        /// <param name="orgId">Organisation the user is linked ot</param>
        /// <returns>UserOrganisastionLink object</returns>
        public UserOrganisationLinks getUserOrganisationLink(string userID, int orgId)
        {
            return _dbContext.UserOrganisationLinks.Where(x => x.ApplicationUserId == userID)
                .Where(x => x.ApplicationOrganisationsId == orgId).Single();
        }

        public UserOrganisationLinks getUserOrganisationLink(int UserOrganisationLinkID)
        {
            return _dbContext.UserOrganisationLinks.Where(x => x.Id == UserOrganisationLinkID).Single();
        }
        /// <summary>
        /// Get all the organisations that are not linked to the current user but have been added to the user.
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>A list of organisations that are not linked to an User</returns>
        //public List<ApplicationOrganisations> getAllUnlinkedOrganisations(ApplicationUser user, List<ApplicationOrganisations> linkedOrgs)
        //{
        //    //Get a list of all not linked organisation with a particular User ID
        //    var TotalListofOrgsLinked = _dbContext.UserOrganisationLinks.Where(x => x.ApplicationUserId == user.Id);
        //    //If the Total list of organisation linked for the user in UserORganiastionLink equals the number of linkedOrganisations
        //    if(TotalListofOrgsLinked.ToList().Count == linkedOrgs.Count)
        //    {

        //    }
        //    //var notLink = _dbContext.ApplicationOrganisations.ToList().Except(linkedOrgs);
        //    //return notLink.ToList();
        //}

        /// <summary>
        /// Get an Organisation object by its ID
        /// </summary>
        /// <param name="id">ID of the organisation that you want to get</param>
        /// <returns>Organisation object</returns>
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

        #region Update Methods

        #endregion

        #region Delete Methods
        #endregion






        #endregion
    }
}
