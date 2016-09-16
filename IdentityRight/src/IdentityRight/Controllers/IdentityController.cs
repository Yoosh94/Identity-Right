using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using IdentityRight.Models;
using IdentityRight.Services;
using IdentityRight.ViewModels.Identity;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using IdentityRight.ViewModels;
using IdentityRight.ViewModels.EditDetails;

namespace IdentityRight.Controllers
{
    [Authorize]
    public class IdentityController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly AddressProvider _addressProvider;

        public IdentityController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IEmailSender emailSender,
        ISmsSender smsSender,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<IdentityController>();
            _dbContext = new ApplicationDbContext();
            _addressProvider = new AddressProvider();
        }

        //
        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var user = await GetCurrentUserAsync();
            var model = new IndexViewModel
            {
                HasPassword = await _userManager.HasPasswordAsync(user),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(user),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(user),
                Logins = await _userManager.GetLoginsAsync(user),
                BrowserRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel account)
        {
            ManageMessageId? message = ManageMessageId.Error;
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.RemoveLoginAsync(user, account.LoginProvider, account.ProviderKey);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    message = ManageMessageId.RemoveLoginSuccess;
                }
            }
            return RedirectToAction(nameof(ManageLogins), new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public IActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var user = await GetCurrentUserAsync();
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, model.PhoneNumber);
            await _smsSender.SendSmsAsync(model.PhoneNumber, "Your security code is: " + code);
            return RedirectToAction(nameof(VerifyPhoneNumber), new { PhoneNumber = model.PhoneNumber });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableTwoFactorAuthentication()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, true);
                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation(1, "User enabled two-factor authentication.");
            }
            return RedirectToAction(nameof(Index), "Identity");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableTwoFactorAuthentication()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, false);
                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation(2, "User disabled two-factor authentication.");
            }
            return RedirectToAction(nameof(Index), "Identity");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        [HttpGet]
        public async Task<IActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(await GetCurrentUserAsync(), phoneNumber);
            // Send an SMS to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePhoneNumberAsync(user, model.PhoneNumber, model.Code);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.AddPhoneSuccess });
                }
            }
            // If we got this far, something failed, redisplay the form
            ModelState.AddModelError(string.Empty, "Failed to verify phone number");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePhoneNumber()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.SetPhoneNumberAsync(user, null);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.RemovePhoneSuccess });
                }
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        //
        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User changed their password successfully.");
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        //
        // GET: /Manage/SetPassword
        [HttpGet]
        public IActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        //GET: /Manage/ManageLogins
        [HttpGet]
        public async Task<IActionResult> ManageLogins(ManageMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.AddLoginSuccess ? "The external login was added."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await _userManager.GetLoginsAsync(user);
            var otherLogins = _signInManager.GetExternalAuthenticationSchemes().Where(auth => userLogins.All(ul => auth.AuthenticationScheme != ul.LoginProvider)).ToList();
            ViewData["ShowRemoveButton"] = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            var redirectUrl = Url.Action("LinkLoginCallback", "Identity");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, User.GetUserId());
            return new ChallengeResult(provider, properties);
        }

        //
        // GET: /Manage/LinkLoginCallback
        [HttpGet]
        public async Task<ActionResult> LinkLoginCallback()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var info = await _signInManager.GetExternalLoginInfoAsync(User.GetUserId());
            if (info == null)
            {
                return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.Error });
            }
            var result = await _userManager.AddLoginAsync(user, info);
            var message = result.Succeeded ? ManageMessageId.AddLoginSuccess : ManageMessageId.Error;
            return RedirectToAction(nameof(ManageLogins), new { Message = message });
        }

        //This method will open the search org page
        // GET: /Identity/searchorganisation
        [HttpGet]
        public IActionResult SearchOrg()
        {
            return View("SearchOrganisation");
        }

        //This method will open the search org page
        // GET: /Identity/SubscribedOrganisation
        [HttpGet]
        public IActionResult SubscribedOrg()
        {
            return View("SubscribedOrganisation");
        }

        //This method will open the page that allows users to manage their 
        // GET: /Identity/UpdatePostalAddress
        [HttpGet]
        public IActionResult ManageAddresses()
        {
            return View("ManageAddressView");
        }

        //This method will open the search org page
        // GET: /Identity/UpdatePhone
        [HttpGet]
        public IActionResult UpdatePhoneNo()
        {
            return View("UpdatePhoneToOrganisation");
        }

        //This method will open the search org page
        // GET: /Identity/UpdatePhone
        [HttpGet]
        public IActionResult UpdateHomePhoneNo()
        {
            return View("UpateHomePhoneToOrganisation");
        }

        //This method will open the search org page
        // GET: /Identity/UpateEmailToOrganisation
        [HttpGet]
        public IActionResult UpateEmailToOrg()
        {
            return View("UpateEmailToOrganisation");
        }

        [HttpGet]
        public IActionResult searchorganisations(string userSearch)
        {
            var result = from c in _dbContext.ApplicationOrganisations
                         where c.organisationName == userSearch
                         select c;
            ViewData["organisation"] = result.ToString();
            return View("SearchOrganisation");
        }

        // GET: /Identity/AddAddress
        [HttpGet]
        public IActionResult AddAddress(ManageMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                  message == ManageMessageId.AddAddressSuccess ? "Your address has been successfully added."
                : message == ManageMessageId.AddAddressFail ? "Address already exists."
                : "";
            return View("ManageAddressView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(AddAddressViewModel model)
        {
            //Get the current user
            var user = await GetCurrentUserAsync();
            //Create a country object from the form the user has submitted. Region id will be set to 1 for now.
            Countries country = new Countries { countryName = model.country, RegionsId = 1 };
            //Check if the country exists
            var countryExist = _addressProvider.checkIfCountryExists(country);
            //If there is no country add it to the db
            if (!countryExist)
            {
                //Add the country to the db
                _addressProvider.addCountry(country);
            }
            //Parse the postcode as an int
            int postcode;
            bool result = int.TryParse(model.postal_code, out postcode);
            //Create a location object
            Locations location = new Locations
            {
                CountriesId = _addressProvider.getCountryId(country),
                postcode = postcode,
                state = model.administrative_area_level_1,
                streetName = model.route,
                streetNumber = model.street_number,
                suburb = model.locality,
                unitNumber = model.subpremise
            };
            //Check if location exists 
            var locationExist = _addressProvider.checkIfLocationExists(location);
            //If location does not exist create it in the db
            if (!locationExist)
            {
                _addressProvider.addLocation(location);
            }
            //Create userAddress object
            UserAddresses userAddress = new UserAddresses
            {
                LocationsId = _addressProvider.getLocationId(location),
                AddressType = model.addressType,
                ApplicationUserId = user.Id
            };
            //Check if the user address already exists first
            bool uaExists = _addressProvider.checkUserAddress(userAddress);
            if (!uaExists)
            {
                //Create a user address
                _addressProvider.addUserAddress(userAddress);
                return RedirectToAction("AddAddress", new { Message = ManageMessageId.AddAddressSuccess });
            }
            else
            {
                return RedirectToAction("AddAddress", new { Message = ManageMessageId.AddAddressFail });
            }

        }

        // GET: /Identity/showAddress
        [HttpGet]
        public async Task<IActionResult> showAddress()
        {
            var user = await GetCurrentUserAsync();
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
            return View("DisplayAddressView", displayAddressViewModel);
        }

        [HttpGet("editAddress/{id}")]
        public async Task<IActionResult> updateAddress(Locations loc)
        {
            var user = await GetCurrentUserAsync();
            UserAddresses userAddress = _addressProvider.getAddressByLocation(user, loc.Id);
            ViewBag.EditType = "address";
            return View("UpdateDetails", new UpdateAddressViewModel { location = loc, userAddress = userAddress });
        }

        //Settings:
        //This method will open the search org page
        // GET: /Identity/UpateEmailToOrganisation
        [HttpGet]
        public IActionResult SecondaryEmail()
        {
            return View("AddSecondaryEmail");
        }

        //Joint Account:
        //This method will open the search org page
        // GET: /Identity/UpateEmailToOrganisation
        [HttpGet]
        public IActionResult JointAcc()
        {
            return View("AddJointAccount");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error,
            AddAddressSuccess,
            AddAddressFail
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }

        // GET: /Identity/Organisations
        [HttpGet]
        public IActionResult Organisations()
        {
            ApplicationDbContext adc = new ApplicationDbContext();

            var uID = User.GetUserId();


            IQueryable<ApplicationOrganisations> AO = from q in adc.UserOrganisationLinks
                                                      where q.ApplicationUserId == uID
                                                      select q.ApplicationOrganisation;

            List<ApplicationOrganisations> rowList = AO.ToList();

            return View(rowList);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetLinks(OrganisationsViewModel ovm)
        {

            ApplicationDbContext adc = new ApplicationDbContext();


            //Get the ID of the current user
            var user = await GetCurrentUserAsync();
            var uID = user.Id;

            //Get a list of all linked orgs for that user ID
            IQueryable<ApplicationOrganisations> AOL = from q in adc.UserOrganisationLinks
                                                       where q.ApplicationUserId == uID
                                                       select q.ApplicationOrganisation;

            List<ApplicationOrganisations> linked = AOL.ToList(); //Convert to list


            IQueryable<UserOrganisationLinks> UOL = from q in adc.UserOrganisationLinks
                                                    where q.ApplicationUserId == uID
                                                    select q;

            List<UserOrganisationLinks> UOLlinked = UOL.ToList(); //Convert to list


            //Check if the user actually passed any new orgs links through. Either the user deleted all their links or had none when they saved
            if (ovm.ReturnedIDs != null && ovm.ReturnedIDs.Count != 0)
            {


                //Fill a list with all the IDs of the currently linked orgs
                List<long> linkedIDs = new List<long>(linked.Count);

                foreach (ApplicationOrganisations ao in linked)
                {
                    linkedIDs.Add(ao.Id);
                }


                /*IEnumerable<long> removedFromDB = from q in ovm.ReturnedIDs
                                                  where linkedIDs.Contains(q)
                                                  select q;
                                                  */

                IEnumerable<long> removedFromDB = from q in linkedIDs
                                                  where !ovm.ReturnedIDs.Contains(q)
                                                  select q;

                List<long> removedFromDBList = removedFromDB.ToList();


                IEnumerable<UserOrganisationLinks> orgsToRemove = from org in adc.UserOrganisationLinks
                                                                  where removedFromDBList.Contains(org.ApplicationOrganisationsId)
                                                                  select org;

                List<UserOrganisationLinks> orgsToRemoveList = orgsToRemove.ToList();

                foreach (UserOrganisationLinks orgLink in orgsToRemoveList)
                {
                    adc.UserOrganisationLinks.Remove(orgLink);
                }

                //Create a collection of IDs from the newly added Orgs, by excluding those that were already there
                IEnumerable<long> removedDoubles = from q in ovm.ReturnedIDs
                                                   where !linkedIDs.Contains(q)
                                                   select q;


                //For each of this new IDs create a new link to the currently logged in User.
                foreach (long id in removedDoubles)
                {
                    UserOrganisationLinks uol = new UserOrganisationLinks();

                    uol.ApplicationUserId = uID;
                    uol.ApplicationOrganisationsId = (int)id;


                    adc.UserOrganisationLinks.Add(uol);
                }

                //Commit the DB
                adc.SaveChanges();
            }
            else //Else no IDs were passed over. So either the DB was already empty or the user has deleted all their org links
            {
                //Check if the user has any orgLinks
                if (linked.Count != 0)
                {
                    //Since they had links previously they must have removed all their links 
                    //for the returnedID count to be zero or the list to be Null
                    //so remove them all from the DB 
                    foreach (UserOrganisationLinks uol in UOL)
                    {
                        adc.UserOrganisationLinks.Remove(uol);
                    }

                    //Commit the DB
                    adc.SaveChanges();
                }

                //Otherwise they never had any links and they pressed 'save' so do nothing.
            }

            return RedirectToAction("LinkOrganisations");
        }

        // GET: /Identity/Organisations
        [HttpGet]
        public async Task<IActionResult> LinkOrganisations()
        {
            ApplicationDbContext adc = new ApplicationDbContext();

            //Get the ID of the current user   
            var user = await GetCurrentUserAsync();
            var uID = user.Id;
            //Get a list of all linked orgs for that user ID
            IQueryable<ApplicationOrganisations> AOL = from q in adc.UserOrganisationLinks
                                                       where q.ApplicationUserId == uID
                                                       select q.ApplicationOrganisation;

            List<ApplicationOrganisations> linked = AOL.ToList(); //Convert to list

            //Fill a list with all the IDs of the currently linked orgs
            List<long> linkedIDs = new List<long>(linked.Count);

            foreach (ApplicationOrganisations ao in linked)
            {
                linkedIDs.Add(ao.Id);
            }


            //Get a list of currently available orgs for linking - by excluding those with IDs listed in linkedIds
            IQueryable<ApplicationOrganisations> AOUL = from q in adc.ApplicationOrganisations
                                                        where !linkedIDs.Contains(q.Id)
                                                        select q;

            List<ApplicationOrganisations> unlinked = AOUL.ToList();


            //Create a new view model and assign the linked and unlinked orgs
            OrganisationsViewModel OVM = new OrganisationsViewModel();

            //OVM.LinkedOrgs = linked;
            List<SelectListItem> SLI = new List<SelectListItem>();
            foreach (ApplicationOrganisations ao in linked)
            {
                SLI.Add(new SelectListItem { Text = ao.organisationName, Value = ao.Id.ToString() });
            }


            OVM.LinkedOrgs = SLI;
            OVM.UnlinkedOrgs = unlinked;

            //Pass the linked/unlinked orgs to the view
            return View(OVM);
        }

        #endregion
    }
}
