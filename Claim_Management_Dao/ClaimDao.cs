using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Claim_Management_Model;


namespace Claim_Management_Dao
{
    public class ClaimDao : IClaimDao
    {
        public int ApproveClaim(int claimId, string claimStatus, long approvedAmount)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ApproveClaim", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ClaimId", claimId);
                    command.Parameters.AddWithValue("@ClaimStatus", claimStatus);
                    command.Parameters.AddWithValue("@ApproveAmount", approvedAmount);

                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }catch (Exception)
                {

                }finally { connection.Close(); }
                return result;
            }
            
        }
        public int RequestClaim(Claim claim)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {

                int result = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_RequestClaim", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ClaimId", claim.ClaimId);
                    command.Parameters.AddWithValue("@PlanName", claim.PlanName);
                    command.Parameters.AddWithValue("@MemberPlanId", claim.MemberId);
                    command.Parameters.AddWithValue("@ClaimServiceDate", claim.ClaimServiceDate);
                    command.Parameters.AddWithValue("@ClaimProcessingDate", claim.ClaimProcessingDate);
                    command.Parameters.AddWithValue("@ClaimSubmissionDate", claim.ClaimSubmissionDate);
                    command.Parameters.AddWithValue("@ClaimStatus", claim.ClaimStatus);
                    command.Parameters.AddWithValue("@ClaimAmount", claim.ClaimAmount);
                    command.Parameters.AddWithValue("@ApproveAmount", claim.ApprovedAmount);

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

        public int ResubmitClaim(int claimId)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                int result=0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ResubmitClaim", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@claimId", claimId);

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

        public List<Claim> ViewClaimForAdmin()
        {
            List<Claim> claimList = new List<Claim>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ViewClaimForAdmin", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Claim claim = new Claim();
                        claim.ID = int.Parse(dataReader["ID"].ToString());
                        claim.Member_Id = dataReader["MemberPlanId"].ToString();
                        claim.PlanName = dataReader["PlanName"].ToString();
                        claim.ClaimId = int.Parse(dataReader["ClaimId"].ToString());
                        claim.ClaimServiceDate = Convert.ToDateTime(dataReader["ClaimServiceDate"].ToString());
                        claim.ClaimProcessingDate = Convert.ToDateTime(dataReader["ClaimProcessingDate"].ToString());
                        claim.ClaimSubmissionDate = Convert.ToDateTime(dataReader["ClaimSubmissionDate"].ToString());
                        claim.ClaimAmount = Convert.ToInt64(dataReader["ClaimAmount"]);
                        claimList.Add(claim);
                    }
                    if (claimList.Count == 0)
                    {
                        throw new NoClaimException();
                    }
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return claimList;
            }
        }
        public List<Claim> ViewClaimForCustomer(int memberId)
        {
            List<Claim> claimList = new List<Claim>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ViewClaimForCustomer", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@memberId", memberId);

                    SqlDataReader dataReader = command.ExecuteReader();
                    int count = 0;
                    while (dataReader.Read())
                    {
                        Claim claim = new Claim();

                        claim.ClaimId = Convert.ToInt32(dataReader["ClaimId"].ToString());
                        claim.MemberId = dataReader["MemberId"].ToString();
                        claim.ClaimServiceDate = DateTime.Parse(dataReader["ClaimServiceDate"].ToString());
                        claim.ClaimProcessingDate = DateTime.Parse(dataReader["ClaimProcessingDate"].ToString());
                        claim.ClaimSubmissionDate = DateTime.Parse(dataReader["ClaimSubmissionDate"].ToString());
                        claim.ClaimStatus = dataReader["ClaimStatus"].ToString();
                        claim.ClaimAmount = Convert.ToInt32(dataReader["ClaimAmount"].ToString());
                        claim.ApprovedAmount = Convert.ToInt32(dataReader["ApprovedAmount"].ToString());

                        claimList.Add(claim);
                        count++;
                    }
                    if (count == 0)
                    {
                        throw new NoClaimException();
                    }
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return claimList;
            }
        }

        public Claim ViewClaimById(int claimId)
        {
            List<Claim> claimList = new List<Claim>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                Claim claim = new Claim();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ViewClaimById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClaimId", claimId);
                    SqlDataReader dataReader = command.ExecuteReader();

                    
                    while (dataReader.Read())
                    {
                        claim.ClaimId = Convert.ToInt32(dataReader["ClaimId"].ToString());
                        claim.PlanName = dataReader["PlanName"].ToString();
                        claim.ClaimServiceDate = DateTime.Parse(dataReader["ClaimServiceDate"].ToString());
                        claim.ClaimProcessingDate = DateTime.Parse(dataReader["ClaimProcessingDate"].ToString());
                        claim.ClaimSubmissionDate = DateTime.Parse(dataReader["ClaimSubmissionDate"].ToString());
                        claim.ClaimAmount = Convert.ToInt32(dataReader["ClaimAmount"].ToString());
                        claim.ApprovedAmount = Convert.ToInt64(dataReader["ApprovedAmount"].ToString());
                    }
                    command.Dispose();
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
                return claim;
            }
        }
        public void Documents(DocUpload doc)
        {
            DocUpload documen = new DocUpload();
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_doc_upload", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@reasonClaim", doc.ReasonForClaiming);
                    command.Parameters.AddWithValue("@idProof", doc.IDProof);
                    command.Parameters.AddWithValue("@requiredDocument", doc.RequiredDocuments);
                    command.Parameters.AddWithValue("@bankAccountNumber", doc.AccountNumber);
                    command.Parameters.AddWithValue("@bankIfscCode", doc.IFSCCode);
                    command.Parameters.AddWithValue("@banAccountName", doc.AccountHolder);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }catch (Exception)
                {

                }finally
                {
                    connection.Close();
                }
            }
        }
    }
}
