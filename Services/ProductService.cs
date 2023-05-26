using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bmerketo.Services;

public class ProductService
{
    private readonly ProductContext _productContext;

    public ProductService(ProductContext productContext)
    {
        _productContext = productContext;
    }


    //Searches for product with the same name
    public async Task<bool> ProductExists(AddProductsViewModel viewModel)
    {
        try
        {
            ProductEntity _productEntity = viewModel;

            var _productInfo = await _productContext.Products.FirstOrDefaultAsync(x => x.Name == viewModel.Name);
            if (_productInfo != null)
            {
                return false;
            }else
            {
                //Adds new product to db
               return AddNewProduct(viewModel).Result;
            }
        }
        catch
        {
            return false;
        }
    }


    //Creates product, from form by viewmodel
    public async Task<bool> AddNewProduct(AddProductsViewModel viewModel)
    {
        try
        {
            ProductEntity _productEntity = viewModel;

            _productContext.Add(new ProductEntity
            {
                Name = _productEntity.Name,
                Description = _productEntity.Description,
                Price = _productEntity.Price,
                ImgUrl = _productEntity.ImgUrl,
                ProductTag = _productEntity.ProductTag,

            });

            // Saves changes to user
            await _productContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }

    }


    //Puts all products into a list
    public async Task<IEnumerable<ProductEntity>> GetAllProducts()
    {
        return await _productContext.Set<ProductEntity>().ToListAsync();
    }

    //Puts all products with, expression to a list
    public async Task<IEnumerable<ProductEntity>> GetAllProducts(Expression<Func<ProductEntity, bool>> expression)
    {
        return await _productContext.Set<ProductEntity>().Where(expression).ToListAsync();
    }

    //Get single product by ID, should work in SingleProductController but doesnt return a proper ProductEntity...
    public async Task<ProductEntity> GetSingleProduct(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = await _productContext.Set<ProductEntity>().FirstOrDefaultAsync(expression);
        if (entity != null)
        {
            return entity;
        }
        return null!;
    }



    //Gets product from database, by id that it gets from the controller (Which the controller gets from the link on the product)
    //Is not async / await, but seems to work anyhow... 
    public ProductEntity GetProductById(Guid id)
    {
        var product = _productContext.Products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            return product;
        }
        else
            return null!;
    }


}
