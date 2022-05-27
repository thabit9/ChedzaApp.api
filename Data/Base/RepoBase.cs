using System.Linq.Expressions;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Exceptions;
using ChedzaApp.api.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChedzaApp.api.Data.Base
{
    public abstract class RepoBase<T> : IRepo<T> where T : EntityBase, new()
    {
        public DbSet<T> Table { get; }
        public ChedzaContext _context { get; }
        private readonly bool _disposeContext;
        protected RepoBase(ChedzaContext context)
        {
            _context = context;
            Table = _context.Set<T>();            
        }
        protected RepoBase(DbContextOptions<ChedzaContext> options) : this(new ChedzaContext(options))
        {
           _disposeContext = true; 
        }

        public virtual void Dispose()
        {
            if(_disposeContext)
                _context.Dispose();
        }

        //public int Count => throw new NotImplementedException();

        public bool HasChanges => _context.ChangeTracker.HasChanges();
        public (string Schema, string TableName) TableSchemaAndName 
        {
            get
            {
                var metaData = _context.Model.FindEntityType(typeof(T).FullName!)!;
                return (metaData.GetSchema(), metaData.GetTableName())!;
            }
        }
        public int SaveChanges()
        {
            try
            {
               return _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should log and handle intelligently
                throw new ChedzaConcurrencyException("A concurrency error happened.", ex);
            }
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded
                //Should log and handle intelligently
                throw new ChedzaRetryLimitExceededException("There is a problem with you connection.", ex);
            }
            catch (DbUpdateException ex)
            {
                //Should log and handle intelligently
                if (ex.InnerException is SqlException sqlException)
                {
                    if (sqlException.Message.Contains("FOREIGN KEY constraint", 
                    StringComparison.OrdinalIgnoreCase))
                    {
                        if (sqlException.Message.Contains("table \"Store.Products\", column 'Id'",
                        StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ChedzaInvalidProductException($"Invalid Product Id\r\n{ex.Message}", ex);
                        }
                        if (sqlException.Message.Contains("table \"Store.Customers\", column 'Id'",
                        StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ChedzaInvalidCustomerException($"Invalid Customer Id\r\n{ex.Message}", ex);
                        }
                    }
                }
                throw new ChedzaException("An error occurred updating the database", ex);
            }
            catch (Exception ex)
            {
                //Should log and handle intelligently
                throw new ChedzaException("An error occurred updating the database", ex);
            }
        }

        //POST
        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist? SaveChanges() : 0;
        }
        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist? SaveChanges() : 0;
        }
        //DELETE
        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }
        //SEARCH or FIND
        public T Find(int? id) => Table.Find(id)!;
        public T FindAsNoTracking(int id) => 
            Table.Where(x => x.Id == id)
                    .AsNoTracking().FirstOrDefault()!;
        public T FindIgnoreQueryFilters(int id) =>
            Table.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id)!;
        //GET
        public virtual IEnumerable<T> GetAll() => Table;
        public virtual IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy) => 
            Table.OrderBy(orderBy);
        public IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take) => 
            query.Skip(skip).Take(take);
        //PUT
        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }
    }
}