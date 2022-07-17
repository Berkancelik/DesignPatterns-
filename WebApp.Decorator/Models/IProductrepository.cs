using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Decorator.Models
{
    public interface IProductrepository
    {
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAll(string userId);
        Task<Product> Save(Product product);
        Task Update(Product product);
        Task Remove(Product product);
    }
}
