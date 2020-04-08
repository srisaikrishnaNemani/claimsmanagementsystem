<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="Claim.aspx.cs" Inherits="Claim_Management_System.Claim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p class="page-heading">
        <strong><span style="font-size: 50px">Claim</span></strong>&nbsp;
    </p>
    <table class="slide_show" style="text-align: left">
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Policy Name </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblClaimPolicyName" runat="server" Text="."></asp:Label>
                &nbsp;
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px"></td>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; height: 23px;"></td>
            <td style="height: 23px"></td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Reason for claiming</td>
            <td></td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="txtReason" runat="server" Height="42px" Width="158px" CssClass="text-style"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BorderStyle="None" ControlToValidate="txtReason" ErrorMessage="*Reason is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Id Proof </td>
            <td></td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" BorderStyle="None" ControlToValidate="FileUpload1" ErrorMessage="*Id Proof is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif"></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Required Document 
                <br />
                (FIR,Inquest Report,Driving License,CSR etc)</td>
            <td></td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" BorderStyle="None" ControlToValidate="FileUpload2" ErrorMessage="*Document is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Bank Account Number</td>
            <td></td>
            <td>
                <asp:TextBox ID="txtAcNo" runat="server" CssClass="text-style"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BorderStyle="None" ControlToValidate="txtAcNo" ErrorMessage="*Account Number is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Bank<strong><em> </em></strong>IFSC Code</td>
            <td></td>
            <td>
                <asp:TextBox ID="txtIfsc" runat="server" CssClass="text-style"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BorderStyle="None" ControlToValidate="txtIfsc" ErrorMessage="*Bank IFSC is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">Account Holder Name</td>
            <td></td>
            <td>
                <asp:TextBox ID="txtAcName" runat="server" CssClass="text-style"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" BorderStyle="None" ControlToValidate="txtAcName" ErrorMessage="*Account Holder Name is mandatory" ForeColor="Red" ValidationGroup="SubmitClaim"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnRequestClaim" runat="server" class="button" Text="Submit Claim" ValidationGroup="SubmitClaim" OnClick="btnRequestClaim_Click" />
                <asp:Label ID="lblMsgUpload" runat="server" ForeColor="Red" Text=""></asp:Label>

            </td>
            
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
