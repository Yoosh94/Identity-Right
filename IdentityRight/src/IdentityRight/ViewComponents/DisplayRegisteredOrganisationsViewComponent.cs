using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityRight.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace IdentityRight.ViewComponents
{
    public class DisplayRegisteredOrganisationsViewComponent :ViewComponent
    {
        readonly UserManager<ApplicationUser> userManager;
        public DisplayRegisteredOrganisationsViewComponent(UserManager<ApplicationUser> UserManager)
        {
            userManager = UserManager;
        }

        public IViewComponentResult Invoke (ClaimsPrincipal claimUser)
        {
            var uID = claimUser.GetUserId();
            ApplicationDbContext adc = new ApplicationDbContext();
            IQueryable<ApplicationOrganisations> AO = from q in adc.UserOrganisationLinks
                                                      where q.ApplicationUserId == uID
                                                      select q.ApplicationOrganisation;
            List<ApplicationOrganisations> rowList = AO.ToList();
            return View(rowList);
        }
    }
}
