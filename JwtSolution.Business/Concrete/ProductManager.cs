using JwtSolution.Business.Abstract;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
        }
    }
}
