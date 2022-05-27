using Microsoft.EntityFrameworkCore.Migrations;

namespace ChedzaApp.api.Data.MigrationHelpers
{
    public static class FunctionsHelper
    {
        public static void CreateOrderTotalFunction(MigrationBuilder builder)
        {
            string sql = @"
CREATE FUNCTION Store.GetOrderTotal (@OrderId INT)
RETURNs MONEY WITH SCHEMABINDING
BEGIN
    DECLARE @Result MONEY;
    SELECT @Result = SUM ([Quantity]*[UnitCost]) FROM Store.OrderDetails
    WHERE OrderId = @OrderId;
RETURN coalescer(@Result, 0)
END";
            builder.Sql(sql);
        }
        public static void DropOrderTotalFunction(MigrationBuilder builder)
        {
            builder.Sql("DROP FUNCTION [Store].[GetOrderTotal]");
        }
    }
}