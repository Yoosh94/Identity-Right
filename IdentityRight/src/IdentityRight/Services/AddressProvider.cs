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
            //Check if Country Exist
            //return from c in _dbContext.Country
            //                    where c.countryName.Contains(CountryName)
            //                    select c).ToList();
            //return _dbContext.Country.Where(x => x.countryName == CountryName).ToList();
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
            //var location = from loc in _dbContext.Location
            //               where loc.CountriesId == country.First().Id
            //               where loc.postcode == postcode
            //               where loc.state == model.administrative_area_level_1
            //               where loc.streetName == model.route
            //               where loc.streetNumber == model.street_number
            //               where loc.suburb == model.locality
            //               where (loc.unitNumber == model.subpremise || loc.unitNumber == null)
            //               select loc;
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
    }
}
