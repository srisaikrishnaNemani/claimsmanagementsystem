<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="ClaimApproval.aspx.cs" Inherits="Claim_Management_System.ClaimApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        td {
            font-size: 20px;
        }

        .auto-style1 {
            height: 26px;
        }

        .auto-style2 {
            height: 32px;
        }
    </style>
    <table class="slide_show" style="text-align: left">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 35px" colspan="2"><strong>Claim Approval</strong></td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 485px;">MemberName</td>
            <td>
                <asp:Label ID="lblMemberName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 485px;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Plan Name</td>
            <td>
                <asp:Label ID="lblPlanName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Claim Service Date</td>
            <td>
                <asp:Label ID="lblClaimServiceDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Claim Submission Date</td>
            <td>
                <asp:Label ID="lblClaimSubmissionDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Claim Amount</td>
            <td>
                <asp:Label ID="lblClaimAmount" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtAmounApprove" runat="server" Height="22px" Width="167px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:RegularExpressionValidator ID="regApprove" runat="server" ControlToValidate="txtAmounApprove" ErrorMessage="*Should be a number" Visible="false" ForeColor="Red" ValidationExpression="[0-9]{1,10}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmounApprove" ErrorMessage="*Data is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnApprove" runat="server" CssClass="approve_button" Text="Approve" OnClick="btnApprove_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReject" runat="server" CssClass="reject_button" Text="Reject" OnClick="btnReject_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
