<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QRMrWaffle.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>MrWaffle</title>
    <link href="home.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Eskişehir waffle lezzetini en kaliteli ürünlerimiz ile waffle hazzına ulaşabileceğiniz hizmet sunuyoruz" />
    <meta name="author" content="HHBadak" />
    <meta name="author" content="Appsoly" />
    <meta name="keywords" content="waffle, eskişehir, eskişehir tatlı, eskişehir waffle, espark, MrWaffle" />
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/images/websiteico.png" />

    <link rel="canonical" href="https://www.mrwaffle.com.tr/" />
</head>
<body>
    <div class="card-container">
        <div class="logo">
            <img src="assets/images/websiteico.jpg" alt="Logo" />
        </div>
        <div class="card-link">
            <a href="menu.aspx#cok-satanlar">
                <div class="card" style="background-image: url('../assets/images/product/pasta.jpg');">
                    <div class="card-info">
                        <h4 style="text-align: center;">ÇOK SATANLAR</h4>
                    </div>
                </div>
            </a>
        </div>
        <asp:Repeater ID="rp_categories" runat="server">
            <ItemTemplate>
                <div class="card-link">
                    <a href='<%# "menu.aspx#" + Eval("SpecialID") %>'>
                        <div class="card" style="background-image: url('<%#"../assets/images/product/" + Eval("Image") %>');">
                            <div class="card-info">
                                <h4 style="text-align: center;"><%# Eval("Name") %></h4>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</body>
</html>
