using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Users
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
        public Users ()
        {
            this.ID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permitions = 0;
            this.isActive = false;
            Mode = enMode.Addnew;
        }
        private Users(int ID, string userName, string password,byte permitions, bool IsActive)
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
        public static Users GetUserByID(int ID)
        {
            string userName = ""; string password = "";  byte permitions = 0; bool IsActive = false;
            bool isFound = DataUsers.GetUserByID(ID,ref userName, ref password, ref permitions, ref IsActive);
            if (isFound)
                return new Users(ID, userName, password, permitions, IsActive);
            else
                return null;
        }
        public static Users GetUserNamewithPassword(string UserName,string Password)
        {
            int ID = -1; byte permitions = 0; bool isActive = false; string storedHash = null;
            bool isFound = DataUsers.GetUserByUserNameandPassword(ref ID, UserName, ref storedHash, ref permitions, ref isActive);
            byte savehistory = DataUsers.AddLogos(ID, DateTime.Now);
            //if (isFound && savehistory >= 0)
            //    return new clsUsers(ID, UserName, Password, permitions, isActive);
            //else
            //    return null;
            if (!isFound)
                return null;
            // Verify plaintext password against hash
            bool verified = BCrypt.Net.BCrypt.Verify(Password, storedHash);

            if (!verified)
                return null;
            if (savehistory < 0)
                return null;

            return new Users(ID, UserName, Password, permitions, isActive);
        }
        public bool Addnewuser()
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(this.Password);
            this.ID = DataUsers.AddNewUser(this.UserName, hashedPassword, (byte)this.Permitions, this.isActive);
            return (this.ID != -1);
        }
        public bool UpdateUser()
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(this.Password);
            return DataUsers.UpdateUser(this.ID, this.UserName, hashedPassword, (byte)this.Permitions, this.isActive);
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
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            return DataUsers.ChangePassword(this.ID, hashedPassword);
        }
        public static bool ChangepasswordAnyone(int ID, string Password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            return DataUsers.ChangePassword(ID, hashedPassword);
        }
    }
}
