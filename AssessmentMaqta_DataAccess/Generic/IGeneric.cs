using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_DataAccess.Generic
{
    public interface IGeneric<T>
    {
        Task<int> Insert(T obj);
        Task Update(T obj);
        Task delete(int Id);
        Task<T> Load(int Id);
        Task<List<T>> LoadAll();
    }
}
