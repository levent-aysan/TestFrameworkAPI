using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrameworkAPI.Schemas.RequestSchemas
{
    internal class PartnerDetails
    {
        public string name;
        public string he_accounttype;
        public string accountnumber;
        public string he_originalcapturename;

        public PartnerDetails()
        {
        }

        public PartnerDetails(string PartnerName, string AccType, string AccNo, string OrgName)
        {
            name = PartnerName;
            he_accounttype = AccType;
            accountnumber = AccNo;
            he_originalcapturename = OrgName;       
        }
    }
}
