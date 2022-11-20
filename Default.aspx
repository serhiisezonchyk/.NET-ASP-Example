<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspDotNet2_l5.Default"
    MasterPageFile="~/Policedepartment.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table align="center">

        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Policeman List"
                    Font-Size="18pt" ForeColor="#012F74" Font-Bold="True" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:GridView runat="server" ID="GridViewPoliceman"
                    AutoGenerateColumns="false"
                    ShowFooter="true" ShowHeader="true"
                    AllowPaging="true" PageSize="10"
                    OnRowDeleting="GridViewPoliceman_RowDeleting" Font-Size="14pt"
                    OnRowEditing="GridViewPoliceman_RowEditing"
                    OnRowCancelingEdit="GridViewPoliceman_RowCancelingEdit"
                    OnPageIndexChanging="GridViewPoliceman_PageIndexChanging"
                    HorizontalAlign="Center"
                    OnRowUpdating="GridViewPoliceman_RowUpdating"
                    OnRowCommand="GridViewPoliceman_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Id"
                            ItemStyle-Width="50" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="myLabelId" runat="server"
                                    Text='<%# Bind("Id")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxId" runat="server" Width="50"
                                    Text='<%# Bind("Id") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First name"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelFirstNane" runat="server"
                                    Text='<%# Bind("FirstName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxFirstName" runat="server" Width="150"
                                    Text='<%# Bind("FirstName") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBoxFirstName" runat="server"
                                    Width="150" Text='<%# Bind("FirstName") %>' />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last name"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelLastName" runat="server"
                                    Text='<%# Bind("LastName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxLastName" runat="server" Width="150"
                                    Text='<%# Bind("LastName") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBoxLastName" runat="server" Width="150"
                                    Text='<%# Bind("LastName") %>' />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Age"
                            ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label ID="myLabelAge" runat="server"
                                    Text='<%# Bind("Age")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxAge" runat="server" Width="50"
                                    Text='<%# Bind("Age") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBoxAge" runat="server"
                                    Width="50" Text='<%# Bind("Age") %>' />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sex"
                            ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="myLabelSex" runat="server"
                                    Text='<%#Eval("Sex.Id") +") "+  Eval("Sex.Name")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxSex" runat="server" Width="100" Text='<%#Eval("Sex.Id")%>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="myFooterTextBoxSex" runat="server"
                                    Width="130" AppendDataBoundItems="true" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department"
                            ItemStyle-Width="200">
                            <ItemTemplate>
                                <asp:Label ID="myLabelDepartment" runat="server"
                                    Text='<%# Eval("Department.Id") + ") " +Eval("Department.Address") + ", "+Eval("Department.City")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxDepartment" runat="server" Width="200" Text='<%#Eval("Department.Id")%>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="myFooterTextBoxDepartment" runat="server"
                                    Width="200" AppendDataBoundItems="true" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rank"
                            ItemStyle-Width="130">
                            <ItemTemplate>
                                <asp:Label ID="myLabelRank" runat="server"
                                    Text='<%# Eval("Rank.Id") +") "+  Eval("Rank.Name")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox  ID="myTextBoxRank" runat="server" Width="130" Text='<%#Eval("Rank.Id")%>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="myFooterTextBoxRank" runat="server"
                                    Width="130" AppendDataBoundItems="true" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server"
                                    CommandName="Edit" Text="Edit"
                                    ImageUrl="~/resources/refresh.png" />
                                <asp:ImageButton ID="ibDelete" runat="server"
                                    CommandName="Delete" Text="Delete"
                                    ImageUrl="~/resources/delete.png" />
                                <asp:ImageButton ID="ibSelect" runat="server"
                                    CommandName="Select"
                                    ImageUrl="~/resources/select.png"
                                    CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ibUpdate" runat="server"
                                    CommandName="Update" Text="Update"
                                    ImageUrl="~/resources/confirmation.png" />
                                <asp:ImageButton ID="ibCancel" runat="server"
                                    CommandName="Cancel" Text="Cancel"
                                    ImageUrl="~/resources/cancel.png" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ibInsert" runat="server" 
                                    CommandName="Insert" OnClick="ibInsert_Click"
                                    ImageUrl="~/resources/plus.png" CausesValidation="false" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <EmptyDataTemplate>
                        <table border="1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="150" align="center">First name</td>
                                <td width="150" align="center">Last name</td>
                                <td width="50" align="center">Age</td>
                                <td width="100" align="center">Sex</td>
                                <td width="200" align="center">Department</td>
                                <td width="130" align="center">Rank</td>
                                <td>Actions</td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:TextBox ID="emptyFirstNameTextBox" runat="server"
                                        Width="150" />
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyLastNameTextBox" runat="server"
                                        Width="150" />
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyAgeTextBox" runat="server"
                                        Width="50" />
                                </td>
                                    <asp:DropDownList ID="emptySexTextBox" runat="server"
                                        Width="100" AppendDataBoundItems="true">
                                        <asp:ListItem Text="1) male" Value="1" />
                                        <asp:ListItem Text="2) female" Value="2" />
                                     </asp:DropDownList>
                                <td>
                                    <asp:TextBox ID="emptyDepartmentTextBox" runat="server"
                                        Width="200"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyRankTextBox" runat="server"
                                        Width="130"/>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="emptyImageButton" runat="server"
                                        ImageUrl="~/resources/plus.png"
                                        OnClick="emptyImageButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Center" />
                </asp:GridView>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>

