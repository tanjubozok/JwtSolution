using AutoMapper;
using JwtSolution.Business.Abstract;
using JwtSolution.Dtos.ProductDtos;
using JwtSolution.Entities.Concrete;
using JwtSolution.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtSolution.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _productService.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
        }

        [HttpPut("{id}")]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return NoContent();
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var errorLog = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;
            
            var data = errorLog.Data;
            var helpLink = errorLog.HelpLink;
            var hResult = errorLog.HResult;
            var innerException = errorLog.InnerException;
            var message = errorLog.Message;
            var source = errorLog.Source;
            var stackTrace = errorLog.StackTrace;
            var targetSite = errorLog.TargetSite;

            return Problem(detail: "Apide bir problem oldu, en kısa sürede düzelecektir.");
        }
    }
}
