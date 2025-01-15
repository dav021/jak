using BaseTechnicalTest_JAKSolutions.Models.DTOs;

namespace BaseTechnicalTest_JAKSolutions.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO? GetById(int id);
        void Add(ProductDTO productDto);
        void Update(int id, ProductDTO productDto);
        void Delete(int id);
    }
}
