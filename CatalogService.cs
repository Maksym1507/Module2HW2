using System;
using System.Text;

namespace Practice_6
{
    public class CatalogService
    {
        private static readonly Catalog _products;
        static CatalogService()
        {
            _products = Catalog.Instance;
        }

        public static void ShowProducts()
        {
            Console.WriteLine("Product range: ");
            foreach (var item in _products.ListOfProducts)
            {
                Console.Write(item + "\n");
            }

            Console.WriteLine();
        }
    }
}
