<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_TeamProject._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <!--logo is from https://www.google.ca/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjHrv-jlcPQAhXj24MKHWk-DbYQjhwIBQ&url=http%3A%2F%2Fwww.illustrationsof.com%2F1097307-royalty-free-library-clipart-illustration&bvm=bv.139782543,d.amc&psig=AFQjCNFDecrRKsoitKWmiOSF4Os96Q7B7g&ust=1480137786694944 -->
  
    <div>  
        <a>
        <img src="Assets/imageslibrary.jpeg" /></a>
        <h1>AA Library</h1><br />
       <h3>     AA Library is a national depository library . 
            As a depository library it receives a copy of all books, newspapers and periodicals published across the world. 
            The users are free to use the library and books upon one time subscription. 
            The library has a network of mobile branches with free to use facilities upon refundable security deposit.
    </h3></div>
     <div> 
         <p>Username</p>
    <p> <asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>
    <p><asp:RequiredFieldValidator ID="UserNameReq" runat="server" ControlToValidate="UserName" ErrorMessage="Required UserName" SetFocusOnError="true"></asp:RequiredFieldValidator>
  <p> Password</p>
        <p> <asp:TextBox ID="Password" runat="server"></asp:TextBox></p>
        <p><asp:RequiredFieldValidator ID="PasswordReq" runat="server" ControlToValidate="Password" ErrorMessage="Required Password" SetFocusOnError="true"></asp:RequiredFieldValidator>
   <p> <asp:Button ID="LogIn" OnClick="LogIn_Click" Text="LogIn" runat="server" /></p>
         <p>New User? Register here
     <asp:Button ID="register" Text="Register" runat="server" /></p>
    <p> <asp:Button ID="Update" Text="Update" runat="server" /></p>
     </div>
  </asp:Content>
