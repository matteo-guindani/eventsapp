using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventsApp.Database;
using EventsApp.Models;
using MongoDB.Driver;

namespace EventsApp.Repositories
{
    public class PlanRepository : Repository<Plan>
    {
        public PlanRepository(IDatabaseContext context) : base(context.Plans)
        {
        }

        public IList GetProductsStatistics()
        {
            IDictionary<string, ProductStatistics> results = new Dictionary<string, ProductStatistics>();

            foreach (var plan in Collection.Find("{}").ToCursor().ToEnumerable())
            {
                foreach (var prescription in plan.Prescriptions)
                {
                    var product = prescription.Product;
                    if (!results.ContainsKey(product))
                    {
                        results.Add(product, new ProductStatistics(product));
                    }

                    results[product]
                        .IncrementCount()
                        .AddQuantity(prescription.TotalQuantity);
                }
            }

            return results.Values.ToList();
        }
    }
}
