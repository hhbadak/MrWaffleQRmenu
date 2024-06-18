<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/index.Master" AutoEventWireup="true" CodeBehind="updatePopUp.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.updatePopUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>POP-UP GÜNCELLEME SAYFASI</h1>
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
                    <label><b>Pop-Up Metnini Giriniz</b></label>
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control" Placeholder="Pop-Up Metni"></asp:TextBox><br />
                    <label><b>Pop-Up Resmi</b></label>
                    <asp:Image ID="img_picture" runat="server" Style="width: 250px" /><br />
                    <asp:FileUpload ID="fu_picture" runat="server"></asp:FileUpload><br />
                    <label><b>Yönlendirilecek Url Adresini Giriniz</b></label>
                    <asp:TextBox ID="tb_url" runat="server" CssClass="form-control" Placeholder="Url Adresi"></asp:TextBox><br />
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_update" runat="server" Text="GÜNCELLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_update_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
