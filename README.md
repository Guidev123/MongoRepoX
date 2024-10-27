<body style="text-align: center;">

<div align="center">
    <img  src="https://github.com/user-attachments/assets/75d29e4b-b88c-43db-a5f1-396f6338e464" />
</div>


<h1>MongoRepoX - MongoDB Repository Library</h1>

<p><strong>MongoRepoX</strong>MongoRepoX is a generic MongoDB repository library that simplifies CRUD operations, making it easy to work with MongoDB collections in a flexible and strongly-typed way. Additionally, the library supports pagination, making it easier to handle large datasets efficiently.</p>

<h2>Usage</h2>

<h3>1. Define an Entity</h3>
<p>Create your entity class, implementing <code>IEntityBase&lt;TKey&gt;</code> and specifying the identifier type. In this example, we use <code>Guid</code> for the ID of the <code>Product</code> entity.</p>

<pre style="color: black; background-color: white;">
<code>
public class Product : IEntityBase&lt;Guid&gt;
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public Product(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}
</code>
</pre>

<h3>2. Define the Repository Interface</h3>
<p>Create a repository interface for <code>Product</code>, inheriting from the generic <code>IRepository&lt;Product, Guid&gt;</code>. This allows for easy extension of the repository with product-specific methods, if needed.</p>

<pre style="color: black; background-color: white;">
<code>
public interface IProductRepository : IRepository&lt;Product, Guid&gt;
{
    // Define product-specific methods if needed
}
</code>
</pre>

<h3>3. Create a Repository</h3>
<p>Next, create a custom repository class that inherits from <code>Repository&lt;Product, Guid&gt;</code>. This repository allows CRUD operations on the <code>Products</code> collection in MongoDB.</p>

<pre style="color: black; background-color: white;">
<code>
public class ProductRepository(IMongoDatabase mongoDatabase)
           : Repository<Product, Guid>(mongoDatabase, "Products"), IProductRepository
{
}
</code>
</pre>

<h3>4. Create a Service for Business Logic</h3>
<p>Next, create a <code>ProductService</code> class that utilizes the <code>IProductRepository</code> to manage product operations. This service handles the logic for adding, updating, retrieving, and removing products.</p>

<pre style="color: black; background-color: white;">
<code>
public class ProductService(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.CreateAsync(product);
    }
}
</code>
</pre>

<h2>Contributing</h2>
<p>Contributions are welcome! Feel free to open issues, submit pull requests, or suggest features to improve MongoRepoX.</p>

</body>
