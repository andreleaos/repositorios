using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoServicosApi.Models.Services
{
    public interface BaseService<T, Y>
    {
        void Create(T entity);
        List<T> Read();
        T GetById(Y id);
        void Update(T entity);
        void Delete(Y id);
    }
}
