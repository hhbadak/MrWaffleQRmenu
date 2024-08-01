<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.productList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div>
                        <h3><%# Eval("Name") %></h3>
                        <p><%# Eval("Description") %></p>
                        <a href="updateProduct.aspx?mid=<%# Eval("ID") %>">Update</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

     <asp:ListView ID="lv_listProduct" runat="server" DataKeyNames="ID" OnItemCommand="lv_listProduct_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Fotoğraf</th>
                            <th>ID</th>
                            <th>Adı</th>
                            <th>Açıklaması</th>
                            <th>Fiyatı</th>
                            <th>Kategorisi</th>
                            <th>Seçenek</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../assets/images/product/<%# Eval("Image") %>" width="50" /></td>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Description") %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("Category") %></td>
                    <td>
                        <a href='../YoneticiPaneli/updateProduct.aspx?mid=<%# Eval("ID") %>' class="duzenle"><i class="align-middle me-2" data-feather="edit"></i></a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="delete"><i class="align-middle me-2" data-feather="trash-2"></i></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
