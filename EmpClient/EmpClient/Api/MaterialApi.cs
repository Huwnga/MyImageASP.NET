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
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Materials";
            string resStrMaterials = resClient.RestRequestAll();
            List<Material> materials = JsonConvert.DeserializeObject<List<Material>>(resStrMaterials);

            return materials;
        }
    }
}