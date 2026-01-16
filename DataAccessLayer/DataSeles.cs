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
    public class DataSeles
    {
        public static DataTable GetAllSeles()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Select * From Sales_View;", connection))
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
            }
            return Dt;
        }
        public static int GetTotalSales()
        {
            int TotalSeles = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("GETTotalSales", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var TotalSelesParam = new SqlParameter("@TotalSeles", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(TotalSelesParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (TotalSelesParam.Value != DBNull.Value) TotalSeles = Convert.ToInt32(TotalSelesParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); TotalSeles = 0; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return TotalSeles;
            }
        }
        public static bool getSaleByID(int ID, ref int Product_ID, ref int Quantity, ref DateTime SaleDate, ref int UserID, ref int TotalPrice)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("SP_GetSaleByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                var Product_IDParam = new SqlParameter("@Product_ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var SaleDateParam = new SqlParameter("@SaleDate", SqlDbType.Date) { Direction = ParameterDirection.Output };
                var UserIDParam = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var TotalPriceParam = new SqlParameter("@TotalPrice", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(Product_IDParam);
                command.Parameters.Add(QuantityParam);
                command.Parameters.Add(SaleDateParam);
                command.Parameters.Add(UserIDParam);
                command.Parameters.Add(TotalPriceParam);
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (Product_IDParam.Value != DBNull.Value) Product_ID = Convert.ToInt32(Product_IDParam.Value);
                    if (SaleDateParam.Value != DBNull.Value) SaleDate = Convert.ToDateTime(SaleDateParam.Value);
                    if (QuantityParam.Value != DBNull.Value) Quantity = Convert.ToInt32(QuantityParam.Value);
                    if (UserIDParam.Value != DBNull.Value) UserID = Convert.ToInt32(UserIDParam.Value);
                    if (TotalPriceParam.Value != DBNull.Value) TotalPrice = Convert.ToInt32(TotalPrice);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static int AddNewSale(int Product_ID, int Quantity, DateTime SaleDate, int UserID, int TotalPrice)
        {
            int? NewID = null;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_AddNewSale", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Product_ID", Product_ID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@SaleDate", SaleDate);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                SqlParameter outputparameter = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    NewID = (int)command.Parameters["@NewID"].Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return NewID ?? -1;
            }
        }
        public static bool UpdateSale(int ID, int Product_ID, int Quantity, DateTime SaleDate, int UserID, int TotalPrice)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_UpdateSale", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Product_ID", Product_ID);
                command.Parameters.AddWithValue("@Product_ID", Product_ID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@SaleDate", SaleDate);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
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
        public static bool DeleteSale(int ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_DeleteSupplier", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
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
        public static byte ReduceQuantity(int ID, int Quantity)
        {
            byte ReturnValue = 0;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using(SqlCommand command = new SqlCommand("ReduceQuantityByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@quantity",Quantity);
                SqlParameter outputparameter = new SqlParameter("@RowsAffected", SqlDbType.TinyInt)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (command.Parameters["@RowsAffected"].Value != DBNull.Value)
                    {
                        ReturnValue = Convert.ToByte(command.Parameters["@RowsAffected"].Value);
                    }
                    
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return ReturnValue;
            }
        }
    }
}
