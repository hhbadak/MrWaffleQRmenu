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
                <div class="card" style="background-color:none !important">
                    <input type="text" class="form-control" placeholder="Ürün Adını Giriniz"><br />
                    <textarea class="form-control" rows="2" placeholder="Ürün Açıklamasını Giriniz"></textarea><br />
                    <input type="number" class="form-control" placeholder="Ürün Fiyatını Giriniz"><br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
