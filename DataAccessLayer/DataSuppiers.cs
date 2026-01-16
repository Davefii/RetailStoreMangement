using DataAccessSettings;
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
    public class DataSuppiers
    {
        public static DataTable GetAllSuppliers()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Select * From Suppliers;", connection))
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
        public static bool GetSupplierbyID(int ID, ref string Supplier_Name, ref string Contact_Person,  ref string Email, ref string Phone_number, ref string Address, ref bool Status)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("SP_GetSupplierByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.Add(new SqlParameter("@Supplier_Name", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Contact_Person", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Phone_Number", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (command.Parameters["@Supplier_Name"].Value != DBNull.Value) Supplier_Name = command.Parameters["@Supplier_Name"].Value.ToString();
                    if (command.Parameters["@Contact_Person"].Value != DBNull.Value) Contact_Person = command.Parameters["@Contact_Person"].Value.ToString();
                    if (command.Parameters["@Phone_Number"].Value != DBNull.Value) Phone_number = command.Parameters["@Phone_Number"].Value.ToString();
                    if (command.Parameters["@Email"].Value != DBNull.Value) Email = command.Parameters["@Email"].Value.ToString();
                    if (command.Parameters["@Address"].Value != DBNull.Value) Address = command.Parameters["@Address"].Value.ToString();
                    if (command.Parameters["@Status"].Value != DBNull.Value) Status = Convert.ToBoolean(command.Parameters["@Status"].Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static bool GetSupplierbyName(ref int ID, string Supplier_Name, ref string Contact_Person, ref string Email, ref string Phone_number, ref string Address, ref bool Status)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("SP_GetSupplierByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Supplier_Name", Supplier_Name);
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Contact_Person", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Phone_Number", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                var IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                command.Parameters.Add(IsFoundParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (command.Parameters["@ID"].Value != DBNull.Value) ID = Convert.ToInt32(command.Parameters["@ID"].Value);
                    if (command.Parameters["@Contact_Person"].Value != DBNull.Value) Contact_Person = command.Parameters["@Contact_Person"].Value.ToString();
                    if (command.Parameters["@Phone_Number"].Value != DBNull.Value) Phone_number = command.Parameters["@Phone_Number"].Value.ToString();
                    if (command.Parameters["@Email"].Value != DBNull.Value) Email = command.Parameters["@Email"].Value.ToString();
                    if (command.Parameters["@Address"].Value != DBNull.Value) Address = command.Parameters["@Address"].Value.ToString();
                    if (command.Parameters["@Status"].Value != DBNull.Value) Status = Convert.ToBoolean(command.Parameters["@Status"].Value);
                    isFound = (IsFoundParam.Value != DBNull.Value) && Convert.ToBoolean(IsFoundParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static int AddSupplier(string Supplier_Name, string Contact_Person, string Phone_number, string Email, string Address, bool Status)
        {
            int? ID = null;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_AddNewSupplier", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Supplier_Name", Supplier_Name);
                command.Parameters.AddWithValue("@Contact_Person", Contact_Person);
                command.Parameters.AddWithValue("@Phone_Number", Phone_number);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Status", Status);
                SqlParameter outputparameter = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ID = (int)command.Parameters["@NewID"].Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex);  }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return ID?? -1;
            }
        }

        public static bool UpdateSupplier(int ID,string Supplier_Name, string Contact_Person, string Phone_number, string Email, string Address, bool Status)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_UpdateSupplier", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Supplier_Name", Supplier_Name);
                command.Parameters.AddWithValue("@Contact_Person", Contact_Person);
                command.Parameters.AddWithValue("@Phone_Number", Phone_number);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Status", Status);
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
        public static bool DeleteSupplier(int ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("Sp_DeleteSupplier", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID",ID);
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
        public static int GetTotalSuppliers()
        {
            int TotalSupplier = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.ConnictionString))
            using (SqlCommand command = new SqlCommand("GetTotalSuppliers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var TotalSupplierParam = new SqlParameter("@totalSuppliers", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(TotalSupplierParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (TotalSupplierParam.Value != DBNull.Value) TotalSupplier = Convert.ToInt32(TotalSupplierParam.Value);
                }
                catch (Exception ex) { Debug.WriteLine(ex); TotalSupplier = 0; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return TotalSupplier;
            }
        }
    }
}
