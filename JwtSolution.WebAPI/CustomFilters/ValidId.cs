using JwtSolution.Business.Abstract;
using JwtSolution.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace JwtSolution.WebAPI.CustomFilters
{
    public class ValidId<T> : IActionFilter where T : class, IEntity, new()
    {
        private readonly IGenericService<T> _genericService;

        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();
            var checkedId = (int)dictionary.Value;

            var entity = _genericService.GetByIdAsync(checkedId).Result;
            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{checkedId} idli nesne bulunamdı");
            }
        }
    }
}
