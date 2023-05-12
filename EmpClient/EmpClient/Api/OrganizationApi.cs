using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class OrganizationApi
    {
        public static List<Organization> GetOrganizations()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations";
            string resStrOrgs = resClient.RestRequestAll();
            List<Organization> orgs = JsonConvert.DeserializeObject<List<Organization>>(resStrOrgs);

            return orgs;
        }

        public static List<Organization> GetOrganizationsWithParentOrg()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/OrganizationsWithParentOrg";
            string resStrOrgs = resClient.RestRequestAll();
            List<Organization> orgs = JsonConvert.DeserializeObject<List<Organization>>(resStrOrgs);

            return orgs;
        }

        public static Organization GetOrganizationByID(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            string resStrOrgs = resClient.RestRequestAll();
            Organization orgs = JsonConvert.DeserializeObject<Organization>(resStrOrgs);

            return orgs;
        }
    }
}