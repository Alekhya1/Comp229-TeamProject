<%@ Page Title="ViewItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="Comp229_TeamProject.ViewBooks" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    
               
            <div class="row" runat="server">
            
                <div class="col-md-4">
                    <h1>  Item Details </h1>

                 <asp:Label ID="nameofitem" runat="server" /> <br /> <br />
                 <asp:Label ID="UniqueNo" runat="server" /> <br /> <br />
                <asp:Label ID="RDate" runat="server" /> <br /> <br />
                <asp:Label ID="Description" runat="server" /> <br /> <br />
                <asp:Label ID="Others" runat="server" /> <br /> 
           
                 <h4> Reviews given by other Users </h4>  
                 <asp:GridView ID="Reviewdetails" runat="server" />
                       
                   

               </div>
   </div>                  
   
    
    </asp:Content>
