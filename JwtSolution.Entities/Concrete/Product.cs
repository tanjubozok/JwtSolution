using JwtSolution.Entities.Abstract;

namespace JwtSolution.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
