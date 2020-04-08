<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="ClaimMain.aspx.cs" Inherits="Claim_Management_System.ClaimMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnMainPage" CssClass="button" runat="server" Text="Main Page" OnClick="btnMainPage_Click" />
    <asp:GridView ID="gridPolicy" runat="server" AutoGenerateColumns="False" Width="654px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gridPolicy_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Plan Id" DataField="PlanCodeId"></asp:BoundField>
            <asp:BoundField HeaderText="Plan Name" DataField="PlanName" />
            <asp:BoundField HeaderText="PlanDescription" DataField="PlanDescription" />
            <asp:BoundField HeaderText="Coverage Amount" DataField="CoverageAmount" />
            <asp:BoundField HeaderText="StartDate" DataField="StartDate" DataFormatString ="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="EndDate" DataField="EndDate"  DataFormatString ="{0:dd/MM/yyyy}" />
            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="approve_button" Text="Claim" CommandName="ClaimButton"></asp:ButtonField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
