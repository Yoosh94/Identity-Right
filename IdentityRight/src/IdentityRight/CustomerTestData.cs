using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight
{
    class CustomerTestData
    {
        private long _ID;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Password;
        private string _Address;

        private List<string> _Orgs;

        public CustomerTestData(long id, string firstName, string lastName, string email, string address)
        {
            _ID = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Email = email;
            _Address = address;

            _Password = "AAFDJ454SJDShJH";
        }


        public override string ToString()
        {
            return string.Format("ID: {0}, {1}, {2}, Email: {3}, Address: {4}", _LastName, _FirstName, _ID, _Email, _Address);
        }


        public string GenerateInsert()
        {
            //Guid g = new Guid();

            return string.Format("insert into AspNetUsers (Id,Email,FirstName,LastName,EmailConfirmed,LockoutEnabled,PhoneNumberConfirmed,TwoFactorEnabled,isAccountCompleted,AccessFailedCount) values('{0}','{1}','{2}','{3}',0,1,0,0,0,0);", Guid.NewGuid(), _Email, _FirstName, _LastName);
        }

        //string query = @"insert into AspNetUsers (Id,Email,FirstName,LastName,EmailConfirmed,LockoutEnabled,PhoneNumberConfirmed,TwoFactorEnabled,isAccountCompleted,AccessFailedCount) values('hdddsd','tt@tt.com','Ayush','Kumar',0,1,0,0,0,0);";

    }
}
