using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IdentityRight.Models;
using IdentityRight.ViewModels.Organisations;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Configuration;

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
    }
}
