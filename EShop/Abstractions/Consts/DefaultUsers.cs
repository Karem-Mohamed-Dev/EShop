namespace EShop.Abstractions.Consts;

public static class DefaultUsers
{
    public static class Admin
    {
        public static readonly string Id = "01957b40-a60a-7413-ae16-6c4727049ca9";
        public const string Email = "admin@eshop.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAECmR5YUNa+8lm4NNTA5ONhy0jRto2LT7XAmS+CBwFwJ4Z6F5+4erVz4AVQ0ZLuC/fg==";
        //public const string Password = "Admin@123";
        public const string SecurityStamp = "96ADA591-B04C-4D37-B57B-9FCBA8262C5B";
        public const string ConcurrencyStamp = "283AEB14-CE9F-4AE0-88F9-4C86FCEFA221";
    }

    public static class Client
    {
        public static readonly string Id = "01957b40-a60b-780d-b328-f9bf9c4aa691";
        public const string Email = "client@test.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEMie4u7ffTRAMN7ZbSrikIwbANJmNMC/1n4oBXgFcrSo32sL0xcUG75XenUMNGFCig==";
        //public const string Password = "Client@123";
        public const string SecurityStamp = "19439CAF-856D-46A7-9903-6141810F446B";
        public const string ConcurrencyStamp = "303BE4AC-8A47-4B2F-91F2-2BB1B459470D";
    }

    public static class Seller
    {
        public static readonly string Id = "01957b40-a60b-780d-b328-f9c0cd4b0d85";
        public const string Email = "seller@test.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEEgeAgFomAVkZC8mbMWMscDo/z55UzNa4DfNUGSOlMThA2y5+JxkICCpDvnPH1Tp0A==";
        //public const string Password = "Seller@123";
        public const string SecurityStamp = "B99E64F4-E3AC-449E-843D-5CC67A1FCAFF";
        public const string ConcurrencyStamp = "1238F62D-0C73-4298-B0B5-F85FDFE9CDBB";
    }
}
