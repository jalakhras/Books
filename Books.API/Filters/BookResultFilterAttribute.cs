using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class BookResultFilterAttribute : ResultFilterAttribute
    {

        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
               || resultFromAction.StatusCode < 200
               || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(resultFromAction.Value.GetType()))
                resultFromAction.Value = mapper.Map<IEnumerable<Models.Book>>(resultFromAction.Value);
            else
                resultFromAction.Value = mapper.Map<Models.Book>(resultFromAction.Value as Entity.Book);
            await next();
        }
    }

}
