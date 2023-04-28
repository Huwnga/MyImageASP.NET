using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Api
{
    public class SizeApi
    {
        public static List<Size> GetSizes()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes";
            string resStrSizes = resClient.RestRequestAll();
            List<Size> sizes = JsonConvert.DeserializeObject<List<Size>>(resStrSizes);

            return sizes;
        }


        public static List<Size> GetSizesByMaterialID(int materialID)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes/Material?materialID" + materialID;
            string resStrSizesByMaterial = resClient.RestRequestAll();
            List<Size> sizesByMaterial = JsonConvert.DeserializeObject<List<Size>>(resStrSizesByMaterial);

            return sizesByMaterial;
        }
    }
}