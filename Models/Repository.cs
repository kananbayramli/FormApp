namespace FormsApp.Models;

public class Repository{

    private static readonly List<Product> _products = new();
    private static readonly List<Category> _categories = new();

    static Repository()
    {
        _categories.Add(new Category{CategoryId = 1, Name="Telefon"});
        _categories.Add(new Category{CategoryId = 2, Name="Notebook"});


        _products.Add(new Product{ProductId=1,Name="Iphone 13 Pro", Price=2000, IsActive=true, Image="2.png", CategoryId=1});
        _products.Add(new Product{ProductId=2,Name="Iphone 14 Pro", Price=3000, IsActive=true, Image="3.png", CategoryId=1});
        _products.Add(new Product{ProductId=3,Name="Iphone 15", Price=4000, IsActive=true, Image="4.png", CategoryId=1});
        _products.Add(new Product{ProductId=4,Name="Iphone 13 Pro Max", Price=3500, IsActive=true, Image="6.png", CategoryId=1});

        _products.Add(new Product{ProductId=5,Name="Macbook Air", Price=2000, IsActive=true, Image="1.png", CategoryId=2});
        _products.Add(new Product{ProductId=6,Name="Asus NOT", Price=2000, IsActive=true, Image="7.png", CategoryId=2});

    }

    public static List<Product> Products{
        get{
            return _products;
        }
    }



    public static void CreateProduct(Product entity)
    {
        _products.Add(entity);
    }




    public static List<Category> Categories{
        get{
            return _categories;
        }
    }


}