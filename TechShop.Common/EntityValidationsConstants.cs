namespace TechShop.Common
{
    public class EntityValidationsConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Product
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 70;

            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 50;

            public const int DescriptionMinLength = 30;
            public const int DescriptionMaxLength = 1000000;

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 5;

            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "1";          
            public const string PriceMaxValue = "100000";          
        }

        public static class CartValidations
        {
            public const string TotalPriceMinValue = "0";
            public const string TotalPriceMaxValue = "2147483647";

            public const string QuantityMinValue = "0";
            public const string QuantityMaxValue = "100";
        }

        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 20;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 70;

            public const int CountryMinLength = 2;
            public const int CountryMaxLength = 60;

            public const int CityMinLength = 2;
            public const int CityMaxLength = 50;

            public const int AddressMinLength = 4;
            public const int AddressMaxLength = 100;

            public const int PostCodeMinLength = 3;
            public const int PostCodeMaxLength = 10;

            public const int DescriptionMaxLength = 10000;

        }
    }
}
