using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Models.Enums;

namespace TestTask.Controllers;

[ApiController]
[Route("[controller]")]

public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    /// <summary>
    /// Получение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet ("GetOrder")]
    public async Task<ActionResult> GetOrder(Guid id)
    {
        try
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null || order.DeletedAt != null)
            {
                return BadRequest("Заказ не найден");
            }
            return Ok(order);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpPost("CreateOrder")]
    public async Task<ActionResult> CreateOrder(Order order)
    {
        try
        {
            return Ok((await _orderRepository.CreateOrder(order)).Value);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Удаление заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteOrder")]
    public async Task<ActionResult> DeleteOrder(Guid id)
    {
        var deleteResult = await _orderRepository.DeleteOrder(id);
        if (deleteResult.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(deleteResult.Errors.FirstOrDefault());
    }
    
    /// <summary>
    /// Редактирование / Изменение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpPut("UpdateOrder")]
    public async Task<ActionResult> UpdateOrder(Guid id, Order order)
    {
        
        var updateResult = await _orderRepository.UpdateOrder(id, order);
        
        if (updateResult.IsSuccess)
        {
            return Ok(updateResult.Value);
        }
        
        return BadRequest(updateResult.Errors.FirstOrDefault());
    }

}