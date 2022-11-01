using DataAccessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var context = new PRN221_DBContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductByCode(string code)
        {
            Product product = null;
            try
            {
                var fStoreDB = new PRN221_DBContext();
                product = fStoreDB.Products.SingleOrDefault(product => product.ProductCode == code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public Product GetProductByID(int productID)
        {
            Product product = null;
            try
            {
                var fStoreDB = new PRN221_DBContext();
                product = fStoreDB.Products.SingleOrDefault(product => product.Id == productID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.Id);
                if (_product == null)
                {
                    var fStoreDB = new PRN221_DBContext();
                    fStoreDB.Products.Add(product);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product p = GetProductByID(product.Id);
                if (p == null)
                {
                    var fStoreDB = new PRN221_DBContext();
                    fStoreDB.Entry<Product>(product).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This product does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int productId)
        {
            try
            {
                Product _product = GetProductByID(productId);
                if (_product == null)
                {
                    var fStoreDB = new PRN221_DBContext();
                    fStoreDB.Products.Remove(_product);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This product does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
