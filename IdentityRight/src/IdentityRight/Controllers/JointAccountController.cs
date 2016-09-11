using System.Linq;
using Microsoft.AspNet.Mvc;

namespace IdentityRight.Controllers
{
    public class JointAccountController : Controller
    {
        //Joint Account:
        //This method will open the search org page
        // GET: /Identity/UpateEmailToOrganisation
        [HttpGet]
        public IActionResult JointAcc()
        {
            return View("AddJointAccount");
        }
    }
}