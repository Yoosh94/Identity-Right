using IdentityRight.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace IdentityRight.Controllers
{
    public class OrganisationsController : Controller
    {
        private readonly OrganisationProvider _orgRepo;

        public OrganisationsController()
        {
            _orgRepo = new OrganisationProvider();
        }

        [Authorize]
        [HttpGet]
        [Route("/Organisations")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Organisations";
            var organisations = _orgRepo.GetAllOrganisations();
            return View("OrganisationsPartial", organisations);
        }

        [Authorize]
        [HttpGet]
        [Route("/Organisation/{organisationId}")]
        public IActionResult Organisation(int organisationId)
        {
            var organisation = _orgRepo.GetOrganisationDetails(organisationId);
            if (organisation == null) return HttpBadRequest("Bad Request");
            ViewData["Title"] = organisation.OrganisationName;
            return View("OrganisationPartial", organisation);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUserDetail(string userId)
        {
            var userDetail = _orgRepo.GetUserDetails(userId);
            return PartialView("UserDetail", userDetail);
        }
    }
}