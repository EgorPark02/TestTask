using FluentResults;
using TestTask.Models;

namespace TestTask.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    /// Получение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Order> GetOrderByIdAsync(Guid id);
    
    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<Result<Order>> CreateOrder(Order order);

    /// <summary>
    /// Удаление заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Result> DeleteOrder(Guid id);

    /// <summary>
    /// Редактирование / Изменение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<Result<Order>> UpdateOrder(Guid id, Order order);
}