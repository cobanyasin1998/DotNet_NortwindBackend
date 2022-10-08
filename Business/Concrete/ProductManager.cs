using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //BUSINESS CODE
            _productDal.Add(product);
           return new SuccesResult(Messages.ProductAdded);

        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccesResult(Messages.ProductDeleted);


        }

        public IDataResult<Product> GetById(int productId)
        {
            
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId)); 
        }

        public IDataResult<List<Product>> GetList()
        {
             return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccesResult(Messages.ProductUpdated);

        }

    }
}
