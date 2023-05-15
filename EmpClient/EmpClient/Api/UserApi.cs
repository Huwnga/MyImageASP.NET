using EmpClient.Models;
using System;
using System.Collections.Generic;
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
        public List<User> GetUsersWithAll()
        {
            string endPoint = "api/UsersWithAll";
            List<User> users = ApiTemplate.GetByEndPoint<List<User>>(endPoint);

            return users;
        }

        public List<User> GetUser(int id)
        {
            string endPoint = "api/Users?id=" + id;
            List<User> users = ApiTemplate.GetByEndPoint<List<User>>(endPoint);

            return users;
        }

        public User Login(User user)
        {
            string endPoint = "api/User/Login";
            User u = ApiTemplate.InserObjByEndPoint<User>(endPoint, user);

            return u;
        }
    }
}