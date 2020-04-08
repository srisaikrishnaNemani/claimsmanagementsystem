using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Claim_Management_Model;

namespace Claim_Management_Dao
{
    class AgentPlanDao : IAgentPlanDao
    {
        public int AddAgentPlan(AgentPlan memberPlan)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_AgentPlan", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AgentId", memberPlan.AgentId);
                    command.Parameters.AddWithValue("@PlanCode", memberPlan.PlanCodeId);
                    command.Parameters.AddWithValue("@StartDate", memberPlan.StartDate);
                    command.Parameters.AddWithValue("@EndDate", memberPlan.EndDate);
                    command.Parameters.AddWithValue("@CoverageAmount", memberPlan.CoverageAmount);
                    command.Parameters.AddWithValue("@CoverageNumber", memberPlan.CoverageNumber);
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
        public List<AgentPlan> GetAgentPlan()
        {
            List<AgentPlan> AgentPlanList = new List<AgentPlan>();

            int count = 0;
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getAgentPlan", connection);

                    SqlDataReader dataReader = command.ExecuteReader();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    while (dataReader.Read())
                    {
                        AgentPlan memberPlan = new AgentPlan();

                        memberPlan.AgentPlanId = Convert.ToInt32(dataReader["AgentPlan"].ToString());
                        memberPlan.AgentId = dataReader["AgentId"].ToString();
                        memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                        memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                        memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                        memberPlan.CoverageAmount = Convert.ToInt32(dataReader["CoverageAmount"].ToString());
                        memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());

                        AgentPlanList.Add(memberPlan);
                        count++;
                    }
                    if (count == 0)
                    {
                        throw new NoMemberPlanException();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return AgentPlanList;
            }
        }

        public int GetAgentPlanId(int AgentId, int PlanId)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getAgentPlanById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AgentId", AgentId);
                    command.Parameters.AddWithValue("@PlanId", PlanId);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return Convert.ToInt32(dataReader["AgentPlanId"].ToString());
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return 0;
            }

        }
        public List<AgentPlan> GetAgentPlanForIdWhereNoClaim(string AgentId)
        {
            List<AgentPlan> AgentPlanList = new List<AgentPlan>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getAgentPlanIdNoclaim", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AgentId", AgentId);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        if (dataReader["ClaimStatus"].ToString().Equals("processing"))
                        {
                            AgentPlan memberPlan = new AgentPlan();
                            memberPlan.AgentId = dataReader["AgentId"].ToString();
                            memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                            memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                            memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                            memberPlan.CoverageAmount = Convert.ToInt32(dataReader["CoverageAmount"].ToString());
                            memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());
                            memberPlan.PlanName = dataReader["PlanName"].ToString();
                            memberPlan.PlanDescription = dataReader["PlanDescription"].ToString();

                            AgentPlanList.Add(memberPlan);
                        }
                    }
                    if (AgentPlanList.Count == 0)
                    {
                        throw new NoMemberPlanException();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return AgentPlanList;
            }
        }
        public List<AgentPlan> GetAgentPlanForId(string AgentId)
        {
            List<AgentPlan> AgentPlanList = new List<AgentPlan>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_GetAgentPlanForId", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AgentId", AgentId);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        AgentPlan memberPlan = new AgentPlan();
                        memberPlan.AgentPlanId = Convert.ToInt32(dataReader["AgentPlanId"].ToString());
                        memberPlan.AgentId = dataReader["AgentId"].ToString();
                        memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                        memberPlan.PlanName = dataReader["PlanName"].ToString();
                        memberPlan.PlanDescription = dataReader["PlanDescription"].ToString();
                        memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                        memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                        memberPlan.CoverageAmount = long.Parse(dataReader["CoverageAmount"].ToString());
                        memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());

                        AgentPlanList.Add(memberPlan);
                    }
                    if (AgentPlanList.Count == 0)
                    {
                        throw new NoMemberPlanException();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return AgentPlanList;
            }
        }
    }
}

