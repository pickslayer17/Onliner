namespace Testing.Pages.CatalogPages
{
    public class ProductCharacteristic
    {
        public readonly bool IsWhite;
        public readonly string Name;
        public readonly string Value;

        public ProductCharacteristic(string name, string value, bool isWhite)
        {
            Name = name;
            Value = value;
            IsWhite = isWhite;
        }
    }
}