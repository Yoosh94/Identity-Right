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
        /// <returns>Boolean if the add was successful or not</returns>
        public bool createEmailForUser(UserEmailAddresses email)
        {
            bool exist = doesEmailAlreadyExist(email);
            if (!exist)
            {
                _dbContext.UserEmailAddress.Add(email);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
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
        /// <summary>
        /// Check if an email for the user already exists.
        /// </summary>
        /// <param name="email">UserEmailAddress</param>
        /// <returns>Boolean if email already exists for the user</returns>
        public bool doesEmailAlreadyExist(UserEmailAddresses email)
        {
            var emails = _dbContext.UserEmailAddress.Where(x => x.ApplicationUserId == email.ApplicationUserId).Where(y => y.emailAddress == email.emailAddress);
            if(emails == null)
            {
                //If no email exists return false
                return false;
            }
            return true;
        }
        #endregion

        #region Update Email Operation
        #endregion

        #region Delete Email operation
        #endregion
    }
}
