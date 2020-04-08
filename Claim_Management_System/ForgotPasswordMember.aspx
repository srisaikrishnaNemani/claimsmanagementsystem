<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPasswordMember.aspx.cs" Inherits="Claim_Management_System.ForgotPasswordMember" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="user_login">
        <h1 class="login_head">Forget Password</h1>

        <br />
        <table style="width: 342px; margin: auto; margin-top: 30px; height: 246px">
            <tr style="width: 336px">
                <td style="width: 336px">Email Id :
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtEmailId" runat="server" TextMode="Email"></asp:TextBox>
                </td>

            </tr>
            <tr style="width: 336px">
                <td colspan="2" style="width: 336px">Security Question...!

                </td>
            </tr>
            <tr style="width: 336px">

                <td style="width: 336px">Birth City :
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 336px">
                <td style="width: 336px">Favorite Person:
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtFavPerson" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 336px">
                <td style="width: 336px">Password :
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 336px">
                <td style="width: 336px">Confirm Password :
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtConfPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 336px">
                <td style="width: 336px; height: 52px;"></td>
                <td style="width: 336px; height: 52px;">
                    <asp:Button ID="btnSubmit" Style="float: right" CssClass="login_button" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
