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

            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "1";          
            public const string PriceMaxValue = "100000";          
        }

        //public static class Seller
        //{
        //    public const int PhoneNumberMinLength = 7;
        //    public const int PhoneNumberMaxLength = 15;

        //    public const int EmailAddressMinLength = 5;
        //    public const int EmailAddressMaxLength = 50;
        //}
    }
}
