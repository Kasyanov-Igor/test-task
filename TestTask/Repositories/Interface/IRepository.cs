using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_task.Repositories.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task<bool> Delete(int id);
    }
}
