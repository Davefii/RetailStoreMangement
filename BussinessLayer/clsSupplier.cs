using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsSupplier
    {
        public enum enMode { AddNew = 0, Update = 1}
        public int ID {  get; set; }
        public string Supplier_Name { get; set; }
        public string Contact_Person { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public enMode Mode;
        public clsSupplier()
        {
            this.ID = -1;
            this.Supplier_Name = string.Empty;
            this.Contact_Person = string.Empty;
            this.Phone_Number = string.Empty;
            this.Address = string.Empty;
            this.Email = string.Empty;
            this.Status = false;
            this.Mode = enMode.AddNew;
        }
        private clsSupplier(int ID,string SupplierName, string ContactPerson, string PhoneNumber, string Address, string Email, bool Status)
        {
            this.ID = ID;
            this.Supplier_Name = SupplierName;
            this.Contact_Person = ContactPerson;
            this.Phone_Number = PhoneNumber;
            this.Address = Address;
            this.Email = Email;
            this.Status = Status;
            this.Mode = enMode.Update;
        }
        public static int GetTotalSuppliers()
        {
            return DataSuppiers.GetTotalSuppliers();            
        }
        public static DataTable GetAllSupplier()
        {
            return DataSuppiers.GetAllSuppliers();
        }
        public static clsSupplier GetSupplierByID(int ID)
        {
             string SupplierName = "";  string ContactPerson = "";  string PhoneNumber = "";  string Address = "";  string Email = "";  bool Status = false;
            bool isFound = DataAccessLayer.DataSuppiers.GetSupplierbyID(ID, ref SupplierName, ref ContactPerson, ref Email, ref PhoneNumber, ref Address, ref Status);
            if (isFound)
                return new clsSupplier(ID, SupplierName, ContactPerson, PhoneNumber, Address, Email, Status);
            else
                return null;
        }
        public static clsSupplier GetSupplierByName(string SupplierName)
        {
            int ID = -1; string ContactPerson = ""; string PhoneNumber = ""; string Address = ""; string Email = ""; bool Status = false;
            bool isFound = DataAccessLayer.DataSuppiers.GetSupplierbyName(ref ID, SupplierName, ref ContactPerson, ref Email, ref PhoneNumber, ref Address, ref Status);
            if (isFound)
                return new clsSupplier(ID, SupplierName, ContactPerson, PhoneNumber, Address, Email, Status);
            else
                return null;
        }
        private bool AddnewSuppliuer()
        {
            this.ID = DataSuppiers.AddSupplier(this.Supplier_Name, this.Contact_Person, this.Phone_Number, this.Email, this.Address, this.Status);
            return (this.ID != -1);
        }
        private bool UpdateSuppliuer()
        {
            return DataSuppiers.UpdateSupplier(this.ID,this.Supplier_Name, this.Contact_Person, this.Phone_Number, this.Email, this.Address, this.Status);
        }
        public bool DeleteSuppliuer()
        {
            return DataSuppiers.DeleteSupplier(this.ID);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        return AddnewSuppliuer();
                    }
                case enMode.Update:
                    {
                        return UpdateSuppliuer();
                    }
                default:
                    return false;
            }
        }
    }
}
