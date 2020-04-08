using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Claim_Management_Model;
using System.Data;


namespace Claim_Management_Dao
{
  public  class AgentDao : IAgentDao
    {

        public int RegisterAgent(Agent member)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_AgentRegistration", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Age", member.Age);
                    command.Parameters.AddWithValue("@Gender", member.Gender);
                    command.Parameters.AddWithValue("@Dob", member.DateOfBirth);
                    command.Parameters.AddWithValue("@Contact", member.Contact);
                    command.Parameters.AddWithValue("@Altcontact", member.AltContact);
                    command.Parameters.AddWithValue("@EmailId", member.EmailId);
                    command.Parameters.AddWithValue("@Password", member.Password);
                    command.Parameters.AddWithValue("@ConfirmPassword", member.ConfirmPassword);
                    command.Parameters.AddWithValue("@AddressLine1", member.AddrsLine1);
                    command.Parameters.AddWithValue("@AddressLine2", member.AddrsLine2);
                    command.Parameters.AddWithValue("@City", member.City);
                    command.Parameters.AddWithValue("@State", member.State);
                    command.Parameters.AddWithValue("@ZipCode", member.ZipCode);
                    command.Parameters.AddWithValue("@Active", member.Active);
                    command.Parameters.AddWithValue("@FavoritePerson", member.FavoritePerson);

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

        public int LoginAgent(string emailId, string password)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_loginAgent", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();
                    Agent member = new Agent();
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

        public List<Agent> GetAgentListForAdmin()
        {
            List<Agent> AgentList = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getAgentListForAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    int count = 0;
                    while (dataReader.Read())
                    {
                        Agent agent = new Agent();
                        agent.AgentID = Convert.ToInt32(dataReader["AGENTID"].ToString());
                        agent.FirstName = dataReader["FIRSTNAME"].ToString();
                        agent.Gender = dataReader["GENDER"].ToString();
                        agent.DateOfBirth = DateTime.Parse(dataReader["DOB"].ToString());
                        agent.Contact = long.Parse(dataReader["CONTACTNUMBER"].ToString());
                        agent.EmailId = dataReader["EMAILID"].ToString();
                        agent.City = dataReader["CITY"].ToString();
                        agent.Active = dataReader["ACTIVE"].ToString();

                        AgentList.Add(agent);
                        count++;
                    }
                    if (count == 0)
                    {

                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return AgentList;
            }
        }
        public int ApproveAgent(int AgentId, string active)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_approveAgent", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AgentId", AgentId);
                    command.Parameters.AddWithValue("@Active", active);

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

        public List<Claim> ClaimStatus(string memberId)
        {
            List<Claim> AgentPlanList = new List<Claim>();
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ClaimStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", memberId);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Claim claim = new Claim();
                        claim.ID = int.Parse(dataReader["ID"].ToString());
                        claim.ClaimId = int.Parse(dataReader["ClaimId"].ToString());
                        claim.PlanName = dataReader["PlanName"].ToString();
                        claim.ApprovedAmount = Convert.ToInt64(dataReader["ApprovedAmount"].ToString());
                        claim.ClaimStatus = dataReader["ClaimStatus"].ToString();
                        AgentPlanList.Add(claim);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                if (AgentPlanList.Count == 0)
                {
                    throw new NoClaimException();
                }
                else
                {
                    return AgentPlanList;
                }
            }
        }
        public List<Claim> ClaimStatusRejected(string ClaimId)
        {
            List<Claim> AgentPlanList = new List<Claim>();
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ClaimStatusRejected", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", ClaimId);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Claim claim = new Claim();
                        claim.ID = int.Parse(dataReader["ID"].ToString());
                        claim.ClaimId = int.Parse(dataReader["ClaimID"].ToString());
                        claim.PlanName = dataReader["PlanName"].ToString();
                        claim.ApprovedAmount = Convert.ToInt64(dataReader["ApprovedAmount"].ToString());
                        claim.ClaimStatus = dataReader["ClaimStatus"].ToString();
                        Claim c = new Claim();
                        AgentPlanList.Add(claim);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                if (AgentPlanList.Count == 0)
                {
                    throw new NoClaimException();
                }
                else
                {
                    return AgentPlanList;
                }
            }
        }

        public int SecurityMember(string EmailId, string FavoritePerson, string Password, string ConfPassword)
        {

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_SecurityMember", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailId", EmailId);
                    command.Parameters.AddWithValue("@FavoritePerson", FavoritePerson);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@ConfirmPassword", ConfPassword);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Agent member = new Agent();
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

    

