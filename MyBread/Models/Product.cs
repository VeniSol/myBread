namespace MyBread.Models;

public class Product
{
    public Product( string nameProd, double priceProd, int quantityProd)
    {
        this.nameProd = nameProd;
        this.priceProd = priceProd;
        this.quantityProd = quantityProd;
    }
    public Product(int id, string nameProd, double priceProd, int quantityProd)
    {
        this.id = id;
        this.nameProd = nameProd;
        this.priceProd = priceProd;
        this.quantityProd = quantityProd;
    }

    public Product()
    {
    }

    private int id;
    private string nameProd;
    private double priceProd;
    private int quantityProd;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string NameProd
    {
        get { return nameProd; }
        set { nameProd = value; }
    }

    public double PriceProd
    {
        get { return priceProd; }
        set { priceProd = value; }
    }

    public int QuantityProd
    {
        get { return quantityProd; }
        set { quantityProd = value; }
    }
}