using System.ComponentModel.DataAnnotations.Schema;

namespace MyBread.Models;

public class Order
{
    public Order(User user, Product product, int quantity)
    {
        this.userId = userId;
        this.productId = productId;
        this.quantity = quantity;
    }

    public Order(int id, int userId, int productId, int quantity)
    {
        this.id = id;
        this.userId = userId;
        this.productId = productId;
        this.quantity = quantity;
    }

    public Order()
    {
    }

    private int id;
    private int userId;
    private int productId;
    private int quantity;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    
    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public int ProductId
    {
        get {return productId;}
        set { productId = value; }
    }

    public int Quantity
    {
        get { return quantity;}
        set { quantity = value; }
    }
    
    
}