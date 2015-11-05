<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="la.Web.travel.Modify" Title="修改页" %>
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
		<asp:label id="lbltravle_ID" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发起人
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpromoter_userid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发布时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtrelease_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		目的地
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDestination" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出发地
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtstartplace" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		返回时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtreturn_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出发时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtstart_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		交通方式
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttransportation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		费用说明
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfee" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅行主题
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttravle_theme" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		需要旅伴人数
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttravle_personcount" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcompanion_condition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		留言
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttravle_msg" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图1
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpic1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图2
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpic2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图3
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpic3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴收入要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtincome_condition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴车辆要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcar_condition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴身高要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtheight_condition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		旅伴信用要求
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcredit_condition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		想得到的礼品
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtwantget_gift" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		想送出的礼品
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtwantsend_gift" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报名费用（旅币)
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtreg_fee" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

