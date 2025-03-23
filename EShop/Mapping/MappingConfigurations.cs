namespace EShop.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductRequest, Product>()
            .Ignore(dest => dest.Images);

        config.NewConfig<Product, ProductDetailsResponse>()
            .Map(x => x.Images, src => src.Images.Select(x => x.Url))
            .Map(dest => dest.Seller, src => new SellerResponse
            (
                src.Seller.Id,
                src.Seller.UserName!,
                src.Seller.ProfileImageUrl
            ))
            .Map(dest => dest.Category, src => src.Category != null ? src.Category.Name : null)
            .Map(dest => dest.SubCategory, src => src.SubCategory != null ? src.SubCategory.Name : null);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.Seller, src => new SellerResponse
            (
                src.Seller.Id,
                src.Seller.UserName!,
                src.Seller.ProfileImageUrl
            ));
    }
}
