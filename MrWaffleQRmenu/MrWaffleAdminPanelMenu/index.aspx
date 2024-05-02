<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MrWaffleQRmenu.MrWaffleAdminPanelMenu.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mr.Waffle Yönetici Paneli</title>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <asp:ListView ID="lv_makaleler" runat="server" OnItemCommand="lv_makaleler_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Resim</th>
                            <th>ID</th>
                            <th>Başlık</th>
                            <th>Kategori</th>
                            <th>Yonetici</th>
                            <th>Görüntüleme Sayısı</th>
                            <th>Ekleme Tarihi</th>
                            <th>Durum</th>
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
                     <td><img src="../MakaleResimleri/<%# Eval("Resim") %>" width="50" /></td>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Baslik") %></td>
                    <td><%# Eval("Kategori") %></td>
                    <td><%# Eval("Yonetici") %></td>
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("EklemeTarihStr") %></td>
                    <td><%# Eval("YayindaStr") %></td>
                    <td>
                        <a href='MakaleDuzenle.aspx?mid=<%# Eval("ID") %>' class="duzenle">Düzenle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
    <script src="bootstrap-5.3.0/js/bootstrap.bundle.js"></script>
    <script src="bootstrap-5.3.0/js/bootstrap.min.js"></script>
</body>
</html>
