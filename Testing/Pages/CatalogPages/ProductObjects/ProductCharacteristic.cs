using System;

namespace Testing.Pages.CatalogPages
{
    public class ProductCharacteristic
    {
        private readonly (string name, string value, string color) Data;

        public ProductCharacteristic(string name, string value, string isWhite)
        {
            Data.name = name;
            Data.value = value;
            Data.color = isWhite;
        }


        private bool OneColorIsOrangeOtherIsWhite(ProductCharacteristic verified) =>
            ColorIsWhite() && verified.ColorIsOrange() || ColorIsOrange() && verified.ColorIsWhite();

        private bool ColorIsWhite() => Data.color == TestSettings.CellWhiteColor;

        private bool ColorIsOrange() => Data.color == TestSettings.CellOrangeColor;

        //Different values should be with different color
        public bool DifferentValuesHaveDifferentColors(ProductCharacteristic verified)
        {
            if (Equals(verified)) return true;
            return Data.name == verified.Data.name &&
                   Data.value != verified.Data.value &&
                   Data.color != verified.Data.color &&
                   OneColorIsOrangeOtherIsWhite(verified);
        }

        public override string ToString() =>
            string.Format($"[{Data.name}] \"{Data.value}\" (Color: {Data.color})");

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(ProductCharacteristic)) return false;
            var verified = (ProductCharacteristic) obj;
            return Data.name == verified.Data.name &&
                   Data.value == verified.Data.value &&
                   Data.color == verified.Data.color;
        }

        public override int GetHashCode() => HashCode.Combine(Data.name, Data.value, Data.color);
    }
}