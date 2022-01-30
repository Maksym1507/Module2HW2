using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            NotificationService.ShowMessage("Product range:\n");
            foreach (var item in _products.ListOfProducts)
            {
                NotificationService.ShowMessage($"{item}\n");
            }

            Console.WriteLine();
        }
    }
}
