using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class UserApi
    {
        public static List<User> GetUsers()
        {
            string endPoint = "api/Users";
            List<User> users = ApiTemplate.GetByEndPoint<List<User>>(endPoint);

            return users;
        }
        public static List<User> GetUsersWithAll()
        {
            string endPoint = "api/UsersWithAll";
            List<User> users = ApiTemplate.GetByEndPoint<List<User>>(endPoint);

            return users;
        }

        public static User GetUser(int id)
        {
            string endPoint = "api/Users?id=" + id;
            User users = ApiTemplate.GetByEndPoint<User>(endPoint);

            return users;
        }

        public static User Login(User user)
        {
            string endPoint = "api/User/Login";
            User u = ApiTemplate.InserObjByEndPoint<User>(endPoint, user);

            return u;
        }

        public static bool CheckFunctionByUser(int functionID, int userID)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Users/CheckFunction?functionID=" + functionID + "&userID=" + userID;
            string resStrObj = resClient.InsertData();

            if (!resStrObj.StartsWith("Error:"))
            {
                bool nObj = JsonConvert.DeserializeObject<bool>(resStrObj);

                return nObj;
            }

            return false;
        }

        public static User InsUser(User user)
        {
            string endPoint = "api/Users";
            User u = ApiTemplate.InserObjByEndPoint<User>(endPoint, user);

            return u;
        }

        public static bool DelUser(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Users?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}