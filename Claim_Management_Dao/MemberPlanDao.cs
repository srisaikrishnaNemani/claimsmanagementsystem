using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Claim_Management_Model;

namespace Claim_Management_Dao
{
    public class MemberPlanDao : IMemberPlanDao
    {
        public int AddMemberPlan(MemberPlan memberPlan)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_MemberPlan", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberId", memberPlan.MemberId);
                    command.Parameters.AddWithValue("@PlanCode", memberPlan.PlanCodeId);
                    command.Parameters.AddWithValue("@StartDate", memberPlan.StartDate);
                    command.Parameters.AddWithValue("@EndDate", memberPlan.EndDate);
                    command.Parameters.AddWithValue("@CoverageAmount", memberPlan.CoverageAmount);
                    command.Parameters.AddWithValue("@CoverageNumber", memberPlan.CoverageNumber);
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
        public List<MemberPlan> GetMemberPlan()
        {
            List<MemberPlan> memberPlanList = new List<MemberPlan>();

            int count = 0;
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getMemberPlan", connection);

                    SqlDataReader dataReader = command.ExecuteReader();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    while (dataReader.Read())
                    {
                        MemberPlan memberPlan = new MemberPlan();

                        memberPlan.MemberPlanId = Convert.ToInt32(dataReader["MemberPlan"].ToString());
                        memberPlan.MemberId = dataReader["MemberId"].ToString();
                        memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                        memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                        memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                        memberPlan.CoverageAmount = Convert.ToInt32(dataReader["CoverageAmount"].ToString());
                        memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());

                        memberPlanList.Add(memberPlan);
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
                return memberPlanList;
            }
        }

        public int GetMemberPlanId(int memberId, int PlanId)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getMemberPlanById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@memberId", memberId);
                    command.Parameters.AddWithValue("@PlanId", PlanId);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return Convert.ToInt32(dataReader["MemberPlanId"].ToString());
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
        public List<MemberPlan> GetMemberPlanForIdWhereNoClaim(string memberId)
        {
            List<MemberPlan> memberPlanList = new List<MemberPlan>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getMemberPlanIdNoclaim", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MemberId", memberId);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        if (dataReader["ClaimStatus"].ToString().Equals("processing"))
                        {
                            MemberPlan memberPlan = new MemberPlan();
                            memberPlan.MemberId = dataReader["MemberId"].ToString();
                            memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                            memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                            memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                            memberPlan.CoverageAmount = Convert.ToInt32(dataReader["CoverageAmount"].ToString());
                            memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());
                            memberPlan.PlanName = dataReader["PlanName"].ToString();
                            memberPlan.PlanDescription = dataReader["PlanDescription"].ToString();

                            memberPlanList.Add(memberPlan);
                        }
                    }
                    if (memberPlanList.Count == 0)
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
                return memberPlanList;
            }
        }
        public List<MemberPlan> GetMemberPlanForId(string memberId)
        {
            List<MemberPlan> memberPlanList = new List<MemberPlan>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_GetMemberPlanForId", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@memberId", memberId);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        MemberPlan memberPlan = new MemberPlan();
                        memberPlan.MemberPlanId = Convert.ToInt32(dataReader["MemberPlanId"].ToString());
                        memberPlan.MemberId = dataReader["MemberId"].ToString();
                        memberPlan.PlanCodeId = Convert.ToInt32(dataReader["PlanCodeId"].ToString());
                        memberPlan.PlanName = dataReader["PlanName"].ToString();
                        memberPlan.PlanDescription = dataReader["PlanDescription"].ToString();
                        memberPlan.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                        memberPlan.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                        memberPlan.CoverageAmount = long.Parse(dataReader["CoverageAmount"].ToString());
                        memberPlan.CoverageNumber = Convert.ToInt32(dataReader["CoverageNumber"].ToString());

                        memberPlanList.Add(memberPlan);
                    }
                    if (memberPlanList.Count == 0)
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
                return memberPlanList;
            }
        }
    }
}
