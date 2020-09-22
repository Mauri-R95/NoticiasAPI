using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        //IUnitOfWork UnitOfWork { get; }
        //Tipo generico que grapea todos los T como class
        Task<bool> Exist(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> DeleteAsync(int id);
        Task<T> Update(int id, T element);
        Task<T> Add(T element);
        
    }
}

