namespace EShop.Services;

public class CategoryService(AppDbContext context) : ICategoryService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<CategoryResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await _context.Categories
            .Where(x => !x.IsDisabled || includeDisabled)
            .AsNoTracking()
            .ProjectToType<CategoryResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<CategoryResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {        
        if(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } category)
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound);

        return Result.Success(category.Adapt<CategoryResponse>());
    }

    public async Task<Result<CategoryResponse>> AddAsync(CategoryRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.Categories.AnyAsync(x => x.Name == request.Name))
            return Result.Failure<CategoryResponse>(CategoryErrors.DuplicateCategory);

        var category = new Category { Name = request.Name };

        await _context.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(category.Adapt<CategoryResponse>());
    }

    public async Task<Result> UpdateAsync(Guid id, CategoryRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } category)
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound);

        if (await _context.Categories.AnyAsync(x => x.Name == request.Name && x.Id != id, cancellationToken))
            return Result.Failure<CategoryResponse>(CategoryErrors.DuplicateCategory);

        if(category.Name != request.Name)
        {
            category.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);
        }

        return Result.Success();
    }

    public async Task<Result> ToggleDisableAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (await _context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } category)
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound);

        category.IsDisabled = !category.IsDisabled;
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
