﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign.aspx.cs" Inherits="QRMrWaffle.YoneticiPaneli.sign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Mr.Waffle Yönetici Giriş</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Responsive Admin &amp; Dashboard Template based on Bootstrap 5" />
    <meta name="author" content="AdminKit" />
    <meta name="keywords" content="adminkit, bootstrap, bootstrap 5, admin, dashboard, template, responsive, css, sass, html, theme, front-end, ui kit, web" />

    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link rel="shortcut icon" href="../MrWaffleAdminPanelMenu/img/icons/icon-48x48.png" />

    <link rel="canonical" href="https://demo-basic.adminkit.io/pages-sign-up.html" />


    <link href="../YoneticiPaneli/css/app.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;600&display=swap" rel="stylesheet" />

      <script type="text/javascript">
        function handleEnterKey(event) {
            if (event.keyCode === 13) {
                document.getElementById('<%= HiddenField1.ClientID %>').value = 'true';
                __doPostBack('<%= lbtn_login.UniqueID %>', '');
                return false;
            }
        }
    </script>
</head>
<body>
   <form id="form1" runat="server">
        <main class="d-flex w-100">
            <div class="container d-flex flex-column">
                <div class="row vh-100">
                    <div class="col-sm-10 col-md-8 col-lg-6 mx-auto d-table h-100">
                        <div class="d-table-cell align-middle">

                            <div class="text-center mt-4">
                                <img src="../YoneticiPaneli/img/LOGO.jpg" />
                            </div>

                            <div class="card">
                                <div class="card-body">
                                    <asp:Panel ID="pnl_hata" runat="server" CssClass="messageBox" Visible="false">
                                        <asp:Label ID="lbl_hata" runat="server">Deneme Mesaj İçeriği</asp:Label>
                                    </asp:Panel>
                                    <div class="m-sm-4">
                                        <div class="mb-3">
                                            <label class="form-label">Soyadınızı Giriniz</label>
                                            <asp:TextBox ID="tb_surname" runat="server" CssClass="form-control form-control-lg" placeholder="Soyadınız"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <label class="form-label">Şifrenizi Giriniz</label>
                                            <asp:TextBox ID="tb_password" runat="server" CssClass="form-control form-control-lg" placeholder="Şifreniz" TextMode="Password" onkeydown="handleEnterKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="text-center mt-3">
                                            <asp:LinkButton ID="lbtn_login" runat="server" Text="Giriş Yap" CssClass="btn btn-lg btn-primary" OnClick="lbtn_login_Click"> </asp:LinkButton>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </form>
    <script src="../YoneticiPaneli/js/app.js"></script>
</body>
</html>
