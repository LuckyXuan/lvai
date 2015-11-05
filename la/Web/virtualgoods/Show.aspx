<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.virtualgoods.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品价格
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_price" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品说明
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_comment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品图片
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_pic_url" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品类别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_type" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		虚拟物品功能
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvirtualgoods_fun" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




