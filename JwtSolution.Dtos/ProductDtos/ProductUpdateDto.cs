using JwtSolution.Dtos.Abstract;

namespace JwtSolution.Dtos.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
