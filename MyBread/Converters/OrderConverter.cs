using MyBread.Db;
using MyBread.Models;
using MyBread.Models.DTO;

namespace MyBread.Converters;

public class OrderConverter
{
    private ProductData productData = new ProductData();
    
    public OrderDTO orderToOrderDTO(Order order)
    {
        return new OrderDTO(order, productData.FindById(order.ProductId));
    }
    
    public List<OrderDTO> ordersToOrderDTO(IEnumerable<Order> orders)
    {
        List<OrderDTO> orderDTOs = new List<OrderDTO>();
        foreach (var order in orders)
        {
            orderDTOs.Add(orderToOrderDTO(order));
        }

        return orderDTOs;
    }
}