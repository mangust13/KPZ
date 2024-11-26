using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerControllerSorter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths
            .OrderBy(p => p.Key.Contains("/Clients") ? 0 : 1) // Пріоритет для Clients
            .ThenBy(p => p.Key) // Решта в алфавітному порядку
            .ToDictionary(p => p.Key, p => p.Value);

        swaggerDoc.Paths = new OpenApiPaths();

        foreach (var path in paths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }
    }
}
