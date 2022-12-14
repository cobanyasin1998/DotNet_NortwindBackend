using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        IHttpContextAccessor _httpContextAccessor;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }
        [ValidationAspect(typeof(ProductValidator), Priority = 2)]

        public IResult Add(Product product)
        {


            //Business Codes

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
        [PerformanceAspect(1)]
        //[ExceptionLogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }
        [SecuredOperation("Product.List,Admin")]

        [CacheAspect(duration: 1)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product prd)
        {
            _productDal.Update(prd);
            //_productDal.Add(prd);

            return new SuccesResult(Messages.ProductAdded);

        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccesResult(Messages.ProductUpdated);
        }

    }
}
