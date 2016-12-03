<%@ Page Title="UpdateItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_TeamProject.Update" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
            <div class="col-md-4">
               
                <h3>Update Page</h3>

                
                <asp:DropDownList ID="CurrentStatus" AutoPostBack="true" runat="server" >
                  <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                     <asp:ListItem Text="YetToBegin" Value="2"></asp:ListItem>
                     <asp:ListItem Text="InProgress" Value="3"></asp:ListItem>
                </asp:DropDownList>

                <br />
                <br />  

                <asp:DropDownList ID="ItemStatus" AutoPostBack="true" runat="server" >
                     <asp:ListItem Text="Loaned" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Wanted" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Owned" Value="3"></asp:ListItem>
                 </asp:DropDownList>

                <br /> <br />
                <asp:Button ID="UpdateButton" Text="UpdateButton" OnClick="UpdateButton_Click"  runat="server"/>

            </div>
    </div>
</asp:Content>