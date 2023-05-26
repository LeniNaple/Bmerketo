using Bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels
{
    public class AddProductsViewModel
    {
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "A Description is required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "A Price is required")]
        public string Price { get; set; } = null!;

        [Required(ErrorMessage = "An image is required")]
        public string ImgUrl { get; set; } = null!;

        public string? ProductTag { get; set; }


        public static implicit operator ProductEntity(AddProductsViewModel viewModel)
        {
            return new ProductEntity
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                ImgUrl = viewModel.ImgUrl,
                ProductTag = viewModel.ProductTag,
            };
        }


    }
}