<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentForm.aspx.cs" Inherits="AspDotNet2_l5.DepartmentForm"  MasterPageFile="~/Policedepartment.Master"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder"
    runat="server">
    <table style="width: 100%;">
        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Depatments"
                    Font-Size="18pt" ForeColor="#012F74" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewDepartment" runat="server"
                    AutoGenerateColumns="false"
                    ShowFooter="true" ShowHeader="true"
                    AllowPaging="true" PageSize="10"
                    Font-Size="14pt" HorizontalAlign="Center"
                    OnPageIndexChanging="GridViewDepartment_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Id"
                            ItemStyle-Width="50" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="myLabelId" runat="server"
                                    Text='<%# Bind("Id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City"
                            ItemStyle-Width="120">
                            <ItemTemplate>
                                <asp:Label ID="myLabelCity" runat="server"
                                    Text='<%# Bind("City")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelAddress" runat="server"
                                    Text='<%# Bind("Address")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

