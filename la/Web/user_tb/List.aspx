<%@ Page Title="用户表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="la.Web.user_tb.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="user_telphone" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="user_telphone" HeaderText="用户Phone" SortExpression="user_telphone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_sex" HeaderText="用户性别" SortExpression="user_sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_nikeName" HeaderText="用户昵称" SortExpression="user_nikeName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_photo" HeaderText="用户头像" SortExpression="user_photo" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_birthday" HeaderText="出生年月" SortExpression="user_birthday" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_height" HeaderText="身高" SortExpression="user_height" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_weight" HeaderText="体重" SortExpression="user_weight" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_address" HeaderText="常住地" SortExpression="user_address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_job" HeaderText="职业" SortExpression="user_job" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_income" HeaderText="年收入" SortExpression="user_income" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_pwd" HeaderText="用户密码" SortExpression="user_pwd" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_marrystate" HeaderText="感情状况" SortExpression="user_marrystate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_edu" HeaderText="学历" SortExpression="user_edu" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="personcenter_bg" HeaderText="个人中心背景" SortExpression="personcenter_bg" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_photo_state" HeaderText="头像审核状态" SortExpression="user_photo_state" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="user_state" HeaderText="用户状态" SortExpression="user_state" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="user_telphone" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="user_telphone" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
