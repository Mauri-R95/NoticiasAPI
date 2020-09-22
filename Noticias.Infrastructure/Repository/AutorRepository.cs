using Noticias.Domain.Models.Autor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Infrastructure.Repository
{
    public class AutorRepository : IAutorRepository
    {
        public Task<Autor> Add(Autor element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Autor> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Autor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Autor> Update(int id, Autor element)
        {
            throw new NotImplementedException();
        }
    }
}
