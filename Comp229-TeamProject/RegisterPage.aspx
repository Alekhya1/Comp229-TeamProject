<%@ Page Title="register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Comp229_TeamProject.RegisterPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
           <div class="col-md-4">
               <p>username:
        <asp:TextBox id="username" runat="server"/>
        <asp:RequiredFieldValidator ID="usernameReq" runat="server" ControlToValidate="Username"
            ErrorMessage="Username is required" SetFocusOnError="true"/>
    </p><br />
    <p>Password:
        <asp:TextBox id="Password" placeholder="" TextMode="Password" runat="server"/>
             Re-type Password:
        <asp:TextBox ID="RetypePassword" placeholder="" textMode="Password" runat="server" />
        <asp:CompareValidator ID="passwordreq" runat="server" ControlToValidate="Retypepassword" ControlToCompare="Password"
            ErrorMessage="Password is not matched" SetFocusOnError="true"/>
    </p><br />
              <p> 
                  First Name
               <asp:TextBox ID="FirstName" runat="server" />
               <asp:RequiredFieldValidator ID="FirstnameReq" runat="server" ControlToValidate="FirstName"
            ErrorMessage="FirstName is required" SetFocusOnError="true" BorderColor="#FF6600" ForeColor="#CC0000"/>
              </p>
    
               <p>
               LastName
               <asp:TextBox ID="LastName" runat="server"  />               
               <asp:RequiredFieldValidator ID="LastnameReq" runat="server" ControlToValidate="LastName" 
                ErrorMessage="LastName is required" SetFocusOnError="true" />
               </p>

               <p>
                EmailID <asp:TextBox ID="emailid" runat="server" />
                <asp:RegularExpressionValidator ID="validatorid" runat="server" ControlToValidate="emailid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="mailID is not in required format" BackColor="#FFFF99" BorderColor="#FF6600" ForeColor="#CC0000"/>
                   </p>
               <p>
               Phone#<asp:TextBox ID="Phone" runat="server" TextMode="Phone" />
               <asp:RequiredFieldValidator ID="Phonenoreq" runat="server" ControlToValidate="Phone"
               ErrorMessage="Username is required" SetFocusOnError="False" />
               </p>
                <Button ID="register" inputtype="submit" Text="Register" runat="server" OnClick="URL" />
              </div>
    </div>
     </asp:Content>