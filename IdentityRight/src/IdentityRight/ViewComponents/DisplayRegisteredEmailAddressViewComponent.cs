using IdentityRight.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityRight.ViewModels.Identity;
using IdentityRight.Services;

namespace IdentityRight.ViewComponents
{
    public class DisplayRegisteredEmailAddressViewComponent : ViewComponent
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly EmailProvider _emailProvider;
        public DisplayRegisteredEmailAddressViewComponent(UserManager<ApplicationUser> UserManager)
        {
            userManager = UserManager;
            _emailProvider = new EmailProvider();
        }

        public async Task<IViewComponentResult> InvokeAsync(ClaimsPrincipal claimUser)
        {
            var id = claimUser.GetUserId();
            var user = await userManager.FindByIdAsync(id);
            DisplayEmailAddressViewModel emailAddressVM = new DisplayEmailAddressViewModel();
            emailAddressVM.emailAddresses = _emailProvider.getAllEmailsForUser(user);
            return View(emailAddressVM);
        }
    }
}
