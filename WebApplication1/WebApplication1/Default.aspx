<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <asp:TextBox ID="UserName" runat="server" />
        <asp:RequiredFieldValidator ID="usernamereq" runat="server" ErrorMessage="username req" ControlToValidate="UserName" SetFocusOnError="True"/>
        <asp:TextBox ID="Password" runat="server" />
               <asp:TextBox ID="ReTypepassword" runat="server" TextMode="Password" />
         <asp:comparevalidator ID="passwordmismatch" runat="server" ErrorMessage="password mismatched" ValueToCompare="Password" SetFocusOnError="true" />
              
            </div>

</asp:Content>
