<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnliIntrudeerList.aspx.cs" Inherits="AspDotNet2_l5.OnliIntrudeerList" MasterPageFile="~/Policedepartment.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder"
    runat="server">
    <table style="width: 100%;">
        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Intruder List"
                    Font-Size="18pt" ForeColor="#012F74" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewIntruder" runat="server"
                    AutoGenerateColumns="false"
                    ShowFooter="true" ShowHeader="true"
                    AllowPaging="true" PageSize="10"
                    Font-Size="14pt" HorizontalAlign="Center"
                    OnPageIndexChanging="GridViewIntruder_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Id"
                            ItemStyle-Width="50" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="myLabelId" runat="server"
                                    Text='<%# Bind("Id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First name"
                            ItemStyle-Width="120">
                            <ItemTemplate>
                                <asp:Label ID="myLabelFirstName" runat="server"
                                    Text='<%# Bind("FirstName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last name"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelLastName" runat="server"
                                    Text='<%# Bind("LastName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label ID="myLabelAge" runat="server"
                                    Text='<%# Bind("Age")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelPhone" runat="server"
                                    Text='<%# Bind("Phone")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description"
                            ItemStyle-Width="200">
                            <ItemTemplate>
                                <asp:Label ID="myLabelDescription" runat="server"
                                    Text='<%# Bind("Description")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sex"
                            ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="myLabelSex" runat="server"
                                    Text='<%#Eval("Sex.Id") +") "+  Eval("Sex.Name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Policeman"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelPoliceman" runat="server"
                                    Text='<%#Eval("Policeman.Id") +") "+  Eval("Policeman.FirstName")+" "+ Eval("Policeman.LastName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table border="1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="150" align="center">First name
                                </td>
                                <td width="150" align="center">Last name
                                </td>
                                <td width="50" align="center">Age
                                </td>
                                <td width="150" align="center">Phone
                                </td>
                                <td width="200" align="center">Description
                                </td>
                                <td width="100" align="center">Sex
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
