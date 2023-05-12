using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Views.PatrialClass
{
    public class MenuItem
    {
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public MenuItem () { }
        public MenuItem(string href, string icon, string title) 
        {
            this.Href = href;
            this.Icon = icon;
            this.Title = title;
        }

        public static List<MenuItem> InitData ()
        {
            List<MenuItem> lMenuItem = new List<MenuItem>();
            lMenuItem.Add(new MenuItem("/Dashboard", "bi bi-speedometer2", "Dashboard"));
            lMenuItem.Add(new MenuItem("/Orders", "bi bi-cart4", "Orders"));
            lMenuItem.Add(new MenuItem("/Accounts", "bi bi-person-fill-gear", "Employees Account"));
            lMenuItem.Add(new MenuItem("/Employees", "bi bi-person-vcard-fill", "Employees"));
            lMenuItem.Add(new MenuItem("/Organizations", "bi bi-buildings-fill", "Organizations"));
            lMenuItem.Add(new MenuItem("/Customers", "bi bi-person-fill", "Customers"));
            lMenuItem.Add(new MenuItem("/Categories", "bi bi-grid-fill", "Categories"));
            lMenuItem.Add(new MenuItem("/Sizes", "bi bi-speedometer2", "Sizes"));
            lMenuItem.Add(new MenuItem("/Materials", "bi bi-stack", "Materials"));
            lMenuItem.Add(new MenuItem("/Products", "bi bi-box-fill", "Products"));
            lMenuItem.Add(new MenuItem("/Payments", "bi bi-wallet-fill", "Payments"));

            return lMenuItem;
        }
    }
}