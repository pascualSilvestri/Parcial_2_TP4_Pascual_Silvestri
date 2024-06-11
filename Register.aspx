<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Parcial_2_TP4_Pascual_Silvestri.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Invalid email format." ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Username is required." ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAge" ErrorMessage="Age is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBoxAge" MinimumValue="16" MaximumValue="120" Type="Integer" ErrorMessage="Age must be greater than 15." ForeColor="Red"></asp:RangeValidator>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Repeat Password"></asp:Label>
        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Repeat Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBoxRepeatPassword" ControlToCompare="TextBoxPassword" ErrorMessage="Passwords do not match." ForeColor="Red"></asp:CompareValidator>
    </div>
    <div>
        <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
    </div>
</asp:Content>
