using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using PartyInvites.Services;

namespace PartyInvites.Infrastructure.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<ICalculator>().To<ProductCalculator>();
            ////_kernel.Bind<ICalculator>().To<ProductDiscountCalculator>().WithPropertyValue("Discount", 2M);

            //var mockProductRepo = new Mock<IProductRepository>();
            //mockProductRepo.Setup(x => x.Products).Returns(new[]
            //{
            //    new Product() {Id = 1, Name = "Asus", Description = "Smartphone", Price = 4M, Category = Category.Discount.ToString()}, 
            //    new Product() {Id = 2, Name = "Hp", Description = "Pc", Price = 5M, Category = Category.Express.ToString()}, 
            //    new Product() {Id = 3, Name = "Apple", Description = "Ipad", Price = 10M, Category = Category.Supplier.ToString()}, 
            //});
            //_kernel.Bind<IProductRepository>().ToConstant(mockProductRepo.Object);

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Product, ProductViewModel>();
            //    cfg.CreateMap<ProductViewModel, Product>();
            //});
            
            //var mapper = config.CreateMapper();
            //_kernel.Bind<IMapper>().ToConstant(mapper);


        }
    }
}