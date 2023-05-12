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
            string resStrCats = resClient.RestRequestAll();
            List<Organization> orgs = JsonConvert.DeserializeObject<List<Organization>>(resStrCats);

            return orgs;
        }

        public static List<Organization> GetOrganizationByID(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            string resStrCats = resClient.RestRequestAll();
            List<Organization> orgs = JsonConvert.DeserializeObject<List<Organization>>(resStrCats);

            return orgs;
        }
    }
}