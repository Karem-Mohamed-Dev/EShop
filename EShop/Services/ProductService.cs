
using System.Collections.Generic;

namespace EShop.Services;

public class ProductService(AppDbContext context) : IProductService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<ProductResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.Products
            .AsNoTracking()
            .Where(x => !x.IsDisabled)
            .ProjectToType<ProductResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<ProductDetailsResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .AsNoTracking()
            .Where(x => x.Id == id && !x.IsDisabled)
            .ProjectToType<ProductDetailsResponse>()
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
            return Result.Failure<ProductDetailsResponse>(ProductErrors.NotFound);

        return Result.Success(product);
    }

    public async Task<Result<ProductDetailsResponse>> AddAsync(Guid sellerId, ProductRequest request, CancellationToken cancellationToken = default)
    {
        if(request.CategoryId is not null)
        {
            if (await _context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken))
                return Result.Failure<ProductDetailsResponse>(CategoryErrors.NotFound);
        }

        if (request.SubCategoryId is not null)
        {
            if (await _context.SubCategories.AnyAsync(x => x.Id == request.SubCategoryId, cancellationToken))
                return Result.Failure<ProductDetailsResponse>(SubCategoryErrors.NotFound);
        }


        var product = request.Adapt<Product>();
        product.SellerId = sellerId;

        product.Images = request.Images.Select(x => new ProductImage
        {
            ProductId = sellerId,
            Url = x
        }).ToList();

        _context.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success(product.Adapt<ProductDetailsResponse>());
    }

    public async Task<Result> UpdateAsync(Guid id, Guid sellerId, ProductRequest request, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        if (product.SellerId != sellerId)
            return Result.Failure(ProductErrors.NotAllowed);

        if (product.Images.Select(x => x.Url).Except(request.Images).Any())
        {
            _context.ProductImages.RemoveRange(product.Images);
            await _context.ProductImages.AddRangeAsync(request.Images.Select(x => new ProductImage
            {
                ProductId = id,
                Url = x
            }), cancellationToken);
        }
        product = request.Adapt(product);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if(await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } product)
            return Result.Failure(ProductErrors.NotFound);

        product.IsDisabled = !product.IsDisabled;
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
