using System;
using Northwind.Entities.Enums;

namespace Northwind.Entities.POCOEntities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }   
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public ShippingType ShippingType { get; set; }
    }
}