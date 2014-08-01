using System;
using System.Collections.Generic;
using System.Web;
namespace WebApp
{
    /// <summary>
    ///Company 的摘要说明
    /// </summary>
    public class Company
    {
        public Company(int id, string name, double price, double change, double pctChange)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Change = change;
            this.PctChange = pctChange;
        }
        public int ID;
        public string Name;
        public double Price;
        public double Change;
        public double PctChange;
        //public int ID { get; set; }
        //public string Name { get; set; }
        //public double Price { get; set; }
        //public double Change { get; set; }
        //public double PctChange { get; set; }
    }
}