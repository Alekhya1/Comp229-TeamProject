﻿<!--Author of this page:Anitha,Description: Update page,version:1-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_TeamProject.Update" %>

<div class="row">
            <div class="col-md-4">
                12
                <h3>Click on book's name to access book details</h3>
                <asp:DataList ID="DataList" runat="server" Height="133px" Width="266px">
                <ItemTemplate>
                <asp:LinkButton ID="link" runat="server" HeaderText="LinkButton" Text ='<%#string.Format("{0} {1}", Eval(""),Eval("")) %>' PostBackUrl='<%# Eval("", "~/.aspx?ID={0}")%>'></asp:LinkButton>
                </ItemTemplate>
                </asp:DataList>
                </div>
    </div>t