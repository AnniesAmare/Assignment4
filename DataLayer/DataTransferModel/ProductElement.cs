using DataLayer.Model;

namespace DataLayer
{
    public class ProductElement
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        //CATEGORY
        public Category Category { get; set; }
    }
}