<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="Claim_Management_System.AdminRegistration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="reg_content">
        <div class="auto-style16">
            <span style="font-size: xx-large">Admin Registration</span><br />
            <br />
            <br />
            <br />
        </div>
        <table>
            <tr>
                <td>First Name </td>
                <td>
                    <asp:TextBox BorderStyle="Outset" ID="txtFirstName" placeholder="First Name" runat="server" CssClass="text-style" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">First Name Cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="expFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*First Name should be in CorrectFormat" ForeColor="Red" ValidationExpression="[A-Z a-z ]{2,90}"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" placeholder="Last Name" runat="server" CssClass="text-style" Width="235px" class="textboxdefault"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Last Name Cannot Be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 23px"></td>
                <td style="height: 23px">
                    <asp:RegularExpressionValidator ID="expFirstName0" runat="server" ControlToValidate="txtLastName" ErrorMessage="*Last Name should be in CorrectFormat" ForeColor="Red" ValidationExpression="[A-Z a-z ]{1,90}"></asp:RegularExpressionValidator>
                </td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Date Of Birth</td>
                <td>
                    <asp:TextBox class="textboxdefault" ID="txtDob" runat="server" CssClass="text-style" TextMode="Date" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDob" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Dob cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButton ID="rdMale" runat="server" AutoPostBack="True" Text="Male" />
                    <asp:RadioButton ID="rdFemale" runat="server" AutoPostBack="True" Text="Female" />
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td id="lblAge">Age</td>
                <td>
                    <asp:TextBox ID="txtAge" placeholder="Age" runat="server" CssClass="text-style" Width="235px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAge" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Age Cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="Age should be above 18" ForeColor="Red" MaximumValue="60" MinimumValue="18"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>Contact Number</td>
                <td>
                    <asp:TextBox ID="txtContactNumber" placeholder="Contact Number" runat="server" CssClass="text-style" Width="235px" MaxLength="12" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Contact Number cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{10}" CssClass="auto-style26" ValidationGroup="register" ForeColor="Red">Contact should be 10 digit number</asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Email Id</td>
                <td>
                    <asp:TextBox ID="txtEmail" placeholder="Email Id" runat="server" CssClass="text-style" Width="235px" TextMode="Email"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Email Id cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" CssClass="auto-style26" ValidationGroup="register" ForeColor="Red">Incorrect email format</asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="height: 26px">Alternate Contact Number</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtAltContactNumber" placeholder="AltContact Number" runat="server" CssClass="text-style" Width="235px" MaxLength="12" TextMode="Number"></asp:TextBox>
                </td>
                <td style="height: 26px"></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtAltContactNumber" ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{10}" CssClass="auto-style26" ValidationGroup="register" ForeColor="Red">Contact should be 10 digit number</asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" placeholder="Password" runat="server" TextMode="Password" CssClass="text-style" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Password cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="RegularExpressionValidator" ValidationExpression="(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&amp;])[A-Za-z\d@$!%*#?&amp;]{8,}" CssClass="auto-style26" ValidationGroup="register" ForeColor="Red">password should be minimum 8 characters with atleast one alphabet, number and special character</asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" placeholder="Confirm Password" runat="server" CssClass="text-style" TextMode="Password" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Password cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="CompareValidator" CssClass="auto-style26" ValidationGroup="register" ForeColor="Red">Password Mismatch</asp:CompareValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>FavoritePerson</td>
                <td>
                    <asp:TextBox ID="FavPerson" placeholder="Favorite Person" runat="server" CssClass="text-style" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FavPerson" ErrorMessage="RequiredFieldValidator" CssClass="auto-style25" ValidationGroup="register" ForeColor="Red">Field cannot be empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 95px"></td>
                <td style="height: 95px">
                    <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button" CausesValidation="False" /><asp:Button ID="btnAdminSignup" runat="server" Text="Register" CssClass="button" ValidationGroup="register" OnClick="btnAdminSignup_Click" />
                </td>
                <td style="height: 95px"></td>
            </tr>
        </table>
    </div>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
