<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.user_tb.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		用户Phone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_telphone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_sex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户昵称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_nikeName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户头像
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_photo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出生年月
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_birthday" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身高
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_height" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		体重
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_weight" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		常住地
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_address" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		职业
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_job" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		年收入
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_income" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户密码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_pwd" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		感情状况
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_marrystate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学历
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_edu" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		个人中心背景
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpersoncenter_bg" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		头像审核状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_photo_state" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluser_state" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




