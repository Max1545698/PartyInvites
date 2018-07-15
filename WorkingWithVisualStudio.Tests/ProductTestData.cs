using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    [Serializable]
    class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPriceUnder50() };
            yield return new object[] { GetPriceOver50 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPriceUnder50()
        {
            decimal[] prices = { 275, 49.95M, 19.50M, 24.95M };

            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product { Name = $"P{i + 1}", Price = prices[i] };
            }
        }

        private Product[] GetPriceOver50 => new Product[]
        {
            new Product{Name = "P1", Price = 5},
            new Product{Name = "P2", Price = 49.95M},
            new Product{Name = "P3", Price = 19.50M},
            new Product{Name = "P4", Price = 24.95M}
        };

    }
}
