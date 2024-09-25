using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IResultGeneric
{
    public interface IResult<T> where T : class
    {
        Result<T> GetById(int id);
        Result<IEnumerable<T>> GetAll(string? code = null);
        Result<T> Create(T result);
        Result<T> Update(T result);
        Result<T> Delete(int id);

    }
}
