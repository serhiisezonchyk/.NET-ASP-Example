<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntruderForm.aspx.cs" Inherits="AspDotNet2_l5.IntruderForm" MasterPageFile="~/Policedepartment.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder"
    runat="server">
    <table style="width: 100%;">
        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Intruder List of  "
                    Font-Size="18pt" ForeColor="#012F74" Font-Bold="True" />
                <asp:Label ID="Label5" runat="server"
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
                    OnRowCancelingEdit="GridViewIntruder_RowCancelingEdit"
                    OnRowDeleting="GridViewIntruder_RowDeleting"
                    OnRowEditing="GridViewIntruder_RowEditing"
                    OnRowUpdating="GridViewIntruder_RowUpdating"
                    OnPageIndexChanging="GridViewIntruder_PageIndexChanging">
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
                            ItemStyle-Width="120">
                            <ItemTemplate>
                                <asp:Label ID="myLabelFirstName" runat="server"
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
                                <asp:TextBox ID="myFooterTextBoxLastName" runat="server"
                                    Width="150" Text='<%# Bind("LastName") %>' />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age" ItemStyle-Width="50">
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
                        <asp:TemplateField HeaderText="Phone"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelPhone" runat="server"
                                    Text='<%# Bind("Phone")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxPhone" runat="server" Width="150"
                                    Text='<%# Bind("Phone") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBoxPhone" runat="server"
                                    Width="150" Text='<%# Bind("Phone") %>' />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description"
                            ItemStyle-Width="200">
                            <ItemTemplate>
                                <asp:Label ID="myLabelDescription" runat="server"
                                    Text='<%# Bind("Description")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxDescription" runat="server" Width="200"
                                    Text='<%# Bind("Description") %>' Columns="5" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBoxDescription" runat="server"
                                    Width="200" Text='<%# Bind("Description") %>' Columns="5"/>
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
                                    Width="100" AppendDataBoundItems="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Policeman"
                            ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="myLabelPoliceman" runat="server"
                                    Text='<%#Eval("Policeman.Id") +") "+  Eval("Policeman.FirstName")+" "+ Eval("Policeman.LastName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBoxPoliceman" runat="server" Width="150" Text='<%#Eval("Policeman.Id")%>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="myFooterTextBoxPoliceman" runat="server"
                                    Width="150" AppendDataBoundItems="true" />
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
                                <td>Actions
                                </td>
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
                                <td>
                                    <asp:TextBox ID="emptyPhoneTextBox" runat="server"
                                        Width="150" />
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyDescriptionTextBox" runat="server"
                                        Width="200" Columns="5" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="emptySexTextBox" runat="server"
                                        Width="100" AppendDataBoundItems="true">
                                        <asp:ListItem Text="1) male" Value="1" />
                                        <asp:ListItem Text="2) female" Value="2" />
                                     </asp:DropDownList>
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
            </td>
        </tr>
    </table>
</asp:Content>
