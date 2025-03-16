namespace EShop.Services;

public interface ISubCategoryService
{
    Task<Result<IEnumerable<SubCategoryResponse>>> GetAllAsync(Guid categoryId, bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<SubCategoryResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<SubCategoryResponse>> AddAsync(SubCategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Guid id, SubCategoryRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken = default);
}
