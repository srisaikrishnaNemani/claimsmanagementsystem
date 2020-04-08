<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="ApproveCustomer.aspx.cs" Inherits="Claim_Management_System.ApproveCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnMainPage" CssClass="button" runat="server" Text="Main Page" OnClick="btnMainPage_Click" />
    <div id="container">
        <div class="gridview">
            <asp:Panel ID="panelGridViewOfMembers" runat="server">
                <asp:GridView ID="GridViewApproveCustomer" runat="server" AutoGenerateColumns="False" Width="1057px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" CssClass="table" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gridviewApproveMember">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="MemberId" HeaderStyle-CssClass="gridview-hidden-column" HeaderText="Member Id" ItemStyle-CssClass="gridview-hidden-column">
                            <HeaderStyle CssClass="gridview-hidden-column" />
                            <ItemStyle CssClass="gridview-hidden-column" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="DateOfBirth" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Dob" />
                        <asp:BoundField DataField="Contact" HeaderText="Contact Number" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:ButtonField ButtonType="Button" CommandName="ApproveMember" ControlStyle-CssClass="approve_button" Text="Approve">
                            <ControlStyle CssClass="approve_button" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" CommandName="RejectMember" ControlStyle-CssClass="reject_button" Text="Reject">
                            <ControlStyle CssClass="reject_button" />
                        </asp:ButtonField>
                         <asp:BoundField DataField="Active" HeaderText="Status" />
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
        </div>
    </div>
   
</asp:Content>
