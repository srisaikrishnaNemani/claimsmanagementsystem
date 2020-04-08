using Claim_Management_Model;
using System.Collections.Generic;

namespace Claim_Management_Dao
{
    public interface IMemberDao
    {
        int RegisterMember(Member member);
        int LoginMember(string emailId, string password);
        List<Member> GetMemberListForAdmin();
        int ApproveMember(int memberId, string active);
        List<Claim> ClaimStatus(string memberId);
        List<Claim> ClaimStatusRejected(string ClaimId);
        int SecurityMember(string EmailId, string FavoritePerson, string Password, string ConfPassword);
    }
}
