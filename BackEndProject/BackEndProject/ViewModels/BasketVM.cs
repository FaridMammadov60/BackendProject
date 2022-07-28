using System;

namespace BackEndProject.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }       
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool InStock { get; set; }
        public int StockCount { get; set; }
        public double Price { get; set; }
        public double DisCountPrice { get; set; }
        public double TaxPrecent { get; set; }

        public int ProductCount { get; set; }
        public Nullable<double> ProductTotalPrice { get; set; }
        public Nullable<double> SumPrice { get; set; }
    }
}
