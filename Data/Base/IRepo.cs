using System.Linq.Expressions;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Base
{
    public interface IRepo<T> where T : EntityBase
    {
        DbSet<T> Table { get; }
        ChedzaContext _context { get; }
        (string Schema, string TableName) TableSchemaAndName { get; }

        //int Count { get; }
        bool HasChanges { get; }
        //Searching or finding
        T Find(int? id);
        T FindAsNoTracking(int id);
        T FindIgnoreQueryFilters(int id);
        //GET
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy);
        IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take);
        //POST
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        //PUT
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist =true);
        //DELETE
        int Delete(T entity, bool persist = true);
        //int Delete(int id, byte[] timeStamp, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        //SAVE
        int SaveChanges();

    }
}