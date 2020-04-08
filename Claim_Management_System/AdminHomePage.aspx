<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Claim_Management_System.AdminHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin_content">

        <asp:Button ID="btnApproveCustomer" CssClass="option" runat="server" Text="Approve Customer" CausesValidation="false" OnClick="btnApproveCustomer_Click"  />

        <asp:Button ID="btnApproveClaims" CssClass="option" runat="server" Text="Approve Claims" CausesValidation="false" OnClick="btnApproveClaims_Click" />

        <asp:Button ID="btnAddEdit" CssClass="option" runat="server" Text="Add/Edit Policy" CausesValidation="false" OnClick="btnAddEdit_Click"  />
    </div>
</asp:Content>
