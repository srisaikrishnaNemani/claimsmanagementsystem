using System.Collections.Generic;
using Claim_Management_Model;

namespace Claim_Management_Dao
{
    public interface IClaimDao
    {
        int ApproveClaim(int claimId, string claimStatus, long approvedAmount);
        int RequestClaim(Claim claim);
        int ResubmitClaim(int claimId);
        List<Claim> ViewClaimForAdmin();
        List<Claim> ViewClaimForCustomer(int memberId);
        Claim ViewClaimById(int claimId);
    }
}
