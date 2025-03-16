

using System.Collections.Generic;

namespace EShop.Services;

public class SubCategoryService(AppDbContext context) : ISubCategoryService
{
    private readonly AppDbContext _context = context;

    public async Task<Result<IEnumerable<SubCategoryResponse>>> GetAllAsync(Guid categoryId, bool includeDisabled = false, CancellationToken cancellationToken = default)
    {
        if (!await _context.Categories.AnyAsync(x => x.Id == categoryId, cancellationToken))
            return Result.Failure<IEnumerable<SubCategoryResponse>>(CategoryErrors.NotFound);

        IEnumerable<SubCategoryResponse> subs = await _context.SubCategories
            .AsNoTracking()
            .Where(x => x.CategoryId == categoryId && (!x.IsDisabled || includeDisabled))
            .ProjectToType<SubCategoryResponse>()
            .ToListAsync(cancellationToken);

        return Result.Success(subs);
    }

    public async Task<Result<SubCategoryResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if(await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } sub)
            return Result.Failure<SubCategoryResponse>(SubCategoryErrors.NotFound);

        return Result.Success(sub.Adapt<SubCategoryResponse>());
    }

    public async Task<Result<SubCategoryResponse>> AddAsync(SubCategoryRequest request, CancellationToken cancellationToken = default)
    {
        if(await _context.SubCategories.AnyAsync(x => x.Name == request.Name, cancellationToken))
            return Result.Failure<SubCategoryResponse>(SubCategoryErrors.DuplicateSubCategory);

        var sub = new SubCategory { Name = request.Name, CategoryId = request.CategoryId };
        await _context.SubCategories.AddAsync(sub, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success(sub.Adapt<SubCategoryResponse>());
    }

    public async Task<Result> UpdateAsync(Guid id, SubCategoryRequest request, CancellationToken cancellationToken = default)
    {
        if(await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } sub)
            return Result.Failure(SubCategoryErrors.NotFound);

        if (await _context.SubCategories.AnyAsync(x => x.Name == request.Name && x.Id != sub.Id, cancellationToken))
            return Result.Failure(SubCategoryErrors.DuplicateSubCategory);

        sub.Name = request.Name;
        sub.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } sub)
            return Result.Failure(SubCategoryErrors.NotFound);

        sub.IsDisabled = !sub.IsDisabled;
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
