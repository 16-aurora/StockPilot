using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StockPilot.Api.Data;
using StockPilot.Api.Models;

namespace StockPilot.Api.Endpoints;

public static class ProductsEndpoints
{
    public static void MapProductsEndpoints(this WebApplication app)
    {
        // Obtener todos los productos
        app.MapGet("/api/products", async (AppDbContext db) =>
        {
            var products = await db.Products.ToListAsync();
            return Results.Ok(products);
        });

        // Crear un producto nuevo y validar sus datos
        app.MapPost("/api/products", async (
            Product product,
            AppDbContext db) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(product);

            bool isValid = Validator.TryValidateObject(
                product,
                validationContext,
                validationResults,
                validateAllProperties: true
            );

            if (!isValid)
            {
                var errors = validationResults
                    .GroupBy(result =>
                        result.MemberNames.FirstOrDefault() ?? "Product")
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(
                            result => result.ErrorMessage
                                ?? "Dato no válido"
                        ).ToArray()
                    );

                return Results.ValidationProblem(errors);
            }

            // Comprobar que el SKU no exista
            var skuExists = await db.Products.AnyAsync(
                p => p.SKU.ToLower() == product.SKU.ToLower()
            );

            if (skuExists)
            {
                return Results.Conflict(new
                {
                    message = "Ya existe un producto con ese SKU."
                });
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return Results.Created(
                $"/api/products/{product.Id}",
                product
            );
        });

        // Actualizar un producto existente
        app.MapPut("/api/products/{id:int}", async (
            int id,
            Product updatedProduct,
            AppDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);

            if (product is null)
            {
                return Results.NotFound(new
                {
                    message = $"No existe un producto con el ID {id}."
                });
            }

            // Validar los datos recibidos
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(updatedProduct);

            bool isValid = Validator.TryValidateObject(
                updatedProduct,
                validationContext,
                validationResults,
                validateAllProperties: true
            );

            if (!isValid)
            {
                var errors = validationResults
                    .GroupBy(result =>
                        result.MemberNames.FirstOrDefault() ?? "Product")
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(
                            result => result.ErrorMessage
                                ?? "Dato no válido"
                        ).ToArray()
                    );

                return Results.ValidationProblem(errors);
            }

            // Evitar que otro producto tenga el mismo SKU
            var skuExists = await db.Products.AnyAsync(
                p => p.Id != id &&
                     p.SKU.ToLower() == updatedProduct.SKU.ToLower()
            );

            if (skuExists)
            {
                return Results.Conflict(new
                {
                    message = "Otro producto ya utiliza ese SKU."
                });
            }

            // Actualizar los campos sin cambiar el ID
            product.Name = updatedProduct.Name;
            product.SKU = updatedProduct.SKU;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;
            product.MinimumStock = updatedProduct.MinimumStock;

            await db.SaveChangesAsync();

            return Results.Ok(product);
        });

        // Eliminar un producto existente
        app.MapDelete("/api/products/{id:int}", async (
            int id,
            AppDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);

            if (product is null)
            {
                return Results.NotFound(new
                {
                    message = $"No existe un producto con el ID {id}."
                });
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Results.Ok(new
            {
                message = $"El producto '{product.Name}' se ha eliminado correctamente."
            });
        });
    }
}