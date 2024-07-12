<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="createCategory.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.createCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>KATEGORİ EKLEME SAYFASI</h1>
    </div>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-lg-6">
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Ürün Ekleme Başarılı
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="card">

                    <label><b>Kategori Adını Giriniz</b></label>
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control" Placeholder="ÜRÜN ADI"></asp:TextBox><br />
                    <label><b>Kategori Aktif Mi?</b></label>
                    <asp:CheckBox ID="cb_best" CssClass="form-control" runat="server" />
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_create" runat="server" Text="EKLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_create_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
