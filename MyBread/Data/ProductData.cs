using MyBread.Models;

namespace MyBread.Db;

public class ProductData
{
    private Data data = new Data();
    public IEnumerable<Product> FindAll()
    {
        return data.Products.ToList();
    }

    public Product FindById(int id)
    {
        return data.Products.Find(id);
    }

    public Product FindByNameProd(string nameProd)
    {
        return data.Products.FirstOrDefault(product => product.NameProd == nameProd);
    }
    public void DelById(int id)
    {
        Product product = FindById(id);
        if (product != null)
        {
            data.Products.Remove(product);
            data.SaveChanges();
        }
    }
    public void Save(Product product)
    {
        data.Products.Add(product);
        data.SaveChanges();
    }
    public void Update(Product product)
    {
        data.Products.Update(product);
        data.SaveChanges();
    }

    public void UpdateQuantityAll(IEnumerable<int> quantityProdList)
    {
        IEnumerable<Product> products = FindAll();
        for (int i = 0; i < products.Count(); i++)
        {
            products.ElementAt(i).QuantityProd = quantityProdList.ElementAt(i);
            Update(products.ElementAt(i));
        }
    }
    public void UpdatePriceAll(IEnumerable<int> priceProdList)
    {
        IEnumerable<Product> products = FindAll();
        for (int i = 0; i < products.Count(); i++)
        {
            products.ElementAt(i).PriceProd = priceProdList.ElementAt(i);
            Update(products.ElementAt(i));
        }
    }
}