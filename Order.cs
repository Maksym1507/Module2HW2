using System;
using System.Text;

namespace Practice_6
{
    public class Order
    {
        private string[] _selectedProducts;
        private static int _id;

        public Order(string[] selectedProducts)
        {
            _selectedProducts = selectedProducts;
            _id++;
            ID = _id;
        }

        public string[] SelectedProducts => _selectedProducts;
        public int Quantity { get; set; }
        public int ID { get; set; }
    }
}
