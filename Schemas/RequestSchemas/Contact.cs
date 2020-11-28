using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrameworkAPI.Schemas.RequestSchemas
{
    internal class Contact
    {
        public string firstname;
        public string lastname;
        public string emailaddress1;

        public Contact()
        {
        }

        public Contact(string fname, string lname, string email)
        {
            firstname = fname;
            lastname = lname;
            emailaddress1 = email;
        }
    }
}
