using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IdentityRight.Models;
using IdentityRight.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityRight.Controllers
{

    [Route("api/[controller]")]
    public class ManageuserController : Controller
    {
        private ManageuserRepository _ManageuserRepository;

        public ManageuserController()
        {
            this._ManageuserRepository = new ManageuserRepository();
        }
        /// <summary>
        /// This method will get a customer address and return it
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns>Customers address</returns>
        // GET: api/link/key/{someKey}
        //[HttpGet]
        //[Route("key/{apiKey}/{userID}")]
        //public UserAddresses GetCustomerAddress(string apiKey, string userID)
        //{
        //    if (_ManageuserRepository.DoesLinkExist(apiKey, userID))
        //    {
        //        _ManageuserRepository.getAddress();
        //    }

        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
