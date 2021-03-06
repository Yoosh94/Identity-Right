﻿using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using IdentityRight.Services;
using IdentityRight.ViewModels.Identity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace IdentityRight.ViewComponents
{
    public class DisplayRegisteredAddressViewComponent : ViewComponent
    {
        private readonly AddressProvider _addressProvider;
        readonly UserManager<ApplicationUser> userManager;
        public DisplayRegisteredAddressViewComponent(UserManager<ApplicationUser> UserManager)
        {
            _addressProvider = new AddressProvider();
            userManager = UserManager;
        }

        /// <summary>
        /// This method id run from Razor html files. It will get the addresses for the user and put them into a model.
        /// </summary>
        /// <param name="claimUser">User object from Razor file</param>
        /// <returns>A partial view to the page.</returns>
        public async Task<IViewComponentResult> InvokeAsync(ClaimsPrincipal claimUser)
        {
            var id = claimUser.GetUserId();
            var user = await userManager.FindByIdAsync(id);
            DisplayAddressViewModel displayAddressViewModel = new DisplayAddressViewModel();
            var userAddress = _addressProvider.getAllAddresses(user);
            var userLocation = _addressProvider.getAllLocations(user);
            foreach (UserAddresses address in userAddress)
            {
                displayAddressViewModel.userAddress.Add(address);
            }
            foreach (Locations location in userLocation)
            {
                displayAddressViewModel.location.Add(location);
            }
            return View(displayAddressViewModel);
            
        }
    }
}
