namespace Deli.Web.Models
{
    // BETTER TO ISOLATE all Microservices
    // even if this is identical with the model from "Deli.Services.ProductAPI"
    // we could add reference to that project
    // with a new ProductDto here we will not affect anything in other projects
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
