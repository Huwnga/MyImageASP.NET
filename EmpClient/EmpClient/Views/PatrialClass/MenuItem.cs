using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Views.PatrialClass
{
    public class MenuItem
    {
        public int FunctionID { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public MenuItem () { }
        public MenuItem(int functionID, string href, string icon, string title) 
        {
            this.FunctionID = functionID;
            this.Href = href;
            this.Icon = icon;
            this.Title = title;
        }

        public static List<MenuItem> InitData ()
        {
            List<MenuItem> lMenuItem = new List<MenuItem>();
            lMenuItem.Add(new MenuItem(1, "/Dashboard", "bi bi-speedometer2", "Dashboard"));
            lMenuItem.Add(new MenuItem(2, "/Orders", "bi bi-cart4", "Orders"));
            lMenuItem.Add(new MenuItem(3, "/Accounts", "bi bi-person-fill-gear", "Employees Account"));
            lMenuItem.Add(new MenuItem(4, "/Employees", "bi bi-person-vcard-fill", "Employees"));
            lMenuItem.Add(new MenuItem(5, "/Organizations", "bi bi-buildings-fill", "Organizations"));
            lMenuItem.Add(new MenuItem(6, "/Customers", "bi bi-person-fill", "Customers"));
            lMenuItem.Add(new MenuItem(7, "/Categories", "bi bi-grid-fill", "Categories"));
            lMenuItem.Add(new MenuItem(8, "/Sizes", "bi bi-aspect-ratio-fill", "Sizes"));
            lMenuItem.Add(new MenuItem(9, "/Materials", "bi bi-stack", "Materials"));
            lMenuItem.Add(new MenuItem(10, "/Products", "bi bi-box-fill", "Products"));
            lMenuItem.Add(new MenuItem(11, "/Payments", "bi bi-wallet-fill", "Payments"));
            lMenuItem.Add(new MenuItem(12, "/Feedbacks", "bi bi-star-half", "Feedbacks"));

            return lMenuItem;
        }
    }
}