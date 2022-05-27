using Microsoft.EntityFrameworkCore.Migrations;
namespace ChedzaApp.api.Data.MigrationHelpers
{
    public static class ViewHelper
    {
        public static void CreateOrderDetailWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql(@"
CREATE VIEW [Store].[OrderDetailWithProductInfo]
AS
SELECT
    od.Id, od.TimeStamp, od.OrderId, od.Quantity, od.UnitCost, od.Quantity*od.UnitCost AS LineItemTotal,
    p.ModelName, p.Description, p.ModelNumber, p.ProductImage, p.ProductImageLarge, p.ProductImageThumb, p.CategoryId, p.UnitsInStock, p.CurrentPrice,
    c.CategoryName
FROM Store.OrderDetails od 
    INNER JOIN Orders o ON o.Id = od.OrderId
    INNER JOIN Products p ON od.ProductId = p.Id 
    INNER JOIN Categories c ON p.CategoryId = c.Id");
        }
        public static void CreateCartRecordWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql(@"
CREATE VIEW [Store].[CartRecordWithProductInfo]
AS
SELECT scr.Id, scr.TimeStamp, scr.DateCreated, scr.CustomerId, scr.Quantity, scr.LineItemTotal, scr.ProductId, p.ModelName, p.Description,
    p.ModelNumber, p.ProductImage, p.ProductImageLarge, p.ProductImageThumb, p.CategoryId, p.UnitsInStock, p.CurrentPrice, 
    c.CategoryName 
FROM Store.ShoppingCartRecords scr 
	INNER JOIN Store.Products p ON p.Id = scr.ProductId
	INNER JOIN Store.Categories c ON c.Id = p.CategoryId");    
        }

        public static void DropOrderDetailWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql("DROP VIEW [Store].[OrderDetailWithProductInfo]");
        }
        public static void DropCartRecordWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql("DROP VIEW [Store].[CartRecordWithProductInfo]");
        }
    }
}