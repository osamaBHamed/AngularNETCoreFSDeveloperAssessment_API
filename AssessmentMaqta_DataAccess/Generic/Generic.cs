using AssessmentMaqta_DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_DataAccess.Generic
{
    public class Generic<T>:IGeneric<T> where T:class
    {
        private readonly AssessmentContext context;

        public Generic(AssessmentContext _context)
        {
            context = _context;
        }
        public async Task<int> Insert(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await context.SaveChangesAsync();
            var Id = obj.GetType().GetProperty("Id").GetValue(obj, null);
            return (int)Id;
        }

        public async Task Update(T obj)
        {
            //context.Set<T>().Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task delete(int Id)
        {
            T obj = await context.Set<T>().FindAsync(Id);
            context.Set<T>().Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<T> Load(int Id)
        {
            T obj = await context.Set<T>().FindAsync(Id);
            return obj;
        }

        public async Task<List<T>> LoadAll()
        {
            List<T> li = await context.Set<T>().ToListAsync();
            return li;
        }
    }
}
