using DataAccessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DAO
{
    public class ShopDAO
    {
        private static ShopDAO instance = null;
        public static readonly object instanceLock = new object();
        private ShopDAO() { }
        public static ShopDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShopDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Shop> GetShops()
        {
            List<Shop> shops;
            try
            {
                var context = new PRN221_DBContext();
                shops = context.Shops.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shops;
        }

        public Shop GetShopByID(int Id)
        {
            Shop shop = null;
            try
            {
                var context = new PRN221_DBContext();
                shop = context.Shops.SingleOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shop;
        }

        public Shop GetShopByCode(string code)
        {
            Shop shop = null;
            try
            {
                var context = new PRN221_DBContext();
                shop = context.Shops.SingleOrDefault(x => x.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shop;
        }

        public void AddNew(Shop shop)
        {
            try
            {
                Shop _shop = GetShopByID(shop.Id);
                if (_shop == null)
                {
                    var context = new PRN221_DBContext();
                    context.Shops.Add(shop);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Shop is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Shop shop)
        {
            try
            {
                Shop c = GetShopByID(shop.Id);
                if (c != null)
                {
                    var context = new PRN221_DBContext();
                    context.Entry<Shop>(shop).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Shop does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int shopId)
        {
            try
            {
                Shop c = GetShopByID(shopId);
                if (c != null)
                {
                    var context = new PRN221_DBContext();
                    context.Shops.Remove(c);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Shop does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
