using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Products
    {
        public enum enMode { AddNew =  0, Update = 1 }
        public int ID { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public int Quantity { get; set; }
        public int Supplier_ID { get; set; }
        public Supplier supplierInfo;
        public enMode Mode;
        public Products()
        {
            this.ID = -1;
            this.Name = string.Empty;
            this.price = 0;
            this.Quantity = 0;
            this.Supplier_ID = 0;
            Mode = enMode.AddNew;
        }
        private Products(int ID, string Name, int Price, int quantity, int Supplier_ID)
        {
            this.ID = ID;
            this.Name = Name;
            this.price = Price;
            this.Quantity = quantity;
            this.Supplier_ID = Supplier_ID;
            supplierInfo = Supplier.GetSupplierByID(this.Supplier_ID);
            Mode = enMode.Update;
        }
        public static DataTable GetAllProduct()
        {
            return DataProduct.GetAllProduct();
        }
        public static int GetTotalProduct()
        {
            return DataProduct.GetTotalProducts();
        }
        public static int GetTotalLowProduct()
        {
            return DataProduct.GetTotalLowProducts();
        }
        public static Products GetProductByID(int ID)
        {
            string Name = ""; int Price = -1; int quantity = -1; int Supplier_ID = -1;
            bool isFound = DataProduct.getProductByID(ID, ref Name, ref Price, ref quantity, ref Supplier_ID);
            if (isFound)
                return new Products(ID, Name, Price, quantity, Supplier_ID);
            else
                return null;
        }
        public static Products GetProductByName(string Name)
        {
            int ID = -1; int Price = -1; int quantity = -1; int Supplier_ID = -1;
            bool isFound = DataProduct.getProductByName(ref ID, Name, ref Price, ref quantity, ref Supplier_ID);
            if (isFound)
                return new Products(ID, Name, Price, quantity, Supplier_ID);
            else
                return null;
        }
        private bool AddNewProduct()
        {
            this.ID = DataProduct.AddNewProduct(this.Name, this.price, this.Quantity, this.Supplier_ID);
            return (this.ID != -1);
        }
        private bool UpdateProduct()
        {
            return DataProduct.UpdateProduct(this.ID, this.Name, this.price, this.Quantity, this.Supplier_ID);
        }
        public bool DeleteProduct()
        {
            return DataProduct.DeleteProduct(this.ID);
        }
        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew:
                    {
                        return AddNewProduct();
                    }
                case enMode.Update:
                    {
                        return UpdateProduct();
                    }
                default:
                    return false;
            }
        }
    }
}
