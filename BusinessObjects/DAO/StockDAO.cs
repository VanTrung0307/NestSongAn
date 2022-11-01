using DataAccessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DAO
{
    public class StockDAO
    {
        private static StockDAO instance = null;
        public static readonly object instanceLock = new object();
        private StockDAO() { }
        public static StockDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StockDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Stock> GetStocks()
        {
            List<Stock> stocks;
            try
            {
                var context = new PRN221_DBContext();
                stocks = context.Stocks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stocks;
        }

        public Stock GetStockByID(int Id)
        {
            Stock stock = null;
            try
            {
                var context = new PRN221_DBContext();
                stock = context.Stocks.SingleOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stock;
        }

        public Stock GetStockByCode(string code)
        {
            Stock stock = null;
            try
            {
                var context = new PRN221_DBContext();
                stock = context.Stocks.SingleOrDefault(x => x.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stock;
        }

        public void AddNew(Stock stock)
        {
            try
            {
                Stock _stock = GetStockByID(stock.Id);
                if (_stock == null)
                {
                    var context = new PRN221_DBContext();
                    context.Stocks.Add(stock);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Stock is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Stock stock)
        {
            try
            {
                Stock c = GetStockByID(stock.Id);
                if (c != null)
                {
                    var context = new PRN221_DBContext();
                    context.Entry<Stock>(stock).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Stock does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int stockId)
        {
            try
            {
                Stock c = GetStockByID(stockId);
                if (c != null)
                {
                    var context = new PRN221_DBContext();
                    context.Stocks.Remove(c);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Stock does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
