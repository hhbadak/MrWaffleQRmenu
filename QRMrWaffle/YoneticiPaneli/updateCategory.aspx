<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="updateCategory.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.updateCategory" %>
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
                    <label><b>Kategori Adı</b></label>
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control" Placeholder="KATEGORİ ADI"></asp:TextBox><br />
                    <label><b>Kategori Aktif Mi?</b></label>
                    <asp:CheckBox ID="cb_active" CssClass="form-control" runat="server" />
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_update" runat="server" Text="GÜNCELLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_update_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
