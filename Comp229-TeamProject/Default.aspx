<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_TeamProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>  
        <h1>AA Library</h1>
        <p class="lead">AA Library is a national depository library . 
            The library has no branchesFacilities.
            As a depository library it receives a copy of all books, newspapers and periodicals published across the world. 
            The users are free to use the library and books upon one time subscription. 
            The library has a network of mobile branches with free to use facilities upon refundable security deposit.</p>
    </div>
     <div> 
         <p>Username</p>
    <p> <asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>
    <p><asp:RequiredFieldValidator ID="UserNameReq" runat="server" ControlToValidate="UserName" ErrorMessage="Required UserName" SetFocusOnError="true"></asp:RequiredFieldValidator>
   <p>Password</p>
        <p> <asp:TextBox ID="Password" runat="server"></asp:TextBox></p>
        <p><asp:RequiredFieldValidator ID="PasswordReq" runat="server" ControlToValidate="Password" ErrorMessage="Required Password" SetFocusOnError="true"></asp:RequiredFieldValidator>
   <p> <asp:Button ID="register" Text="Register" runat="server" /></p>
    <p> <asp:Button ID="Update" Text="Update" runat="server" /></p>
     </div>
  </asp:Content>
