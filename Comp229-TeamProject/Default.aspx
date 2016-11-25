﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_TeamProject._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <!--logo is from https://www.google.ca/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjHrv-jlcPQAhXj24MKHWk-DbYQjhwIBQ&url=http%3A%2F%2Fwww.illustrationsof.com%2F1097307-royalty-free-library-clipart-illustration&bvm=bv.139782543,d.amc&psig=AFQjCNFDecrRKsoitKWmiOSF4Os96Q7B7g&ust=1480137786694944 -->
  
    <div class="row">
        <div class="col-sm-3">  
          <asp:Image ID="studentimage" ImageUrl="~/Assets/imageslibrary.jpeg" runat="server" Height="150" Width="150"/> 
        </div>
        <div class="col-sm-9">       <h1>AA Library</h1>
       <h4>     AA Library is a national depository library . 
            As a depository library it receives a copy of all books, newspapers and periodicals published across the world. 
            The users are free to use the library and books upon one time subscription. 
            The library has a network of mobile branches with free to use facilities upon refundable security deposit.
       </h4>
        </div> 
    </div>  <br />

    <br /> <br />

     <div class="row"> 
        <div class="col-sm-3">
           
            <asp:Repeater ID="novels" runat="server">
                <HeaderTemplate>Novels</HeaderTemplate>
                <ItemTemplate><p> <%# Eval("Bookname") %></p></ItemTemplate>
            </asp:Repeater>
        </div>
     
         <div class="col-sm-3">
           
            <asp:Repeater ID="audiobooks" runat="server">
                <HeaderTemplate>Novels</HeaderTemplate>
                <ItemTemplate><p> <%# Eval("Bookname") %></p></ItemTemplate>
            </asp:Repeater>
        </div>

         <div class="col-sm-3">
           
            <asp:Repeater ID="ebooks" runat="server">
                <HeaderTemplate>Novels</HeaderTemplate>
                <ItemTemplate><p> <%# Eval("Bookname") %></p></ItemTemplate>
            </asp:Repeater>
        </div>

       <div class="col-sm-3"> 
            <h3> Login </h3>
             Username: <asp:TextBox ID="UserName" runat="server"/> 
              <asp:RequiredFieldValidator ID="UserNameReq" runat="server" ControlToValidate="UserName" ErrorMessage="Required UserName" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <br />
             Password :<asp:TextBox ID="Password" TextMode="Password" runat="server" />
               <asp:RequiredFieldValidator ID="PasswordReq" runat="server" ControlToValidate="Password" ErrorMessage="Required Password" SetFocusOnError="true"></asp:RequiredFieldValidator>
               <br />
            <div class="button"><asp:Button ID="LogIn" Text="LogIn" runat="server" style="text-align:center"/> </div> <br />
            New User? Register here
              <asp:Button ID="register" Text="Register" runat="server" />
        </div>
     </div>
  </asp:Content>
    