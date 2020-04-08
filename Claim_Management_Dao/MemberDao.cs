using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Claim_Management_Model;
using System.Data;

namespace Claim_Management_Dao
{
    public class MemberDao : IMemberDao
    {
        public int RegisterMember(Member member)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_memberRegistration", connection);
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
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public int LoginMember(string emailId, string password)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_loginMember", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();
                    Member member = new Member();
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
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public List<Member> GetMemberListForAdmin()
        {
            List<Member> memberList = new List<Member>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getMemberListForAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    int count = 0;
                    while (dataReader.Read())
                    {
                        Member member = new Member();
                        member.MemberID = Convert.ToInt32(dataReader["MEMBERID"].ToString());
                        member.FirstName = dataReader["FIRSTNAME"].ToString();
                        member.Gender = dataReader["GENDER"].ToString();
                        member.DateOfBirth = DateTime.Parse(dataReader["DOB"].ToString());
                        member.Contact = long.Parse(dataReader["CONTACTNUMBER"].ToString());
                        member.EmailId = dataReader["EMAILID"].ToString();
                        member.City = dataReader["CITY"].ToString();
                        member.Active = dataReader["ACTIVE"].ToString();

                        memberList.Add(member);
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
                return memberList;
            }
        }
        public int ApproveMember(int memberId, string active)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_approveMember", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@Active", active);

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

        public List<Claim> ClaimStatus(string memberId)
        {
            List<Claim> memberPlanList = new List<Claim>();
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
                        memberPlanList.Add(claim);
                    }                   
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                if (memberPlanList.Count == 0)
                {
                    throw new NoClaimException();
                }
                else
                {
                    return memberPlanList;
                }
            }
        }
        public List<Claim> ClaimStatusRejected(string ClaimId)
        {
            List<Claim> memberPlanList = new List<Claim>();
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
                        memberPlanList.Add(claim);
                    }
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                if (memberPlanList.Count == 0)
                {
                    throw new NoClaimException();
                }
                else
                {
                    return memberPlanList;
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
                        Member member = new Member();
                        if ((dataReader["EmailID"].ToString().Equals(EmailId)) && (dataReader["FavoritePerson"].ToString().Equals(FavoritePerson)))
                        {
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@ConfirmPassword", ConfPassword);
                            result = 1;
                            break;
                        }
                    }
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
    }
}
