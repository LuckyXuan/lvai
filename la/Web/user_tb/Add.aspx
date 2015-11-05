<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="la.Web.user_tb.Add" Title="增加页" %>

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
		<asp:TextBox id="txtuser_telphone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkuser_sex" Text="用户性别" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户昵称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_nikeName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户头像
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_photo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出生年月
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtuser_birthday" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身高
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_height" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		体重
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_weight" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		常住地
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_address" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		职业
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_job" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		年收入
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_income" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户密码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_pwd" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		感情状况
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_marrystate" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学历
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_edu" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		个人中心背景
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpersoncenter_bg" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		头像审核状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_photo_state" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuser_state" runat="server" Width="200px"></asp:TextBox>
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
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
