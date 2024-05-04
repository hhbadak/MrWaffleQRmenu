<%@ Page Title="" Language="C#" MasterPageFile="~/MrWaffleAdminPanelMenu/MrWaffleAdmin.Master" AutoEventWireup="true" CodeBehind="coldDrink.aspx.cs" Inherits="MrWaffleQRmenu.MrWaffleAdminPanelMenu.coldDrink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="mt-5">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            Ürün Ekleme Başarılı
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>

        <asp:ListView ID="lv_listProduct" runat="server" OnItemCommand="lv_listProduct_ItemCommand">
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
                        <img src="../MrWaffleAdminPanelMenu/img/Product/<%# Eval("Image") %>" width="50" /></td>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Description") %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("Category") %></td>
                    <td>
                        <a href='../MrWaffleAdminPanelMenu/updateProduct.aspx?mid=<%# Eval("ID") %>' class="duzenle"><i class="align-middle me-2" data-feather="edit"></i></a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="delete"><i class="align-middle me-2" data-feather="trash-2"></i></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
