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
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks();
        Stock GetStockById(int id);
        void InsertStock(Stock stock);
        void DeleteStock(int Id);
        void UpdateStock(int id, Stock stock);
    }
    public class StockService : IStockService
    {
        public void DeleteStock(int Id)
        {
            try
            {
                var check = StockDAO.Instance.GetStockByID(Id);

                if (check == null)
                {
                    throw new Exception("Stock Id not found!!!");
                }

                StockDAO.Instance.Remove(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Stock GetStockById(int id)
        {
            try
            {
                var result = StockDAO.Instance.GetStockByID(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Stock> GetStocks()
        {
            try
            {
                var result = StockDAO.Instance.GetStocks();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertStock(Stock stock)
        {
            try
            {
                var checkCode = StockDAO.Instance.GetStockByCode(stock.Code);
                if (checkCode != null)
                {
                    throw new Exception("Stock already exist!!!");
                }

                StockDAO.Instance.AddNew(stock);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateStock(int id, Stock stock)
        {
            try
            {
                var check = StockDAO.Instance.GetStockByID(id);
                if (check == null)
                {
                    throw new Exception("Product Id not found!!!");
                }
                StockDAO.Instance.Update(stock);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
