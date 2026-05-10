using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Sales
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public int User_ID { get; set; }
        public int TotalPrice { get { Products product = Products.GetProductByID(this.Product_ID); return product.price * Quantity; } }
        public enMode Mode;
        public Supplier supplierInfo;
        public Products productinfo;
        public Users user;
        public Sales()
        {
            this.ID = -1;
            this.Product_ID = -1;
            this.Quantity = 0;
            this.SaleDate = DateTime.MinValue;
            this.User_ID = 0;
            Mode = enMode.AddNew;
        }
        private Sales(int ID,int product_ID, int quantity, DateTime SaleDate, int user_ID, int TotalPrice)
        {
            this.ID = ID;
            this.Product_ID = product_ID;
            this.Quantity = quantity;
            this.SaleDate = SaleDate;
            this.User_ID = user_ID;
            user = Users.GetUserByID(this.User_ID);
            Mode = enMode.Update;
        }
        public static int GetTotalSales()
        {
            return DataSeles.GetTotalSales();
        }
        public static DataTable GetAllSeles()
        {
            return DataSeles.GetAllSeles();
        }
        public static Sales GetSaleByID(int ID)
        {
            int product_ID = -1; int quantity = 0; DateTime SaleDate = DateTime.MinValue; int user_ID = -1; int TotalPrice = 0;
            bool isFound = DataSeles.getSaleByID(ID, ref product_ID, ref quantity, ref SaleDate, ref user_ID, ref TotalPrice);
            if (isFound)
                return new Sales(ID, product_ID, quantity, SaleDate, user_ID, TotalPrice);
            else
                return null;
        }
        private byte reducesqutityproduct(int ID, int Quantity)
        {
            return DataSeles.ReduceQuantity(ID, Quantity);
        }
        private bool AddNewSale()
        {
            byte rowaffected = reducesqutityproduct(this.Product_ID, this.Quantity);
            if (rowaffected > 0)
                this.ID = DataSeles.AddNewSale(this.Product_ID, this.Quantity, this.SaleDate, this.User_ID, this.TotalPrice);
            return (this.ID != -1);
        }
        private bool UpdateSale()
        {
            return DataSeles.UpdateSale(this.ID,this.Product_ID, this.Quantity, this.SaleDate, this.User_ID, this.TotalPrice);
        }
        public bool DeleteSale()
        {
            return DataSeles.DeleteSale(ID);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        return AddNewSale();
                    }
                case enMode.Update:
                    {
                        return UpdateSale();
                    }
                default:
                    return false;
            }
        }

    }
}
