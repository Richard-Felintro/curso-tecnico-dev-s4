using ProductsWebAPI.Context;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;

namespace ProductsWebAPI.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        public ProductsContext ctx = new();
        public Products Delete(Guid productId)
        {
            try
            {
                var itemDelete = ctx.Products.First(x => x.Id == productId);
                ctx.Products.Remove(itemDelete);
                ctx.SaveChanges();
                return (itemDelete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Products> Get()
        {
            try
            {
                return (ctx.Products.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products GetById(Guid productId)
        {
            try
            {
                return (ctx.Products.First(x => x.Id == productId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(Products newProduct)
        {
            try
            {
                ctx.Products.Add(newProduct);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products Put(Products updatedProduct)
        {
            try
            {
                Products itemUpdate = ctx.Products.First(x => x.Id == updatedProduct.Id);
                if(itemUpdate != null)
                {
                    itemUpdate.Name = updatedProduct.Name;
                    itemUpdate.Price = updatedProduct.Price;
                }
                ctx.Products.Update(itemUpdate);
                ctx.SaveChanges();
                return updatedProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
