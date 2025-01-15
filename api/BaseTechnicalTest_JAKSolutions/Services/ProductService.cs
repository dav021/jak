using BaseTechnicalTest_JAKSolutions.Models.DTOs;
using BaseTechnicalTest_JAKSolutions.Models.Entities;
using BaseTechnicalTest_JAKSolutions.Repositories.Interfaces;
using BaseTechnicalTest_JAKSolutions.Services.Interfaces;

namespace BaseTechnicalTest_JAKSolutions.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _productRepository.GetAll();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public ProductDTO? GetById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void Add(ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };
            _productRepository.Add(product);
        }

        public void Update(int id, ProductDTO productDTO)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                product.Name = productDTO.Name;
                product.Price = productDTO.Price;
                _productRepository.Update(product);
            }
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
