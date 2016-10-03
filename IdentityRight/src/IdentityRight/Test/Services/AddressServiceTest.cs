using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using IdentityRight.Models;
using System.Diagnostics;

namespace IdentityRight.Test.Controller
{
    public class AddressServiceTest
    {
        private ApplicationDbContext _context;
        private Services.AddressProvider _AddressProvider;

        public AddressServiceTest()
        {
            _AddressProvider = new Services.AddressProvider();
            _context = new ApplicationDbContext();
            //Ensure all the data is deleted.
            // _context.Database.EnsureDeleted();
            //seed date
            Countries country = createCountry();
            _context.Country.Add(country);
            _context.SaveChanges();

            Locations loc = createLocation();
            _context.Location.Add(loc);
            _context.SaveChanges();

            UserAddresses userAddress = createUserAddress();
            _context.UserAddress.Add(userAddress);
            _context.SaveChanges();

            ApplicationUser user = createUser();
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //Test adding address to database
        [Fact]
        public void addValidAddressForUser()
        {
            var beforeAddingAddress = _context.UserAddress.Count();
            _AddressProvider.addUserAddress(new UserAddresses
            {
                AddressType = AddressType.Business,
                LocationsId = 2,
                ApplicationUserId = "testApplicationUserID",
            });
            Assert.Equal(beforeAddingAddress + 1, _context.UserAddress.Count());
        }

        //Test adding location to database.
        [Fact]
        public void addValidLocation()
        {

            var beforeAddingLocation = _context.Location.Count();
            _AddressProvider.addLocation(new Locations
            {
                postcode = 3000,
                state = "VIC",
                streetName = "Test Street Name 2",
                streetNumber = "123",
                suburb = "Melbourne"
            });
            Assert.Equal(beforeAddingLocation + 1, _context.Location.Count());
        }

        //Test adding country to database.
        [Fact]
        public void addValidCountry()
        {
            var beforeAddingCountry = _context.Country.Count();

            _AddressProvider.addCountry(new Countries
            {
                countryName = "Australia",
                RegionsId = 1
            });
            Assert.Equal(beforeAddingCountry + 1, _context.Country.Count());
        }

        /// <summary>
        /// Check if a country exists in the db.
        /// </summary>
        [Fact]
        public void checkIfCountryExistsTrue()
        {
            Countries country = new Countries
            {
                countryName = "TestCountry",
                RegionsId = 1
            };

            bool exist = _AddressProvider.checkIfCountryExists(country);
            Assert.Equal(1, _context.Country.Count());
            Assert.True(exist);
        }

        /// <summary>
        /// Check if a location exists in the db
        /// </summary>
        [Fact]
        public void checkIfLocationExistsTrue()
        {
            Locations loc = createLocation();
            bool exist = _AddressProvider.checkIfLocationExists(loc);
            Assert.True(exist);
        }

        /// <summary>
        /// Check if a user address exists in the db
        /// </summary>
        [Fact]
        public void checkifUserAddressExistsTrue()
        {
            UserAddresses ua = createUserAddress();
            bool exist = _AddressProvider.checkUserAddress(ua);
            Assert.True(exist);
        }

        /// <summary>
        /// Check if user address is deleted from db.
        /// </summary>
        [Fact]
        public void deleteUserAddressById()
        {
            int countBefore = _context.UserAddress.Count();
            _AddressProvider.deleteUserAddressById(100);
            Assert.Equal(countBefore - 1, _context.UserAddress.Count());
        }


        #region helper functions
        private UserAddresses createUserAddress()
        {
            UserAddresses address = new UserAddresses();
            address.AddressType = 0;
            address.LocationsId = 1;
            address.ApplicationUserId = "testApplicationUserID";
            address.Id = 100;
            return address;
        }

        private Locations createLocation()
        {
            Locations loc = new Locations();
            loc.postcode = 3000;
            loc.state = "VIC";
            loc.streetName = "Test Street Name";
            loc.streetNumber = "123";
            loc.suburb = "Melbourne";
            return loc;
        }

        private Countries createCountry()
        {
            Countries country = new Countries();
            country.countryName = "TestCountry";
            country.RegionsId = 1;
            return country;
        }

        private ApplicationUser createUser()
        {
            return new ApplicationUser
            {
                Id = "testUserID",
                AccessFailedCount = 0,
                EmailConfirmed = true,
                IRID = "ddddddd",
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                isAccountCompleted = true
            };
        }
        #endregion
    }
}
