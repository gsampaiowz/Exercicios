using APIparaTESTE.Domains;

namespace APIparaTESTE.Interfaces
    {
    public interface IProductRepository
        {
        List<Product> Get();
        Product Get(Guid id);
        void Post(Product product);
        void Put(Product product, Guid id);
        void Delete(Guid id);
        }
    }


public static class ProductEndpoints
{
	public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Product");

        group.MapGet("/", () =>
        {
            return new [] { new Product() };
        })
        .WithName("GetAllProducts")
        .Produces<Product[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", (int id) =>
        {
            //return new Product { ID = id };
        })
        .WithName("GetProductById")
        .Produces<Product>(StatusCodes.Status200OK);

        group.MapPut("/{id}", (int id, Product input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", (Product model) =>
        {
            //return Results.Created($"/api/Products/{model.ID}", model);
        })
        .WithName("CreateProduct")
        .Produces<Product>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (int id) =>
        {
            //return Results.Ok(new Product { ID = id });
        })
        .WithName("DeleteProduct")
        .Produces<Product>(StatusCodes.Status200OK);
    }
}