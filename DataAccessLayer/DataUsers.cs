using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataUsers
    {
        public static DataTable GetAllUsers()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Select * From Users_View;", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return Dt;
            }
        }
        public static DataTable GetAllLoginHistory()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Select * From LogsView;", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return Dt;
            }
        }
        public static bool GetUserByID(int ID, ref string username, ref string password, ref byte Permition,ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                var UserNameParam = new SqlParameter("@UserName", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                var PasswordParam = new SqlParameter("@Password", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                var PermitionParam = new SqlParameter("@Permissions", SqlDbType.TinyInt) { Direction = ParameterDirection.Output };
                var IsActiveParam = new SqlParameter("@isActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(UserNameParam);
                command.Parameters.Add(PasswordParam);
                command.Parameters.Add(PermitionParam);
                command.Parameters.Add(IsActiveParam);
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (UserNameParam.Value != DBNull.Value) username = UserNameParam.Value.ToString();
                    if (PasswordParam.Value != DBNull.Value) password = PasswordParam.Value.ToString();
                    if (PermitionParam.Value != DBNull.Value) Permition = Convert.ToByte(PermitionParam.Value);
                    if (IsActiveParam.Value != DBNull.Value) IsActive = Convert.ToBoolean(IsActiveParam.Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static bool GetUserByUserNameandPassword(ref int ID, string username, ref string storedHash, ref byte Permition, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_GetUserByUserNameAndPassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", username);

                var IDParam = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var PasswordParam = new SqlParameter("@Password", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                var PermitionParam = new SqlParameter("@Permition", SqlDbType.TinyInt) { Direction = ParameterDirection.Output };
                var IsActiveParam = new SqlParameter("@isActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                command.Parameters.Add(IDParam);
                command.Parameters.Add(PasswordParam);
                command.Parameters.Add(PermitionParam);
                command.Parameters.Add(IsActiveParam);
                command.Parameters.Add(IsFoundParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (IDParam.Value != DBNull.Value) ID = (int)IDParam.Value;
                    if (PasswordParam.Value != DBNull.Value) storedHash = (string)PasswordParam.Value;
                    if (PermitionParam.Value != DBNull.Value) Permition = Convert.ToByte(PermitionParam.Value);
                    if (IsActiveParam.Value != DBNull.Value) IsActive = Convert.ToBoolean(IsActiveParam.Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        //public static bool GetUserByUserNameandPassword(ref int ID, string username, ref string password, ref byte Permition,ref bool IsActive)
        //{
        //    bool isFound = false;
        //    using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
        //    using (SqlCommand command = new SqlCommand("Sp_GetUserByUserNameAndPassword", connection))
        //    {
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@UserName", username);
        //        var IDParam = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
        //        var Passwordparam = new SqlParameter("@Password", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
        //        var PermitionParam = new SqlParameter("@Permition", SqlDbType.TinyInt) { Direction = ParameterDirection.Output };
        //        var IsActiveParam = new SqlParameter("@isActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
        //        var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
        //        command.Parameters.Add(IDParam);
        //        command.Parameters.Add(Passwordparam);
        //        command.Parameters.Add(PermitionParam);
        //        command.Parameters.Add(IsActiveParam);
        //        command.Parameters.Add(IsFoundParam);
        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            if (IDParam.Value != DBNull.Value) ID = (int)IDParam.Value;
        //            if (Passwordparam.Value != DBNull.Value) password = (string)Passwordparam.Value;
        //            if (IsActiveParam.Value != DBNull.Value) IsActive = Convert.ToBoolean(IsActiveParam.Value);
        //            if (PermitionParam.Value != DBNull.Value) Permition = Convert.ToByte(PermitionParam.Value);
        //            isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
        //        }
        //        catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
        //        finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        //        return isFound;
        //    }
        //}
        public static int AddNewUser(string username, string password, byte Permition, bool IsActive)
        {
            int? UserID = null;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_AddNewUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Permissions", Permition);
                command.Parameters.AddWithValue("@isActive", IsActive);
                SqlParameter outputparameter = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    UserID = (int)command.Parameters["@NewID"].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }// Error 
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return UserID ?? -1;
        }
        public static bool UpdateUser(int ID, string username, string password, byte Permition, bool IsActive)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Permissions", Permition);
                command.Parameters.AddWithValue("@isActive", IsActive);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
        public static bool DeleteUser(int ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", ID);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
        public static bool ChangePassword(int ID, string password)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_ChangePassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Password", password);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
        public static byte AddLogos(int User_ID, DateTime Datelog)
        {
            byte? LogsID = null;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_AddNewLogs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", User_ID);
                command.Parameters.AddWithValue("@DateLog", Datelog);
                SqlParameter outputparameter = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    LogsID = (byte)command.Parameters["@NewID"].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return LogsID ?? 0;
        }
    }
}
