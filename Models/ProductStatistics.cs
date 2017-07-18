using System;

namespace EventsApp.Models
{
    public class ProductStatistics : IComparable<ProductStatistics>
    {
        public string Id { get; set; }

        public int Count { get; set; }

        public double Quantity { get; set; }

        public ProductStatistics(string id)
        {
            Id = id;
            Count = 0;
            Quantity = 0;
        }

        public override string ToString()
        {
            return Id;
        }

        public int CompareTo(ProductStatistics other)
        {
            return other == null ? 1 : Id.CompareTo(other.Id);
        }

        public ProductStatistics IncrementCount(int value = 1)
        {
            Count += value;
            return this;
        }

        public ProductStatistics AddQuantity(double quantity)
        {
            Quantity += quantity;
            return this;
        }
    }
}
