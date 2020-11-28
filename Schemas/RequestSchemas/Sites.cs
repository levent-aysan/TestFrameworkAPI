using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrameworkAPI.Schemas.RequestSchemas
{
    internal class Sites
    {
        public decimal he_siteareaha;
        public string he_name;
        public int he_pipelineopportunityid;

        public Sites()
        {
        }

        public Sites(decimal siteArea, string name, int oppId)
        {
            he_siteareaha = siteArea;
            he_name = name;
            he_pipelineopportunityid = oppId;
        }
    }
}
