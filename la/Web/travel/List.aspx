<%@ Page Title="发布的一次旅行" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="la.Web.travel.List" %>
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
                    BorderWidth="1px" DataKeyNames="travle_ID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="travle_ID" HeaderText="旅行ID" SortExpression="travle_ID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="promoter_userid" HeaderText="发起人" SortExpression="promoter_userid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="release_time" HeaderText="发布时间" SortExpression="release_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Destination" HeaderText="目的地" SortExpression="Destination" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="startplace" HeaderText="出发地" SortExpression="startplace" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="return_time" HeaderText="返回时间" SortExpression="return_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="start_time" HeaderText="出发时间" SortExpression="start_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="transportation" HeaderText="交通方式" SortExpression="transportation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="fee" HeaderText="费用说明" SortExpression="fee" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="travle_theme" HeaderText="旅行主题" SortExpression="travle_theme" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="travle_personcount" HeaderText="需要旅伴人数" SortExpression="travle_personcount" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="companion_condition" HeaderText="旅伴要求" SortExpression="companion_condition" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="travle_msg" HeaderText="留言" SortExpression="travle_msg" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pic1" HeaderText="图1" SortExpression="pic1" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pic2" HeaderText="图2" SortExpression="pic2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pic3" HeaderText="图3" SortExpression="pic3" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="income_condition" HeaderText="旅伴收入要求" SortExpression="income_condition" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="car_condition" HeaderText="旅伴车辆要求" SortExpression="car_condition" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="height_condition" HeaderText="旅伴身高要求" SortExpression="height_condition" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="credit_condition" HeaderText="旅伴信用要求" SortExpression="credit_condition" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="wantget_gift" HeaderText="想得到的礼品" SortExpression="wantget_gift" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="wantsend_gift" HeaderText="想送出的礼品" SortExpression="wantsend_gift" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="reg_fee" HeaderText="报名费用（旅币)" SortExpression="reg_fee" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="travle_ID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="travle_ID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
