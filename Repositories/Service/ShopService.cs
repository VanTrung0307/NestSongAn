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
    public interface IShopService
    {
        IEnumerable<Shop> GetShopList();
        Shop GetShopByID(int id);
        void InsertShop(Shop shop);
        void DeleteShop(int id);
        void UpdateShop(int id, Shop shop);
    }
    public class ShopService : IShopService
    {
        public void DeleteShop(int id)
        {
            try
            {
                var check = ShopDAO.Instance.GetShopByID(id);

                if (check == null)
                {
                    throw new Exception("Shop Id not found!!!");
                }

                ShopDAO.Instance.Remove(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Shop GetShopByID(int id)
        {
            try
            {
                var result = ShopDAO.Instance.GetShopByID(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Shop> GetShopList()
        {
            try
            {
                var result = ShopDAO.Instance.GetShops();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertShop(Shop shop)
        {
            try
            {
                var checkCode = ShopDAO.Instance.GetShopByCode(shop.Code);
                if (checkCode != null)
                {
                    throw new Exception("Shop already exist!!!");
                }

                ShopDAO.Instance.AddNew(shop);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateShop(int id, Shop shop)
        {
            try
            {
                var check = ShopDAO.Instance.GetShopByID(id);
                if (check == null)
                {
                    throw new Exception("Shop Id not found!!!");
                }
                ShopDAO.Instance.Update(shop);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
