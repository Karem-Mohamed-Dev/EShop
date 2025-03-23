namespace EShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<Result<ProductDetailsResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ProductDetailsResponse>> AddAsync(Guid id, ProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Guid id, Guid sellerId, ProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken = default);
}
