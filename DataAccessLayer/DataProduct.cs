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
    public class DataProduct
    {
        public static DataTable GetAllProduct()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Select * From Products_View;", connection))
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
        public static bool getProductByID(int ID, ref string Name ,ref int Price, ref int Quantity, ref int Supplier_ID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("SP_GetProductByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID",ID);
                var NameParam = new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                var PriceParam = new SqlParameter("@Price", SqlDbType.SmallMoney) { Direction = ParameterDirection.Output };
                var QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var SupplierIDParam = new SqlParameter("@Supplier_ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(NameParam);
                command.Parameters.Add(PriceParam);
                command.Parameters.Add(QuantityParam);
                command.Parameters.Add(SupplierIDParam);
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (NameParam.Value != DBNull.Value) Name = NameParam.Value.ToString();
                    if (PriceParam.Value != DBNull.Value ) Price = Convert.ToInt32(PriceParam.Value);
                    if (QuantityParam.Value != DBNull.Value) Quantity = Convert.ToInt32(QuantityParam.Value);
                    if (SupplierIDParam.Value != DBNull.Value) Supplier_ID = Convert.ToInt32(SupplierIDParam.Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static bool getProductByName(ref int ID,  string Name, ref int Price, ref int Quantity, ref int Supplier_ID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_GetProductByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", Name);
                var IDParam = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var PriceParam = new SqlParameter("@Price", SqlDbType.SmallMoney) { Direction = ParameterDirection.Output };
                var QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var SupplierIDParam = new SqlParameter("@Supplier_ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(IDParam);
                command.Parameters.Add(PriceParam);
                command.Parameters.Add(QuantityParam);
                command.Parameters.Add(SupplierIDParam);
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (IDParam.Value != DBNull.Value) ID = Convert.ToInt32(IDParam.Value);
                    if (PriceParam.Value != DBNull.Value) Price = Convert.ToInt32(PriceParam.Value);
                    if (QuantityParam.Value != DBNull.Value) Quantity = Convert.ToInt32(QuantityParam.Value);
                    if (SupplierIDParam.Value != DBNull.Value) Supplier_ID = Convert.ToInt32(SupplierIDParam.Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static int AddNewProduct(string Name, int Price, int Quantity, int Supplier_ID)
        {
            int? NewID = null;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using(SqlCommand command = new SqlCommand("Sp_AddNewProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
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
        public static bool UpdateProduct(int ID, string Name, int Price, int Quantity, int Supplier_ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_UpdateProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
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
        public static bool DeleteProduct(int ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_DeleteProduct", connection))
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
        public static int GetTotalProducts()
        {
            int TotalProducts = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("GetTotalProducts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var TotalLowProductsParam = new SqlParameter("@totalProducts", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(TotalLowProductsParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (TotalLowProductsParam.Value != DBNull.Value) TotalProducts = Convert.ToInt32(TotalLowProductsParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); TotalProducts = 0; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return TotalProducts;
            }
        }
        public static int GetTotalLowProducts()
        {
            int TotalLowProducts = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("GetLowQuantityProducts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var TotalLowProductsParam = new SqlParameter("@LowQuantityProducts", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(TotalLowProductsParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (TotalLowProductsParam.Value != DBNull.Value) TotalLowProducts = Convert.ToInt32(TotalLowProductsParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); TotalLowProducts = 0; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return TotalLowProducts;
            }
        }
    }
}
