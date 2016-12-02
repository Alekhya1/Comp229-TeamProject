<%@ Page Title="ViewItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="Comp229_TeamProject.ViewBooks" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    
               
            <div class="row" runat="server">
            
                <div class="col-md-4">
                    <h1>  Item Details </h1>

                 <asp:Label ID="category" runat="server" Visible="false" />
                  <asp:Label ID="ItemId" runat="server" Visible="false" />
                 <asp:Label ID="nameofitem" runat="server" /> <br /> <br />
                 <asp:Label ID="UniqueNo" runat="server" /><asp:Label ID="pages" runat="server" /> <br /> <br />
                <asp:Label ID="RDate" runat="server" /> <br /> <br />
                <asp:Label ID="Description" runat="server" /> <br /> <br />
                <div id="authors" runat="server" visible="false"> <h6> <b> Authors : </b></h6>
                  <asp:Label ID="authordata" runat="server" />
                    <asp:Repeater ID="authordetails" runat="server" >
                    <ItemTemplate><h6><%# Eval("AuthorName") %></h6></ItemTemplate> 
                   </asp:Repeater> 
                </div>

               <div id="isbns" visible="false" runat="server"> <h6><b> ISBN : </b></h6> 
                 <asp:Label ID="isbndata" runat="server" />
                 <asp:Repeater ID="isbndetails" runat="server">
                    <ItemTemplate> <h6><%# Eval("ISBN") %> </h6></ItemTemplate> 
                  </asp:Repeater>
               </div>
           
                 <h4> Reviews given by other Users </h4>  
                 <asp:Label ID="reviewdata" runat="server" />
                 <asp:GridView ID="Reviewdetails" runat="server" />  <br /><br />
                       
           <asp:Button ID="Update" Text="Update" runat="server" OnClick="Update_Click"> </asp:Button>        
     </div>
               
   </div>                  
   
    
    </asp:Content>
