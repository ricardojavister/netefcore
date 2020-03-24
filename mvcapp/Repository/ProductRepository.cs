using mvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvcapp.Repository
{
    public class ProductRepository : IProductRepository
    {
        CrudDbContext db;
        public ProductRepository(CrudDbContext _db)
        {
            db = _db;
        }

        public async Task<int> Add(product entity)
        {
            if (db != null)
            {
                await db.product.AddAsync(entity);
                await db.SaveChangesAsync();

                return entity.idproduct;
            }

            return 0;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;

            if (db != null)
            {
                var entity = await db.product.FirstOrDefaultAsync(x => x.idproduct == id);

                if (entity != null)
                {
                    //Delete that post
                    db.product.Remove(entity);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<product> Get(int id)
        {
            if (db != null)
            {
                return await db.product.Where(x => x.idproduct == id).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<product>> GetAll()
        {
            if (db != null)
            {
                return await db.product.ToListAsync();
            }

            return null;
        }

        public async Task Update(product entity)
        {
            if (db != null)
            {
                //Delete that post
                db.product.Update(entity);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
