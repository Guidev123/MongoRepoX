<body>

<h1>MongoRepoX - MongoDB Repository Library</h1>

<p><strong>MongoRepoX</strong> is a generic MongoDB repository library that simplifies CRUD operations, making it easy to work with MongoDB collections in a flexible and strongly-typed way.</p>

<h2>Usage</h2>

<h3>1. Define an Entity</h3>
<p>Create your entity class, implementing <code>IEntityBase&lt;TKey&gt;</code> and specifying the identifier type. In this example, we use <code>Guid</code> for the ID of the <code>Product</code> entity.</p>

<pre><code>
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
</code></pre>

<h3>2. Create a Repository</h3>
<p>Next, create a custom repository class that inherits from <code>Repository&lt;Product, Guid&gt;</code>. This repository allows CRUD operations on the <code>Products</code> collection in MongoDB.</p>

<pre><code>

public class ProductRepository : Repository&lt;Product, Guid&gt;, IProductRepository
{
    public ProductRepository(IMongoDatabase mongoDatabase)
        : base(mongoDatabase, "Products") { }
}
</code></pre>

<h2>Contributing</h2>
<p>Contributions are welcome! Feel free to open issues, submit pull requests, or suggest features to improve MongoRepoX.</p>

</body>
