using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IListService<T>
    {
        Task<T> CreateList(T t);
        Task<T> EditList(int id, T t);
        Task DeleteList(int id);
        Task<IEnumerable<T>> FetchAllList();
    }
}
