using BaseTechnicalTest_JAKSolutions.Models.Entities;

namespace BaseTechnicalTest_JAKSolutions.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
