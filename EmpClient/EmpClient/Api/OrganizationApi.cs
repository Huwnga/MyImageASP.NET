using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EmpClient.Api
{
    public class OrganizationApi
    {
        public static List<Organization> GetOrganizations()
        {
            string endPoint = "api/Organizations";
            List<Organization> orgs = ApiTemplate.GetListByEndPoint<Organization>(endPoint);

            return orgs;
        }

        public static List<Organization> GetOrganizationsWithParentOrg()
        {
            string endPoint = "api/OrganizationsWithParentOrg";
            List<Organization> orgs = ApiTemplate.GetListByEndPoint<Organization>(endPoint);

            return orgs;
        }

        public static List<Organization> GetChilrensByParentID(int ParentID)
        {
            string endPoint = "api/OrganizationsWithParentOrg?parentID=" + ParentID;
            List<Organization> orgs = ApiTemplate.GetListByEndPoint<Organization>(endPoint);

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

        public static Organization InsertOrganization(Organization org)
        {
            string endPoint = "api/Organizations";
            Organization organization = ApiTemplate.InserObjByEndPoint<Organization>(endPoint, org);

            return organization;
        }

        public static bool UpdateOrganization(int id, Organization org)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            bool isSuccess = resClient.UpdateData(org);

            return isSuccess;
        }

        public static bool DeleteOrganization(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}