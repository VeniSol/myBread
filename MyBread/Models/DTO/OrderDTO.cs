namespace MyBread.Models.DTO;

public class OrderDTO
{
    private Order order;
    private Product product;

    public OrderDTO(Order order, Product product)
    {
        this.order = order;
        this.product = product;
    }

    public OrderDTO()
    {
    }

    public Order Order
    {
        get => order;
        set => order = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Product Product
    {
        get => product;
        set => product = value ?? throw new ArgumentNullException(nameof(value));
    }
}