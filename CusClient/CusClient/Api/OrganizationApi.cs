using CusClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusClient.Api
{
    public class OrganizationApi
    {
        public static List<Organization> GetAllOrganization()
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations";
            string results = rClient.RestRequestAll();
            List<Organization> lOrg = JsonConvert.DeserializeObject<List<Organization>>(results);

            return lOrg;
        }

        public static Organization GetOrganizationByID(int id)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations?id=" + id;
            string results = rClient.RestRequestAll();
            Organization org = JsonConvert.DeserializeObject<Organization>(results);

            return org;
        }

        // POST: Employees/Create

        public static bool CreateOrganization(Organization obj)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations";
            bool result = rClient.InsertData(obj);

            return result;
        }

        // POST: Employees/Edit/5

        public static bool UpdateOrganization(Organization obj, int id)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations?id" + id;
            bool result = rClient.UpdateData(obj);

            return result;
        }



        // POST: Employees/Delete/5
        public static bool DeleteOrganization(int id)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations?id"+id;
            bool result = rClient.DeleteData();

            return result;
        }
    }
}