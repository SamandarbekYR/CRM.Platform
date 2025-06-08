using CRM.DataAccess.EfCode;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Attribute;

public class ValidateApiKeyUsageAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var db = context.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
        var request = context.HttpContext.Request;

        if (!request.Headers.TryGetValue("X-CLIENT-NAME", out var clientName) ||
            !request.Headers.TryGetValue("X-API-KEY", out var apiKey) ||
            !request.Headers.TryGetValue("X-MAC-ADDRESS", out var mac))
        {
            context.Result = new UnauthorizedObjectResult("Missing headers");
            return;
        }

        var client = await db.TrustedClients.FirstOrDefaultAsync(c =>
            c.ApiKey == apiKey && c.Name == clientName);

        if (client == null)
        {
            context.Result = new ForbidResult("Invalid client.");
            return;
        }

        if (client.FirstUsedAt != null)
        {
            var expiresAt = client.FirstUsedAt.Value + client.ExpirationAfterUse;
            if (DateTime.UtcNow > expiresAt)
            {
                client.IsUsed = true;
                await db.SaveChangesAsync();
                context.Result = new ForbidResult("API Key expired.");
                return;
            }

            if (client.MacAddress != mac)
            {
                context.Result = new ForbidResult("API Key already used by another device.");
                return;
            }
        }
        else
        {
            client.MacAddress = mac;
            client.FirstUsedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }

        await next(); 
    }
}

