using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using IdentityRight.ViewModels.Organisations;

namespace IdentityRight.Services
{
    public class AddressProvider : ApplicationDbContext
    {

        private readonly ApplicationDbContext _dbContext;
        //Create instance of database
        public AddressProvider()
        {
            _dbContext = new ApplicationDbContext();
        }

        public bool checkIfCountryExists(Countries country)
        {
            return _dbContext.Country.Contains(country);
        }

        /// <summary>
        /// Add a country to the database
        /// </summary>
        /// <param name="country">An object which contains a country details</param>
        public void addCountry(Countries country)
        {
            _dbContext.Add(country);
            _dbContext.SaveChangesAsync();
        }

        public bool checkIfLocationExists(Locations loc)
        {
            return _dbContext.Location.Contains(loc);
        }

        public void addLocation(Locations location)
        {
            _dbContext.Location.Add(location);
            _dbContext.SaveChangesAsync();
        }

        public void addUserAddress(UserAddresses ua)
        {
            _dbContext.UserAddress.Add(ua);
            _dbContext.SaveChangesAsync();
        }

        public bool checkUserAddress(UserAddresses userAddress)
        {
            return _dbContext.UserAddress.Contains(userAddress);
        }
    }
}
