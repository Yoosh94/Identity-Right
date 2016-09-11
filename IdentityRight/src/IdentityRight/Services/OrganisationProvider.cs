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

        public OrganisationProvider()
        {
            _dbContext = new ApplicationDbContext();
        }

        public List<ApplicationUser> GetAllUsersInOrganisation(int organisationId)
        {
            return _dbContext.UserOrganisationLinks.Where(a => a.ApplicationOrganisationsId == organisationId).Select(l => l.ApplicationUser).ToList();
        }

        public List<ApplicationOrganisations> GetOrganisationsForUser(ApplicationUser user)
        {
            return _dbContext.UserOrganisationLinks.Where(z => z.ApplicationUser.Id == user.Id).Select(z => z.ApplicationOrganisation).ToList();
        }

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

        public OrganisationsViewModel GetAllOrganisations()
        {
            return new OrganisationsViewModel
            {
                Organisations = _dbContext.ApplicationOrganisations.ToList()
            };
        }
    }
}
