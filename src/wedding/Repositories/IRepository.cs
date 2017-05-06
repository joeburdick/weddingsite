using System.Threading.Tasks;

namespace wedding.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T item);

        //Task UpdateAsync(T item);

        //Task DeleteAsync(int id);

        Task<T> GetAsync(int id);
    }
}
