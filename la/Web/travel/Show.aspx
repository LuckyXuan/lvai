<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="la.Web.travel.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		旅行ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltravle_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发起人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpromoter_userid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发布时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblrelease_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		目的地
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDestination" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出发地
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstartplace" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		返回时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreturn_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出发时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstart_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		交通方式
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltransportation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		费用说明
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblfee" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅行主题
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltravle_theme" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		需要旅伴人数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltravle_personcount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcompanion_condition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		留言
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltravle_msg" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图1
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpic1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpic2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图3
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpic3" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴收入要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblincome_condition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴车辆要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcar_condition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴身高要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblheight_condition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴信用要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcredit_condition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		想得到的礼品
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwantget_gift" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		想送出的礼品
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwantsend_gift" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报名费用（旅币)
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreg_fee" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




