<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="RejectionPage.aspx.cs" Inherits="Claim_Management_System.RejectionPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <p>
            <br />
        </p>
        <p>
        </p>
        <div>
            <div style="font-size: 20px">
                <p>Sorry To infrom You that your request has not been approved.These might be the reasons for the rejection.</p>
                <br />
                <br />
                <p>
                    *Not a valid user details.<br />
                </p>
                <p>
                    *improper input for the fields needed.<br />
                </p>
                <p>
                    *Entered mail id is not available.<br />
                </p>
                <p>
                    *given phone number is not authenticated.(not given any reply for the call from our company).<br />
                </p>
                <br />
            </div>
            <div>
                <p style="align-content: center">Please Register again</p>
                <p>
                    <asp:HyperLink ID="HyperLink2" runat="server" Style="text-align: center" class="approve_button" NavigateUrl="~/MemberRegistration.aspx">Click Here</asp:HyperLink>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
