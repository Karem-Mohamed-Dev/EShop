namespace EShop.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<CategoryResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<CategoryResponse>> AddAsync(CategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Guid id, CategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleDisableAsync(Guid id, CancellationToken cancellationToken = default);
}
