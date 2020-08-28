using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
