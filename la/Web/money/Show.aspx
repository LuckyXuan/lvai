﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.money.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		财富ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoney_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户Phone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_telphone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		财富变化
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoney_change" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		财富变化时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoneychange_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		财富变化说明
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoneychange_comment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		余额
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoney_balance" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		财富变化类型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmoneychange_type" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




