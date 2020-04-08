using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Claim_Management_Model;

namespace Claim_Management_Dao
{
    public class PlanCodeDao : IPlanCodeDao
    {
        public int AddPlan(PlanCode planCode)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_AddPlans", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@planname", planCode.PlanName);
                    command.Parameters.AddWithValue("@plandescription", planCode.PlanDescription);
                    command.Parameters.AddWithValue("@coverage1", planCode.Coverage1);
                    command.Parameters.AddWithValue("@coverage2", planCode.Coverage2);
                    command.Parameters.AddWithValue("@coverage3", planCode.Coverage3);
                    command.Parameters.AddWithValue("@coverage4", planCode.Coverage4);
                    command.Parameters.AddWithValue("@coverage5", planCode.Coverage5);

                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public int EditPlan(PlanCode planCode)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_EditPlan", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@plancodeid", planCode.PlanCodeId);
                    command.Parameters.AddWithValue("@planname", planCode.PlanName);
                    command.Parameters.AddWithValue("@plandescription", planCode.PlanDescription);
                    command.Parameters.AddWithValue("@coverage1", planCode.Coverage1);
                    command.Parameters.AddWithValue("@coverage2", planCode.Coverage2);
                    command.Parameters.AddWithValue("@coverage3", planCode.Coverage3);
                    command.Parameters.AddWithValue("@coverage4", planCode.Coverage4);
                    command.Parameters.AddWithValue("@coverage5", planCode.Coverage5);

                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public int RemovePlan(int planCodeId)
        {
            int result=0;
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_Removeplan", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PlanCodeId", planCodeId);

                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public List<PlanCode> ViewPlan()
        {
            List<PlanCode> planCodeList = new List<PlanCode>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ViewPlan", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();

                    int count = 0;
                    while (dataReader.Read())
                    {
                        PlanCode planCode = new PlanCode();
                        planCode.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                        planCode.PlanName = dataReader["PlanName"].ToString();
                        planCode.PlanDescription = dataReader["PlanDescription"].ToString();
                        planCode.Coverage1 = long.Parse(dataReader["Coverage1"].ToString());
                        planCode.Coverage2 = long.Parse(dataReader["Coverage2"].ToString());
                        planCode.Coverage3 = long.Parse(dataReader["Coverage3"].ToString());
                        planCode.Coverage4 = long.Parse(dataReader["Coverage4"].ToString());
                        planCode.Coverage5 = long.Parse(dataReader["Coverage5"].ToString());

                        planCodeList.Add(planCode);
                        count++;
                    }
                    if (count == 0)
                    {
                        throw new NoPlanException();
                    }
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return planCodeList;
            }
        }
    }
}
