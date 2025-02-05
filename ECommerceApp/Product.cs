using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp
{
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public double ItemPrice { get; set; }
        public int StockAmount { get; private set; }

        public Product(int prodID, string prodName, double itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000) throw new ArgumentOutOfRangeException(nameof(prodID));
            if (itemPrice < 5 || itemPrice > 5000) throw new ArgumentOutOfRangeException(nameof(itemPrice));
            if (stockAmount < 5 || stockAmount > 500000) throw new ArgumentOutOfRangeException(nameof(stockAmount));
            
            if (string.IsNullOrEmpty(prodName)) throw new ArgumentException("Product name cannot be null or empty.", nameof(prodName));
            if (prodName.Length > 100) throw new ArgumentException("Product name cannot exceed 100 characters.", nameof(prodName));

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be positive.");
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be positive.");
            if (StockAmount - amount < 0) throw new InvalidOperationException("Not enough stock.");
            StockAmount -= amount;
        }
    }
}

