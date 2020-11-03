using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevannRadhak_03_11_2020.Interfaces
{
    public interface IRestfulService<T> where T : class
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<ICollection<T>> GetManyAsync(int id);
    }
}
