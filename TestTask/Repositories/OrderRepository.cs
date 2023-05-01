using FluentResults;
using Microsoft.EntityFrameworkCore;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Models.Enums;

namespace TestTask.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Order> GetOrderByIdAsync(Guid id)
    {
        return await DbContext.Order.AsNoTracking()
            .Include(o => o.Lines)
            .Where(o => o.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<Result<Order>> CreateOrder(Order order)
    {
        order.Status = Status.New;
        order.CreatedAt = DateTime.UtcNow;
        order.DeletedAt = null;
        DbContext.Order.Add(order);
        
        await DbContext.SaveChangesAsync();
        return Result.Ok(order);
    }

    public async Task<Result> DeleteOrder(Guid id)
    {
        try
        {
            var order = await GetOrderByIdAsync(id);
            
            if (order == null || order.DeletedAt != null)
            {
                throw new Exception("Заказ не найден");
            }
            
            if (order.Status is Status.Delivered or Status.Delivery or Status.Completed)
            {
                throw new Exception("Заказ нельзя удалить");
            }

            order.DeletedAt = DateTime.UtcNow;
            
            DbContext.Order.Update(order);
            await DbContext.SaveChangesAsync();

            return Result.Ok();
        }
        catch(Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public async Task<Result<Order>> UpdateOrder(Guid id, Order order)
    {
        try
        {
             var dbOrder = await GetOrderByIdAsync(id);

            if (dbOrder == null || dbOrder.DeletedAt != null)
            {
                return Result.Fail("Заказ не найден в БД");
            }

            if (dbOrder.Status is Status.Paid or Status.Delivery or Status.Delivered or Status.Completed)
            {
                return Result.Fail("Этот заказ нельзя редактировать");
            }

            if (dbOrder.Id != order.Id || dbOrder.CreatedAt != order.CreatedAt)
            {
                return Result.Fail("Идентификатор заказа и дату создания нельзя редактировать");
            }
            
            dbOrder.Status = order.Status;
            dbOrder.Lines = order.Lines;

            DbContext.Order.Update(dbOrder);
            await DbContext.SaveChangesAsync();
            return Result.Ok(dbOrder);
        }
        catch(Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}