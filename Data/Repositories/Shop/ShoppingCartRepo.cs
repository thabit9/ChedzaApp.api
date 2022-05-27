using System.Data;
using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Exceptions;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class ShoppingCartRepo : RepoBase<ShoppingCart>, IShoppingCartRepo
    {
        private readonly IProductRepo productRepo;
        private readonly ICustomerRepo customerRepo;
        public ShoppingCartRepo(ChedzaContext context, IProductRepo productRepo,
            ICustomerRepo customerRepo) : base(context)
        {
            this.productRepo = productRepo;
            this.customerRepo = customerRepo;
        }
        internal ShoppingCartRepo(DbContextOptions<ChedzaContext> options) : base(new ChedzaContext(options))
        {
            this.productRepo = new ProductRepo(_context);
            this.customerRepo = new CustomerRepo(_context);
            base.Dispose();
        }
        public override int Add(ShoppingCart entity, bool persist = true)
        {
            var product = this.productRepo.FindAsNoTracking(entity.ProductId);
            if(product == null)
            {
                throw new ChedzaInvalidProductException("Unable to locate the product");
            }
            return Add(entity, product, persist);
        }
        public int Add(ShoppingCart entity, Product product, bool persist = true)
        {
            var item = GetBy(entity.ProductId);
            if(item == null)
            {
                if(entity.Quantity > product._Stock_Count)
                {
                    throw new ChedzaInvalidQuantityException(
                    "Can't add more product than available in stock");
                }
                entity.LineItemTotal = entity.Quantity * product._Current_Price;
                return base.Add(entity, persist);
            }
            item.Quantity += entity.Quantity;
            return item.Quantity <= 0 ? Delete(item, persist) : Update(item, product, persist);
        }
        public override void Dispose()
        {
            this.productRepo._context.Dispose();
            this.customerRepo._context.Dispose();
            base.Dispose();
        }
        public override IEnumerable<ShoppingCart> GetAll() =>
            base.GetAll(x => x.DateCreated!).ToList();
        public ShoppingCart GetBy(int productId) =>
            Table.FirstOrDefault(x => x.ProductId == productId)!;

        public CartRecordWithProductInfo GetShoppingCartRecord(int id) =>
            _context.CartRecordWithProductInfos.FirstOrDefault(x => x.Id == id)!;
        
        public IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId)
            => _context.CartRecordWithProductInfos.Where(x => x.CustomerId == customerId).OrderBy(x => x.ModelName);

        public CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId) => 
            new CartWithCustomerInfo()
            {
                CartRecords = GetShoppingCartRecords(customerId).ToList(),
                Customer = this.customerRepo.Find(customerId)
            };
        
        public int Purchase(int customerId)
        {
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = customerId
            };
            var orderIdParam = new SqlParameter("@orderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            try
            {
                _context.Database.ExecuteSqlRaw(
                "EXEC [Store].[PurchaseItemsInCart] @customerId, @orderid out",
                customerIdParam, orderIdParam);
            }
            catch (Exception /*ex*/)
            {
                return -1;
            }
            return (int)orderIdParam.Value;

        }
        public override int Update(ShoppingCart entity, bool persist = true)
        {
            var product = this.productRepo.FindAsNoTracking(entity.ProductId);
            if (product == null)
            {
                throw new ChedzaInvalidProductException("Unable to locate product");
            }
            return Update(entity, product, persist);
        }
        public int Update(ShoppingCart entity, Product product, bool persist = true)
        {
            if (entity.Quantity <= 0)
            {
                return Delete(entity, persist);
            }
            if (entity.Quantity > product._Stock_Count) {
                throw new ChedzaInvalidQuantityException("Can't add more products than availible in stock");
            }
            var dbRecord = Find(entity.Id);
            if (entity.TimeStamp != null && dbRecord.TimeStamp.SequenceEqual(entity.TimeStamp))
            {
                dbRecord.Quantity = entity.Quantity;
                dbRecord.LineItemTotal = entity.Quantity * product._Current_Price;
                return base.Update(dbRecord, persist);
            }
            throw new ChedzaConcurrencyException("Record was changed since it was loaded");

        }
        public override int UpdateRange(IEnumerable<ShoppingCart> entities, bool persist = true)
        {
            int counter = 0;
            foreach (var item in entities)
            {
                var product = this.productRepo.FindAsNoTracking(item.ProductId);
                counter += Update(item, product, false);
            }
            return persist ? SaveChanges() : counter;

        }
        public override int AddRange(IEnumerable<ShoppingCart> entities, bool persist = true)
        {
            int counter = 0;
            foreach (var item in entities)
            { var product = this.productRepo.FindAsNoTracking(item.ProductId);
                counter += Add(item, product, false);
            }
            return persist ? SaveChanges() : counter;
        }
    }
}