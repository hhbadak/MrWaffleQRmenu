<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="updateProduct.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.updateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>ÜRÜN ÜZENLEME SAYFASI</h1>
    </div>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-lg-6">
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Ürün Düzenleme Başarılı
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="card">
                    <label><b>Ürün Kategorisi</b></label>
                    <asp:DropDownList ID="ddl_category" runat="server" Enabled="false" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <label><b>Ürün Adı</b></label>
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control" Placeholder="ÜRÜN ADI"></asp:TextBox><br />
                    <label><b>Ürün Açıklaması</b></label>
                    <asp:TextBox ID="tb_description" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="AÇIKLAMA"></asp:TextBox><br />
                    <label><b>Ürün Fiyatı</b></label>
                    <asp:TextBox ID="tb_price" runat="server" CssClass="form-control" TextMode="Number" Placeholder="FİYAT"></asp:TextBox><br />
                    <label><b>Ürün Resmi</b></label>
                    <asp:Image ID="img_picture" runat="server" Style="width: 250px" /><br />
                    <asp:FileUpload ID="fu_picture" runat="server"></asp:FileUpload><br />
                    <label><b>Çok Satılan mı?</b></label>
                    <asp:CheckBox ID="cb_best" CssClass="form-control" runat="server" />
                    <label><b>Ürün Sırası</b></label>
<asp:DropDownList ID="ddl_order" runat="server" CssClass="form-control">
    <!-- Sıra numaraları burada listelenecek -->
</asp:DropDownList><br />
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_update" runat="server" Text="GÜNCELLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_update_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
