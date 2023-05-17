using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class MaterialApi
    {
        public static List<Material> GetMaterials()
        {
            string endPoint = "api/Materials";
            List<Material> materials = ApiTemplate.GetByEndPoint<List<Material>>(endPoint);

            return materials;
        }

        public static List<Material> GetMaterialsWithAll()
        {
            string endPoint = "api/MaterialsWithAll";
            List<Material> materials = ApiTemplate.GetByEndPoint<List<Material>>(endPoint);

            return materials;
        }

        public static Material GetMaterialByID(int id)
        {
            string endPoint = "api/Materials?id=" + id;
            Material materials = ApiTemplate.GetByEndPoint<Material>(endPoint);

            return materials;
        }

        public static Material InsMat(Material mat)
        {
            string endPoint = "api/Materials";
            Material material = ApiTemplate.InserObjByEndPoint<Material>(endPoint, mat);

            return material;
        }

        public static bool UpdMat(int id, Material prd)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Materials?id=" + id;
            bool isSuccess = resClient.UpdateData(prd);

            return isSuccess;
        }

        public static bool DelMat(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Materials?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}