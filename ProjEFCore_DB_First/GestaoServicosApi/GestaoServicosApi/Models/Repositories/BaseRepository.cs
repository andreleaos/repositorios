using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoServicosApi.Models.Repositories
{
    public interface BaseRepository<T, Y> 
    {
        void Create(T entity);
        List<T> Read();
        T GetById(Y id);
        void Update(T entity);
        void Delete(Y id);
    }
}
