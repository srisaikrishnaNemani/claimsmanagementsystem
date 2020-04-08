using Claim_Management_Model;
using System;
using System.Text;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class Claim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["type"] != null || Session["memberId"] != null)
                {
                    if (Session["type"].ToString() != "User")
                    {
                        Response.Write("<script>alert('Please login as user');window.location.href='Login.aspx'</script>");
                    }
                }
                lblClaimPolicyName.Text = Request.QueryString["name"].ToString();
            }
            catch (Exception)
            {

            }

        }

        protected void btnRequestClaim_Click(object sender, EventArgs e)
        {


            StringBuilder sb = new StringBuilder();

            string filePath = Server.MapPath("~") + "UploadedFiles\\";
            string filePath1, filePath2;

            if (FileUpload1.HasFile)
            {
                try
                {
                    sb.AppendFormat(" Uploading file: {0}", FileUpload1.FileName);

                    if (FileUpload1.PostedFile.ContentType.Equals("image/jpeg") || FileUpload1.PostedFile.ContentType.Equals("image/jpg") || FileUpload1.PostedFile.ContentType.Equals("application/pdf"))
                    {

                        filePath1 = filePath + FileUpload1.FileName;
                        FileUpload1.SaveAs(filePath1);
                        filePath1 = "UploadedFiles\\" + FileUpload1.FileName;
                        sb.AppendFormat("<br/> Save As: {0}", FileUpload1.PostedFile.FileName);
                        sb.AppendFormat("<br/> File type: {0}", FileUpload1.PostedFile.ContentType);
                        sb.AppendFormat("<br/> File length: {0}", FileUpload1.PostedFile.ContentLength);
                        sb.AppendFormat("<br/> File name: {0}", FileUpload1.PostedFile.FileName);
                        lblMsgUpload.Text = "Uploaded";

                        if (FileUpload2.HasFile)
                        {

                            sb.AppendFormat(" Uploading file: {0}", FileUpload1.FileName);

                            if (FileUpload2.PostedFile.ContentType.Equals("image/jpeg") || FileUpload2.PostedFile.ContentType.Equals("image/jpg") || FileUpload2.PostedFile.ContentType.Equals("application/pdf"))
                            {

                                filePath2 = filePath + FileUpload2.FileName;
                                FileUpload2.SaveAs(filePath2);
                                filePath2 = "UploadedFiles\\" + FileUpload2.FileName;
                                sb.AppendFormat("<br/> Save As: {0}", FileUpload2.PostedFile.FileName);
                                sb.AppendFormat("<br/> File type: {0}", FileUpload2.PostedFile.ContentType);
                                sb.AppendFormat("<br/> File length: {0}", FileUpload2.PostedFile.ContentLength);
                                sb.AppendFormat("<br/> File name: {0}", FileUpload2.PostedFile.FileName);
                                lblMsgUpload.Text = "Uploaded";

                                DocUpload docu = new DocUpload();
                                docu.ReasonForClaiming = txtReason.Text;
                                docu.IDProof = filePath1;
                                docu.RequiredDocuments = filePath2;
                                docu.AccountNumber = long.Parse(txtAcNo.Text);
                                docu.IFSCCode = txtIfsc.Text;
                                docu.AccountHolder = txtAcName.Text;

                                new ClaimDao().Documents(docu);

                                Response.Redirect("ClaimMain.aspx");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.Append("<br/> Error <br/>");
                    sb.AppendFormat("Unable to save file <br/> {0}", ex.Message);
                }
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveClaims.aspx");
        }
    }
}