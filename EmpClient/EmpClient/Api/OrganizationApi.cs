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
        public static List<Organization> GetAllOrganization()
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations";
            string KetQua = rClient.RestRequestAll();
            List<Organization> OrganizationList = JsonConvert.DeserializeObject<List<Organization>>(KetQua);
            return OrganizationList;
        }

        public static Organization GetOrganizationByID(int id)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Organizations?OrganizationID=" + id;
            string KetQua = rClient.RestRequestAll();
            List<Organization> OrganizationId = JsonConvert.DeserializeObject<List<Organization>>(KetQua);
            return OrganizationId[0];
        }

        // POST: Employees/Create

        public static int CreateOrganization(Organization obj)
        {
            ResClient rClient = new ResClient();

            //truyen qua obj
            rClient.EndPoint = "api/Organizations";
            int KQ = rClient.InsertData(obj);

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // POST: Employees/Edit/5

        public static int UpdateOrganization(Organization obj, int id)
        {
            ResClient rClient = new ResClient();

            //truyen qua obj
            rClient.EndPoint = "api/Organizations/" + id;
            int KQ = rClient.UpdateData(obj);

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }



        // POST: Employees/Delete/5
        public static int DeleteOrganization(int id)
        {
            ResClient rClient = new ResClient();

            //truyen qua obj
            rClient.EndPoint = "api/Organizations/" + id;
            int KQ = rClient.DeleteData();

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}