<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="ApproveClaims.aspx.cs" Inherits="Claim_Management_System.ApproveClaims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnMainPage" CssClass="button" runat="server" Text="Main Page" OnClick="btnMainPage_Click" />
    <asp:Panel ID="panelGridViewOfClaim" runat="server">
        <asp:GridView ID="gridViewApproveClaims" runat="server" AutoGenerateColumns="False" Width="1093px" CssClass="table" CellPadding="3" GridLines="Horizontal" BorderColor="#E7E7FF" BackColor="White" BorderStyle="None" BorderWidth="1px" OnRowCommand="ApproveClaim">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                 <asp:BoundField DataField="ID" HeaderText="ID" />
                 <asp:BoundField DataField="ClaimId" HeaderText="ClaimId" />
                <asp:BoundField DataField="Member_Id" HeaderText="MemberPlanId" ItemStyle-CssClass="gridview-hidden-column" HeaderStyle-CssClass="gridview-hidden-column">
                    <HeaderStyle CssClass="gridview-hidden-column" />
                    <ItemStyle CssClass="gridview-hidden-column" />
                </asp:BoundField>               
                <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                <asp:BoundField DataField="ClaimServiceDate" HeaderText="Claim Service Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ClaimSubmissionDate" HeaderText="Claim Submission Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ClaimAmount" HeaderText="Claim Amount" />
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="approve_button" CommandName="ApproveClaim" Text="Approve">
                    <ControlStyle CssClass="approve_button" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="reject_button" CommandName="RejectClaim" Text="Reject">
                    <ControlStyle CssClass="reject_button" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="panelNoClaim" Visible="false" runat="server">
        <h1>No Claim Request Available</h1>
    </asp:Panel>

</asp:Content>
