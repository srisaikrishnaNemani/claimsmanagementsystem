<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="TrackPolicy.aspx.cs" Inherits="Claim_Management_System.TrackPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnMainPage" CssClass="button" runat="server" Text="Main Page" OnClick="btnMainPage_Click" />
    <div id="panel1">
        <asp:Panel ID="panleNotification" runat="server">
            <h1>Approved/Processing Claims</h1>
            <asp:GridView ID="gridClaimStatus" runat="server" AutoGenerateColumns="False" CssClass="auto-style6" BorderColor="#E7E7FF" Height="153px" Width="855px" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="ClaimId" HeaderText="ClaimId" />
                    <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />                   
                    <asp:BoundField DataField="ApprovedAmount" HeaderText="Approved Amount" />
                    <asp:BoundField DataField="ClaimStatus" HeaderText="Status" />
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
            <h1>
                <asp:Label ID="lblApproveOrProcessing" runat="server" Text="No Processing/Approved Claim Found" Visible="False"></asp:Label></h1>
            <h1>ReSubmit Claims</h1>
            <asp:GridView ID="gridReSubmitClaims" runat="server" AutoGenerateColumns="False" BorderColor="#E7E7FF" CssClass="auto-style7" Width="1035px" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="ResubmitGridview">

                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="claimId" HeaderStyle-CssClass="gridview-hidden-column" HeaderText="ClaimId" ItemStyle-CssClass="gridview-hidden-column">
                        <HeaderStyle CssClass="gridview-hidden-column" />
                        <ItemStyle CssClass="gridview-hidden-column" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />                   
                    <asp:BoundField DataField="ClaimStatus" HeaderText="Reason For Removal" />
                    <asp:ButtonField ButtonType="Button" CommandName="ReSubmit" ControlStyle-CssClass="approve_button" Text="ReSubmit">
                        <ControlStyle CssClass="approve_button" />
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
            <h1>
                <asp:Label ID="lblReSubmit" runat="server" Text="No ReSubmit Claim Found" Visible="False"></asp:Label></h1>
        </asp:Panel>

    </div>
</asp:Content>