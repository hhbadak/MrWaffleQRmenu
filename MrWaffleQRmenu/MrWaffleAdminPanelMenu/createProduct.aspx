<%@ Page Title="" Language="C#" MasterPageFile="~/MrWaffleAdminPanelMenu/MrWaffleAdmin.Master" AutoEventWireup="true" CodeBehind="createProduct.aspx.cs" Inherits="MrWaffleQRmenu.MrWaffleAdminPanelMenu.createProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>ÜRÜN EKLEME SAYFASI</h1>
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
                    <label><b>Ürün Kategorisini Seçiniz</b></label>
                   <asp:DropDownList ID="ddl_category" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList><br />
                    <label><b>Ürün Adını Giriniz</b></label>
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control" Placeholder="ÜRÜN ADI"></asp:TextBox><br />
                    <label><b>Ürün Açıklamasını Giriniz</b></label>
                    <asp:TextBox ID="tb_description" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="AÇIKLAMA"></asp:TextBox><br />
                    <label><b>Ürün Fiyatını Giriniz</b></label>
                    <asp:TextBox ID="tb_price" runat="server" CssClass="form-control" TextMode="Number" Placeholder="FİYAT"></asp:TextBox><br />
                    <label><b>Ürün Resmi</b></label>
                    <asp:FileUpload ID="fu_picture" runat="server"></asp:FileUpload>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_create" runat="server" Text="EKLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_create_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
