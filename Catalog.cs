namespace Practice_6
{
    public class Catalog
    {
        private static readonly Catalog _instance;
        private static readonly string[] _listOfProducts =
            {
                "Shirt model 1",
                "T-shirt model 1",
                "Socks model 1",
                "Cap",
                "Jeans model 1",
                "Trousers",
                "Hat",
                "Gloves",
                "Hoodie",
                "Jacket model 1",
                "Shirt model 2",
                "Socks model 2",
                "Jeans model 2"
            };

        static Catalog()
        {
            _instance = new Catalog();
        }

        public string[] ListOfProducts => _listOfProducts;
        public static Catalog Instance => _instance;
    }
}
