using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Claim_Management_Model;

namespace Claim_Management_Dao
{
    public class AdminDao : IAdminDao
    {
        public int RegisterAdmin(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_adminRegistration", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", admin.FirstName);
                    command.Parameters.AddWithValue("@LastName", admin.LastName);
                    command.Parameters.AddWithValue("@Age", admin.Age);
                    command.Parameters.AddWithValue("@Gender", admin.Gender);
                    command.Parameters.AddWithValue("@Dob", admin.DateOfBirth);
                    command.Parameters.AddWithValue("@Contact", admin.Contact);
                    command.Parameters.AddWithValue("@Altcontact", admin.AltContact);
                    command.Parameters.AddWithValue("@EmailId", admin.EmailId);
                    command.Parameters.AddWithValue("@Password", admin.Password);
                    command.Parameters.AddWithValue("@ConfirmPassword", admin.ConfirmPassword);
                    command.Parameters.AddWithValue("@Active", admin.Active);
                    command.Parameters.AddWithValue("@FavoritePerson", admin.Favoriteperson);
                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }
        public int LoginAdmin(string emailId, string password)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_loginAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    Admin admin = new Admin();
                    while (dataReader.Read())
                    {
                        if ((dataReader["EMAILID"].ToString() == emailId) && (dataReader["PASSWORD"].ToString() == password) && (dataReader["ACTIVE"].ToString() == "Yes"))
                        {
                            result = 1;//credentails correct;active=yes
                            break;
                        }
                        else if ((dataReader["EMAILID"].ToString() == emailId) && (dataReader["PASSWORD"].ToString() == password) && (dataReader["ACTIVE"].ToString() == "No"))
                        {
                            result = 2;//credentails correct;active=no/rejected
                            break;
                        }
                        else if ((dataReader["EMAILID"].ToString() == emailId) && (dataReader["PASSWORD"].ToString() == password) && (dataReader["ACTIVE"].ToString() == "Processing"))
                        {
                            result = 3;//credentails correct;active=processing
                            break;
                        }
                        else
                        {
                            result = 0;//credentails wrong
                        }
                    }
                    command.Dispose();
                }
                catch (Exception) { }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }
        public List<Admin> GetAdminListForSuperUser()
        {
            List<Admin> adminList = new List<Admin>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getAdminListForSuperUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    int count = 0;
                    while (dataReader.Read())
                    {
                        Admin admin = new Admin();
                        admin.AdminId = Convert.ToInt32(dataReader["ADMINID"].ToString());
                        admin.FirstName = dataReader["FIRSTNAME"].ToString();
                        admin.LastName = dataReader["LASTNAME"].ToString();
                        admin.Age = Convert.ToInt32(dataReader["AGE"].ToString());
                        admin.Gender = dataReader["GENDER"].ToString();

                        adminList.Add(admin);
                        count++;
                    }
                    if (count == 0)
                    {
                        throw new NoAdminException();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return adminList;
            }
        }

        public int ApproveAdmin(int adminId, string active)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_approveAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AdminId", adminId);
                    command.Parameters.AddWithValue("@Active", active);
                    result = command.ExecuteNonQuery();
                    command.Dispose();
                    return result;
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }
        public int SecurityAdmin(string EmailId, string FavoritePerson, string Password, string ConfPassword)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_SecurityAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailId", EmailId);
                    command.Parameters.AddWithValue("@FavoritePerson", FavoritePerson);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@ConfirmPassword", ConfPassword);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Admin admin = new Admin();
                        if ((dataReader["EmailID"].ToString().Equals(EmailId)) && (dataReader["FavoritePerson"].ToString().Equals(FavoritePerson)))
                        {
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@ConfirmPassword", ConfPassword);
                            result = 1;
                            break;
                        }
                    }
                    command.Dispose();
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }
    }
}