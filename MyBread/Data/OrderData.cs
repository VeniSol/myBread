using MyBread.Converters;
using MyBread.Models;
using MyBread.Models.DTO;

namespace MyBread.Db;

public class OrderData
{
    private OrderConverter OrderConverter = new OrderConverter();
    private Data data = new Data();
    private ProductData productData = new ProductData();
    public List<OrderDTO> FindAll()
    {
        return OrderConverter.ordersToOrderDTO(data.Orders.ToList());
    }

    public Order FindById(int id)
    {
        return data.Orders.Find(id);
    }
    
    public void UpdateQuantityAll(List<int> quantityOrderList)
    {
        List<OrderDTO> orders = FindAll();
        for (int i = 0; i < orders.Count(); i++)
        {
            orders.ElementAt(i).Order.Quantity = quantityOrderList.ElementAt(i);
            Update(orders.ElementAt(i).Order);
        }
    }

    public void delOrderById(int id) {
        Order order = FindById(id);
        if (order != null)
        {
            data.Orders.Remove(order);
            data.SaveChanges();
        }
    }
    
    public void Save(Order order)
    {
        data.Orders.Add(order);
        data.SaveChanges();
    }

    public void Update(Order order)
    {
        data.Orders.Update(order);
        data.SaveChanges();
    }
}