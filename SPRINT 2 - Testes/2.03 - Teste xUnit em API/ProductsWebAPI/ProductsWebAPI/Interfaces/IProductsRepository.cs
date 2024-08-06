using ProductsWebAPI.Domains;

namespace ProductsWebAPI.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> Get();
        Products GetById(Guid productId);
        void Post(Products newProduct);
        Products Delete(Guid productId);
        Products Put(Products updatedProduct);
    }
}
