using BusinessObjects.DAO;
using DataAccessObjects.Entity;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductList();
        Product GetProductByID(int id);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(int productId, Product product);
    }
    public class ProductService : IProductService
    {
        public ProductService ()
        {

        }

        public void DeleteProduct(int productId)
        {
            try
            {
                var check = ProductDAO.Instance.GetProductByID(productId);

                if(check == null)
                {
                    throw new Exception("Product Id not found!!!");
                }

                ProductDAO.Instance.Remove(productId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Product GetProductByID(int id)
        {
            try
            {
                var result = ProductDAO.Instance.GetProductByID(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            try
            {
                var result = ProductDAO.Instance.GetProductList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertProduct(Product product)
        {
            try
            {
                var checkCode = ProductDAO.Instance.GetProductByCode(product.ProductCode);               
                if(checkCode != null)
                {
                    throw new Exception("Product already exist!!!");
                }

                ProductDAO.Instance.AddNew(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateProduct(int productId, Product product)
        {
            try
            {
                var check = ProductDAO.Instance.GetProductByID(productId);
                if(check == null)
                {
                    throw new Exception("Product Id not found!!!");
                }
                ProductDAO.Instance.Update(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
