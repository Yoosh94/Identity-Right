using IdentityRight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Services
{
    public class EmailProvider: ApplicationDbContext
    {
        private readonly ApplicationDbContext _dbContext;
        //Create instance of database
        public EmailProvider()
        {
            _dbContext = new ApplicationDbContext();
        }

        #region Create Email Operations

        /// <summary>
        /// Add email to the database
        /// </summary>
        /// <param name="email">UserEmailAddress object</param>
        public void createEmailForUser(UserEmailAddresses email)
        {
            _dbContext.UserEmailAddress.Add(email);
            _dbContext.SaveChanges();
        }
        #endregion

        #region Read Email Operations
        /// <summary>
        /// Get all the emails associated with a user
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>List of UserEmailAddresses</returns>
        public List<UserEmailAddresses> getAllEmailsForUser(ApplicationUser user)
        {
            var emails = _dbContext.UserEmailAddress.Where(x => x.ApplicationUser.Id == user.Id).ToList();
            return emails;
        }
        #endregion

        #region Update Email Operation
        #endregion

        #region Delete Email operation
        #endregion
    }
}
