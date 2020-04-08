<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="Policy.aspx.cs" Inherits="Claim_Management_System.Policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnMainPage" runat="server" CssClass="button" Text="Main Page" OnClick="btnMainPage_Click" />
    <asp:Panel ID="panelEditPlan" runat="server" Height="40%">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="gridPlan" runat="server" AutoGenerateColumns="False" BorderColor="#E7E7FF" Width="90%" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="8" GridLines="Horizontal" OnRowDeleted="gridPlan_RowDeleted" OnRowDeleting="gridPlan_RowDeleting" Height="271px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="PlanCodeId" HeaderStyle-CssClass="gridview-hidden-column" HeaderText="Plan Id" ItemStyle-CssClass="gridview-hidden-column">
                    <HeaderStyle CssClass="gridview-hidden-column" />
                    <ItemStyle CssClass="gridview-hidden-column" />
                </asp:BoundField>
                <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                <asp:BoundField DataField="PlanDescription" HeaderText="PlanDescription" />
                <asp:BoundField DataField="Coverage1" HeaderText="Coverage1 (3 months) ₹" />
                <asp:BoundField DataField="Coverage2" HeaderText="Coverage2 (6 months) ₹" />
                <asp:BoundField DataField="Coverage3" HeaderText="Coverage3 (9 months) ₹" />
                <asp:BoundField DataField="Coverage4" HeaderText="Coverage4 (12 months) ₹" />
                <asp:BoundField DataField="Coverage5" HeaderText="Coverage5 (15 months) ₹" />

                <asp:CommandField ControlStyle-CssClass="reject_button" ControlStyle-Font-Size ="Large"  ShowDeleteButton="true" HeaderStyle-Width="50px" HeaderStyle-Height="3px">
                    <ControlStyle CssClass="reject_button" />
                </asp:CommandField>
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

    <br />

    <asp:Panel ID="PanelAddPlan" runat="server">
        <table class="slide_show">

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>PlanName</td>
                <td>
                    <asp:TextBox ID="txtPlanName" runat="server" CssClass="text-style"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPlanName" ForeColor="Red" ValidationGroup="SubmitButton">*PlanName is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>PlanDescription</td>
                <td>
                    <asp:TextBox ID="txtPlainDescription" runat="server" TextMode="MultiLine" Width="314px" CssClass="text-style"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPlainDescription" ForeColor="Red" ValidationGroup="SubmitButton">*PlainDescription is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Coverage1 (3 months) ₹</td>
                <td>
                    <asp:TextBox ID="txtCoverage1" runat="server" CssClass="text-style" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCoverage1" ForeColor="Red" ValidationGroup="SubmitButton">*Coverage1 is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCoverage1" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[0-9]{1,}" ValidationGroup="SubmitButton">*Should be numbers </asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Coverage2 (6 months) ₹</td>
                <td>
                    <asp:TextBox ID="txtCoverage2" runat="server" CssClass="text-style"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCoverage2" ForeColor="Red" ValidationGroup="SubmitButton">*Coverage2 is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCoverage2" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[0-9]{1,}" ValidationGroup="SubmitButton">*Should be numbers </asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Coverage3 (9 months) ₹</td>
                <td>
                    <asp:TextBox ID="txtCoverage3" runat="server" CssClass="text-style" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCoverage3" ForeColor="Red" ValidationGroup="SubmitButton">*Coverage3 is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCoverage3" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[0-9]{1,}" ValidationGroup="SubmitButton">*Should be numbers </asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Coverage4 (12 months) ₹</td>
                <td>
                    <asp:TextBox ID="txtCoverage4" runat="server" CssClass="text-style"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCoverage4" ForeColor="Red" ValidationGroup="SubmitButton">*Coverage4 is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCoverage4" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[0-9]{1,}" ValidationGroup="SubmitButton">*Should be numbers </asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Coverage5 (15 months) ₹</td>
                <td>
                    <asp:TextBox ID="txtCoverage5" runat="server" CssClass="text-style"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCoverage5" ForeColor="Red" ValidationGroup="SubmitButton">*Coverage5 is Mandatory</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCoverage5" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[0-9]{1,}" ValidationGroup="SubmitButton">*Should be numbers </asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="button" ValidationGroup="SubmitButton" OnClick="SubmitButton_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
