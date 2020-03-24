using mvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Repository
{
    interface IProductRepository 
    {
        Task<List<product>> GetAll();

        Task<product> Get(int id);

        Task<int> Add(product entity);

        Task<int> Delete(int id);

        Task Update(product entity);
    }
}
