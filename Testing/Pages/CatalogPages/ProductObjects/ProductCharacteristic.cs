using System;

namespace Testing.Pages.CatalogPages
{
    public class ProductCharacteristic
    {
        public readonly (string name, string value, bool isWhite) Data;

        public ProductCharacteristic(string name, string value, bool isWhite)
        {
            Data.name = name;
            Data.value = value;
            Data.isWhite = isWhite;
        }

        //Different values should be with different color
        public bool DifferentValuesHaveDifferentColors(ProductCharacteristic verified)
        {
            if (Equals(verified)) return true;
            return Data.name == verified.Data.name &&
                   Data.value != verified.Data.value &&
                   Data.isWhite != verified.Data.isWhite;
        }

        public override string ToString() =>
            string.Format($"[{Data.name}] \"{Data.value}\" (White: {Data.isWhite})");

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(ProductCharacteristic)) return false;
            var verified = (ProductCharacteristic) obj;
            return Data.name == verified.Data.name &&
                   Data.value == verified.Data.value &&
                   Data.isWhite == verified.Data.isWhite;
        }

        public override int GetHashCode() => HashCode.Combine(Data.name, Data.value, Data.isWhite);
    }
}