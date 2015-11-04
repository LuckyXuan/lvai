<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.chat_message.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		聊天记录ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天记录FROM
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_FROM" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天记录TO
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_TO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天内容
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_content" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_comment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		聊天记录状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblchat_state" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




