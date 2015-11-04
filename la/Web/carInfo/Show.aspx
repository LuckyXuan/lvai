<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.carInfo.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		小车编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_id" runat="server"></asp:Label>
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
		车辆等级
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_level" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆牌子
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_brand" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆型号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_type" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片1
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片3
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo3" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片1审核状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo1_state" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片2审核状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo2_state" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		车辆图片3审核状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_photo3_state" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




