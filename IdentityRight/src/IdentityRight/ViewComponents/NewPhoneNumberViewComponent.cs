using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.ViewComponents
{
    public class NewPhoneNumberViewComponent : ViewComponent
    {

        public IViewComponentResult InvokeAsync(string s)
        {
            return View(s);
        }

    }
}
