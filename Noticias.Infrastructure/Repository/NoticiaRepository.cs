using Dapper;
//using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Models.Noticia;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Infrastructure.Repository
{
    public class NoticiaRepository : INoticiaRepository
    { 
        private string ConnectionString;
        private readonly INoticiasDBContext _noticiasDBContext;

        public NoticiaRepository(/*INoticiasDBContext noticiasDBContext,*/ SqlConfiguration connectionString)
        {
            //_noticiasDBContext = noticiasDBContext;
            ConnectionString =  connectionString.ConnectionString;
        }
        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<Noticia> Adds(Noticia e)
        {
            var db = dbConnection();
            var sql = @"Insert INTO Noticia (Titulo, Descripcion, Contenido, AutorID, Fecha)
                VALUES (@Titulo, @Descripcion, @Contenido, @AutorID, @Fecha) ; SELECT CAST(SCOPE_IDENTITY() as int) ";
            var result = await db.QueryAsync<int>(sql.ToString(),
                new { e.Titulo, e.Descripcion, e.Contenido, e.AutorID, e.Fecha });
            e.NoticiaID = result.Single();
            return result.Count() > 0 ? e : null;
        }

        public async Task<Noticia> Add(Noticia e)
        {
            
            var db = dbConnection();
            var sql = @"
                Insert INTO Noticia (Titulo, Descripcion, Contenido, AutorID, Fecha)
                VALUES (@Titulo, @Descripcion, @Contenido, @AutorID, @Fecha) ";
            var result = await db.ExecuteAsync(sql.ToString(),
                new { e.Titulo, e.Descripcion, e.Contenido, e.AutorID, e.Fecha });
            return result > 0 ? e : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM Noticia WHERE NoticiaID = @Id ";
            var result = await db.ExecuteAsync(sql.ToString(), new { Id = id });
            return result > 0;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Noticia> Get(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM Noticia WHERE NoticiaID = @Id";

            return await db.QueryFirstOrDefaultAsync<Noticia>(sql.ToString(), new { Id = id });
        }

        public IEnumerable<Noticia> GetAlls()
        {
            var db = dbConnection();
            var sql = "SELECT NoticiaID,Titulo, Descripcion, Contenido, Fecha, AutorID FROM Noticia";
            db.Open();
            return db.Query<Noticia>(sql.ToString());
        }

        public async Task<IEnumerable<Noticia>> GetAll()
        {
            var db = dbConnection();
            //var sql = @" SELECT NoticiaID,Titulo, Descripcion, Contenido, Fecha, AutorID FROM [dbo].[Noticia]";
            var sql = "SELECT NoticiaID,Titulo, Descripcion, Contenido, Fecha, AutorID FROM Noticia";
            //var sql = @" SELECT * FROM Noticia";
            return await db.QueryAsync<Noticia>(sql.ToString());
            //var result = _noticiasDBContext.Noticia.Include(x => x.AutorID).AllAsync>;

            //Console.WriteLine("Noticias" + noticia);
            //return noticia;
        }

        public async Task<Noticia> Update(int id, Noticia e)
        {
            var db = dbConnection();
            var sql = @"UPDATE Noticia 
                    SET Titulo = @Titulo, Descripcion = @Descripcion,
                    Contenido = @Contenido WHERE NoticiaID = @Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { e.Titulo, e.Descripcion, e.Contenido, Id = id });
            return result > 0 ? e : null;
        }
    }
}
