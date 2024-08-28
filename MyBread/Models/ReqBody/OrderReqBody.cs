namespace MyBread.Models;

public class OrderReqBody
{
    private string user { get; set; } 
    private List<QuantityNew> quantityList { get; set; }
    
}

public class QuantityNew
{
    private int prodId { get; set; }
    private int quantity { get; set; }
}