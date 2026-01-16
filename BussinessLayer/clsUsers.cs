using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsUsers
    {
        enum enMode { Addnew = 0, Update = 1 }
        [Flags]
        public enum enMainMenuPermitions
        { 
            Viewer = 1 ,
            StaffOrCashier = 2,
            Admin = 4
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public enMainMenuPermitions Permitions { get; set; }
        public bool isActive { get; set; }
        enMode Mode;
        public clsUsers ()
        {
            this.ID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permitions = 0;
            this.isActive = false;
            Mode = enMode.Addnew;
        }
        private clsUsers(int ID, string userName, string password,byte permitions, bool IsActive)
        {
            this.ID = ID;
            this.UserName = userName;
            this.Password = password;
            this.Permitions = (enMainMenuPermitions)permitions;
            this.isActive = IsActive;
            Mode = enMode.Update;
        }
        public static DataTable Getallusers()
        {
            return DataUsers.GetAllUsers();
        }
        public static DataTable GetHistoryUserlogin()
        {
            return DataUsers.GetAllLoginHistory();
        }
        public static clsUsers GetUserByID(int ID)
        {
            string userName = ""; string password = "";  byte permitions = 0; bool IsActive = false;
            bool isFound = DataUsers.GetUserByID(ID,ref userName, ref password, ref permitions, ref IsActive);
            if (isFound)
                return new clsUsers(ID, userName, password, permitions, IsActive);
            else
                return null;
        }
        public static clsUsers GetUserNamewithPassword(string UserName,string Password)
        {
            int ID = -1; byte permitions = 0; bool isActive = false;
            bool isFound = DataUsers.GetUserByUserNameandPassword(ref ID, UserName, Password, ref permitions, ref isActive);
            byte savehistory = DataUsers.AddLogos(ID, DateTime.Now);
            if (isFound && savehistory >= 0)
                return new clsUsers(ID, UserName, Password, permitions, isActive);
            else
                return null;
        }
        public bool Addnewuser()
        {
            this.ID = DataUsers.AddNewUser(this.UserName, this.Password, (byte)this.Permitions, this.isActive);
            return (this.ID != -1);
        }
        public bool UpdateUser()
        {
            return DataUsers.UpdateUser(this.ID, this.UserName, this.Password, (byte)this.Permitions, this.isActive);
        }
        public bool DeleteUser()
        {
            return DataUsers.DeleteUser(this.ID);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.Addnew:
                    {
                        return Addnewuser();
                    }
                case enMode.Update:
                    {
                        return UpdateUser();
                    }
                default:
                    return false;
            }
        }
        public bool Changepassword(string Password)
        {
            return DataUsers.ChangePassword(this.ID, Password);
        }
        public static bool ChangepasswordAnyone(int ID, string Password)
        {
            return DataUsers.ChangePassword(ID, Password);
        }
    }
}
