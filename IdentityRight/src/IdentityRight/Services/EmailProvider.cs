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
            //Check if the email address already exits
            bool exist = doesEmailAlreadyExist(email);
            //If it doesn't add the email address to the database.
            if (!exist)
            {
                _dbContext.UserEmailAddress.Add(email);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method will set the specified email to confirmed = true status
        /// </summary>
        /// <param name="user">Application User object</param>
        /// <param name="email">email address to confirm as a string</param>
        /// <returns>Boolean if email was confirmed</returns>
        public bool ConfirmEmail(ApplicationUser user, string email)
        {
            //check if email already exists
            bool exist = doesEmailAlreadyExist(user,email);
            //If it does exist find the email and update the 'confirmed' field to true.
            if (exist)
            {
                var emailObject = getEmailAddress(user, email);
                //Ensure that an object was returned so we can update it.
                if(emailObject != null)
                {
                    _dbContext.UserEmailAddress.Update(emailObject);
                    emailObject.Confirmed = true;
                    _dbContext.SaveChanges();
                    //Sucessfully confirmed email
                    return true;
                }
                //Email not successfully updated
                return false;
            }
            //Email does not exist.
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
            foreach(UserEmailAddresses email in emails)
            {
                email.ApplicationUser = user;
            }
            return emails;
        }
        /// <summary>
        /// Check if an email for the user already exists.
        /// </summary>
        /// <param name="email">UserEmailAddress</param>
        /// <returns>Boolean if email already exists for the user</returns>
        public bool doesEmailAlreadyExist(UserEmailAddresses email)
        {
            var emails = _dbContext.UserEmailAddress.Where(x => x.ApplicationUserId == email.ApplicationUserId)
                .Where(y => y.emailAddress == email.emailAddress).ToList();
            if(emails.Count == 0)
            {
                //If no email exists return false
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if an email for the user already exists.
        /// </summary>
        /// <param name="user">Application User object</param>
        /// <param name="emailAddress">email address as a string</param>
        /// <returns>Boolean if email already exists for the user</returns>
        public bool doesEmailAlreadyExist(ApplicationUser user, string emailAddress)
        {
            var emails = _dbContext.UserEmailAddress.Where(x => x.ApplicationUserId == user.Id)
                .Where(z => z.emailAddress == emailAddress).ToList();
            if(emails.Count == 0)
            {
                //No email address for that user with that email exists
                return false;
            }
            //Email address does exist.
            return true;
        }

        /// <summary>
        /// Get the UserEmailAddress object for a particular user
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <param name="emailAddress">email address to find as a string</param>
        /// <returns>UserEmailAddress object</returns>
        public UserEmailAddresses getEmailAddress(ApplicationUser user, string emailAddress)
        {
            var emails = _dbContext.UserEmailAddress.Where(x => x.ApplicationUserId == user.Id)
                .Where(z => z.emailAddress == emailAddress).ToList();
            //There should only be one email in the list since we cannot have duplicate emails.
            if (emails.Count == 1)
            {
                return emails.First();
            }
            return null;
        }
        #endregion

        #region Delete Email operation
        public bool deleteEmailAddress(UserEmailAddresses email)
        {
            _dbContext.UserEmailAddress.Remove(email);
            _dbContext.SaveChanges();
            var exists = doesEmailAlreadyExist(email);
            if (!exists)
            {
                return true;
            }
            //something went wrong and email still exists for the user.
            return false;
        }
        #endregion
    }
}
