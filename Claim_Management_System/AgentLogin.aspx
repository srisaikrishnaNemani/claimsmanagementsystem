<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.Master"  AutoEventWireup="true" CodeBehind="AgentLogin.aspx.cs" Inherits="Claim_Management_System.Agent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div class="user_login">
            <h1 class="login_head">Agent Login</h1>

        <br />
        <table style="width: 342px; margin: auto; margin-top: 30px; height: 246px">
            <tr>
                <td style="width: 336px">
                    <asp:Label ID="lblusername" runat="server" Text="Username" CssClass="font-style"></asp:Label>
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="232px" placeholder="Username..." Height="27px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td style="width: 336px">&nbsp;</td>
                <td style="width: 336px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName Required!" Style="color: #FF0000; width: auto" ValidationGroup="AdminLoginValidation"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td style="width: 336px">
                    <asp:Label ID="lblpassword" runat="server" Text="Password" CssClass="font-style"></asp:Label>
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtPassword" runat="server" Width="234px" Height="27px" placeholder="Password..." TextMode="Password"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td style="width: 336px">&nbsp;</td>
                <td style="width: 336px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required!" Style="color: #FF0000; width: auto" ValidationGroup="AdminLoginValidation"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>

            </tr>
            <tr>

                <td>
                    <asp:Button ID="btnLogin" CssClass="login_button" runat="server" Text="login" OnClick="btnLogin_Click" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MemberRegistration.aspx" Style="color: #0066FF">New Member Register Here!</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ForgotPasswordMember.aspx" Style="color: #0066FF">Forget Password</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblAlert" runat="server" Text="."></asp:Label>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
