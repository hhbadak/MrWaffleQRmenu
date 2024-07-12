<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.categories" %>

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
        <div class="mb-3">
            <a href="../YoneticiPaneli/createCategory.aspx" style="width:100%; padding:1%;" class="btn btn-primary btn-lg"><i class="align-middle me-2" data-feather="plus"></i> &nbsp KATEGORİ EKLE</a>
        </div>
        <asp:ListView ID="lv_listCategory" runat="server" DataKeyNames="ID" OnItemCommand="lv_listCategory_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Adı</th>
                            <th>Aktif Mi?</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Active") %></td>
                    <td>
                        <a href='../YoneticiPaneli/updateCategory.aspx?mid=<%# Eval("ID") %>' class="duzenle"><i class="align-middle me-2" data-feather="edit"></i></a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="delete"><i class="align-middle me-2" data-feather="trash-2"></i></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
