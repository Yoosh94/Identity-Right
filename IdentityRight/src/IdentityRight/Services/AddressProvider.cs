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

        #region Create Operations
        /// <summary>
        /// Add a country to the database
        /// </summary>
        /// <param name="country">An object which contains a country details</param>
        public void addCountry(Countries country)
        {
            _dbContext.Add(country);
            _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Add a location to the database
        /// </summary>
        /// <param name="location">An object which contains location details</param>
        public void addLocation(Locations location)
        {
            _dbContext.Location.Add(location);
            _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Add a User Address to the database
        /// </summary>
        /// <param name="ua">An object which contains user address details</param>
        public void addUserAddress(UserAddresses ua)
        {
            _dbContext.UserAddress.Add(ua);
            _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Read Operations
        /// <summary>
        /// Check if a country exists in the databse
        /// </summary>
        /// <param name="country">The Country object to check for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkIfCountryExists(Countries country)
        {
            return _dbContext.Country.Contains(country);
        }

        /// <summary>
        /// Check if a Location exists in the database
        /// </summary>
        /// <param name="loc">The Location object to looks for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkIfLocationExists(Locations loc)
        {
            return _dbContext.Location.Contains(loc);
        }

        /// <summary>
        /// Check if the User address exists in the database
        /// </summary>
        /// <param name="userAddress">The user address object to look for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkUserAddress(UserAddresses userAddress)
        {
            return _dbContext.UserAddress.Contains(userAddress);
        }
        #endregion

        #region Update Operations
        #endregion

        #region Delete Operations
        #endregion












    }
}
