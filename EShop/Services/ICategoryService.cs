namespace EShop.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<CategoryResponse>> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<Result<CategoryResponse>> AddAsync(CategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(string id, CategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleDisableAsync(string id, CancellationToken cancellationToken = default);
}
