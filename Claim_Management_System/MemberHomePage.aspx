<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="MemberHomePage.aspx.cs" Inherits="Claim_Management_System.MemberHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="admin_content">
        <asp:Button ID="Button1" CssClass="option" runat="server" Text="Request Claim" CausesValidation="false" OnClick="Button1_Click1" />

        <asp:Button ID="Button2" CssClass="option" runat="server" Text="Join Claim" CausesValidation="false" OnClick="Button2_Click" />

        <asp:Button ID="Button3" CssClass="option" runat="server" Text="Track Claims" CausesValidation="false" OnClick="Button3_Click1" />
    </div>
</asp:Content>
