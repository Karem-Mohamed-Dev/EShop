namespace EShop.Abstractions.Consts;

public static class DefaultRoles
{
    public static class Admin
    {
        public static readonly string Id = "01957b56-0791-7fb2-846a-d59db7d302f8";
        public const string Name = nameof(Admin);
        public const string ConcurrencyStamp = "CC0B5346-F8AD-4580-8B6C-E88F70D2A493";
    }

    public static class Client
    {
        public static readonly string Id = "01957b56-0791-7fb2-846a-d59ed8104780";
        public const string Name = nameof(Client);
        public const string ConcurrencyStamp = "9ADD3A9D-00D3-42DF-83FD-E8FAA10CA3DD";
    }

    public static class Seller
    {
        public static readonly string Id = "01957b56-0791-7fb2-846a-d59f359f3426";
        public const string Name = nameof(Seller);
        public const string ConcurrencyStamp = "76CE33FE-E990-4DF4-A4B0-712609EE0A62";
    }
}