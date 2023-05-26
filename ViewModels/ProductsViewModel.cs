using Bmerketo.Models.Entities;

namespace Bmerketo.ViewModels;

public class ProductsViewModel
{

    public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();

}
