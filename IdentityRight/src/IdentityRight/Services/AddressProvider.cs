using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using IdentityRight.ViewModels.Organisations;
using IdentityRight.ViewModels.UpdateDetails;

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
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Add a location to the database
        /// </summary>
        /// <param name="location">An object which contains location details</param>
        public void addLocation(Locations location)
        {
            _dbContext.Location.Add(location);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Add a User Address to the database
        /// </summary>
        /// <param name="ua">An object which contains user address details</param>
        public void addUserAddress(UserAddresses ua)
        {
            _dbContext.UserAddress.Add(ua);
            _dbContext.SaveChanges();
        }
        #endregion
        #region Read Operations

        #region Read Operations for Country
        /// <summary>
        /// Check if a country exists in the databse
        /// </summary>
        /// <param name="country">The Country object to check for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkIfCountryExists(Countries country)
        {
            int count = _dbContext.Country.Where(x => x.countryName == country.countryName).Count();
            if (count == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get a country object
        /// </summary>
        /// <param name="id">id of the country needed</param>
        /// <returns>A country Object</returns>
        public Countries getCountryById(int id)
        {
            return _dbContext.Country.Where(x => x.Id == id).First();
        }

        /// <summary>
        /// Get the Id of a Country using the object
        /// </summary>
        /// <param name="country">Country object</param>
        /// <returns>ID of the specified country</returns>
        public int getCountryId(Countries country)
        {
            return _dbContext.Country.Where(x => x.countryName == country.countryName).Where(x => x.RegionsId == country.RegionsId).Select(x => x.Id).First();
        }

        #endregion
        #region Read Operation for Location
        /// <summary>
        /// Check if a Location exists in the database
        /// </summary>
        /// <param name="loc">The Location object to looks for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkIfLocationExists(Locations loc)
        {
            //return _dbContext.Location.Contains(loc);
            int count = _dbContext.Location.Where(x => x.CountriesId == loc.CountriesId)
                .Where(x => x.postcode == loc.postcode)
                .Where(x => x.state == loc.state)
                .Where(x => x.streetName == loc.streetName)
                .Where(x => x.streetNumber == loc.streetNumber)
                .Where(x => x.suburb == loc.suburb)
                .Where(x => x.unitNumber == loc.unitNumber)
                .Count();
            if (count == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get the Id of a specified location
        /// </summary>
        /// <param name="loc">Location object</param>
        /// <returns>Id of the specified location</returns>
        public int getLocationId(Locations loc)
        {
            return _dbContext.Location.Where(x => x.CountriesId == loc.CountriesId)
                .Where(x => x.postcode == loc.postcode)
                .Where(x => x.state == loc.state)
                .Where(x => x.streetName == loc.streetName)
                .Where(x => x.streetNumber == loc.streetNumber)
                .Where(x => x.suburb == loc.suburb)
                .Where(x => x.unitNumber == loc.unitNumber)
                .Select(x => x.Id).First();
        }

        /// <summary>
        /// Get all the Locations for a particular user
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>A list of Locations for the specified user</returns>
        public List<Locations> getAllLocations(ApplicationUser user)
        {
            List<Locations> loc = new List<Locations>();
            var listOfAddress = getAllAddresses(user);
            foreach (UserAddresses address in listOfAddress)
            {
                loc.Add(_dbContext.Location.Where(x => x.Id == address.LocationsId).First());
            }
            return loc;
        }
        #endregion
        #region Read Operation for UserAddress
        /// <summary>
        /// Check if the User address exists in the database
        /// </summary>
        /// <param name="userAddress">The user address object to look for</param>
        /// <returns>True if the object exists or false if the object does not exist</returns>
        public bool checkUserAddress(UserAddresses userAddress)
        {
            int count = _dbContext.UserAddress.Where(x => x.AddressType == userAddress.AddressType)
                .Where(x => x.ApplicationUserId == userAddress.ApplicationUserId)
                .Where(x => x.LocationsId == userAddress.LocationsId)
                .Count();
            if (count == 1)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Get all the User address objects for a user
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>List of User addresses</returns>
        public List<UserAddresses> getAllAddresses(ApplicationUser user)
        {
            return _dbContext.UserAddress.Where(x => x.ApplicationUserId == user.Id).ToList();
        }


        /// <summary>
        /// Get the user address object of a user by the location id
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="id">Id of the location that wants to be found</param>
        /// <returns>User Address object</returns>
        public UserAddresses getAddressByLocation(ApplicationUser user, int id)
        {
            //Find userAddress with the ID of the location passed in by the parameter
            var singleUserAddress = _dbContext.UserAddress.Where(x => x.ApplicationUserId == user.Id)
                .Where(z => z.LocationsId == id)
                .First();
            return singleUserAddress;
        }

        #endregion
        #endregion
        #region Update Operations
        public void updateUserAddress(int UserAddressIDtoUpdate, int newLocationID, AddressType addressType)
        {
            var address = _dbContext.UserAddress.Where(x => x.Id == UserAddressIDtoUpdate).First();
            address.LocationsId = newLocationID;
            address.AddressType = addressType;
            _dbContext.SaveChanges();
        }

        #endregion
        #region Delete Operations
        /// <summary>
        /// Delete a UserAddress by the Id
        /// </summary>
        /// <param name="id"></param>
        public void deleteUserAddressById(int id)
        {
            //Get all the userAddresses linked to that account.
            var addressesFound = _dbContext.UserAddress.Where(x => x.Id == id).ToList();
            //if there is only one address delete it.
            if (addressesFound.Count == 1)
            {
                _dbContext.UserAddress.Remove(addressesFound.First());
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}
