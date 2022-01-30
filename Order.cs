﻿namespace Practice_6
{
    public class Order
    {
        private readonly string[] _selectedProducts;
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
        public static Order[] Orders { get; set; }
    }
}
