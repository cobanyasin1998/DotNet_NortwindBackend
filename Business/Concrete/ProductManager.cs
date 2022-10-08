using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {


        public void Add(Product prd)
        {

        }

        public void Delete(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
