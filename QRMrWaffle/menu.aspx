﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="QRMrWaffle.menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MrWaffles</title>
    <meta charset="UTF-8" />

    <link href="styles.css" rel="stylesheet" />
    <link rel="icon" href="assets/images/websiteico.ico" type="image/ico" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Eskişehir waffle lezzetini en kaliteli ürünlerimiz ile waffle hazzına ulaşabileceğiniz hizmet sunuyoruz" />
    <meta name="author" content="HHBadak" />
    <meta name="author" content="Appsoly" />
    <meta name="keywords" content="waffle, eskişehir, eskişehir tatlı, eskişehir waffle, espark, MrWaffle" />
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/images/websiteico.png" />

    <link rel="canonical" href="https://www.mrwaffle.com.tr/" />
    <style>
        /* Pop-up stilleri */
        .popup-container {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            display: flex;
            justify-content: center;
            align-items: center;
            z-index: 9999;
        }

        .popup-content {
            background-color: #fff;
            padding: 40px;
            width: 70%;
            max-width: 800px;
            text-align: center;
            border-radius: 5px;
            font-family: 'Poppins', sans-serif;
            position: relative; /* Yeni eklenen kapatma düğmesi için konumlandırma */
        }

        .close-button {
            position: absolute;
            top: 10px;
            right: 10px;
            cursor: pointer;
            font-weight: bold;
            font-size: 18px;
            color: #000;
        }

            .close-button:hover {
                color: #555;
            }

        @media screen and (max-width: 600px) {
            .popup-content {
                width: 90%;
                padding: 20px;
            }
        }

        /* Footer stilleri */
        .footer {
            background-color: #333;
            color: #fff;
            padding: 10px;
            text-align: center;
            font-family: 'Poppins', sans-serif;
        }

        .responsive-img {
            width: 200px; /* Genişliği konteynere uyacak şekilde yapar */
            height: auto; /* Yüksekliği otomatik olarak ayarlar */
            object-fit: cover; /* Görüntüyü konteyneri kaplayacak şekilde kırpar */
        }
    </style>

    <script>
        // Pop-up kapatma işlemi
        function closePopup() {
            var popupContainer = document.getElementById('popup-container');
            popupContainer.style.display = 'none';
        }

        // Boşluğa tıklayınca pop-up'ı kapatma işlemi
        window.addEventListener('click', function (event) {
            var popupContainer = document.getElementById('popup-container');
            var popupContent = document.getElementById('popup-content');
            if (event.target === popupContainer || !popupContent.contains(event.target)) {
                popupContainer.style.display = 'none';
            }
        });
    </script>

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="popup-container" class="popup-container">
            <div id="popup-content" class="popup-content">
                <h2>Hoş Geldiniz!</h2>
                <asp:Repeater ID="rp_popUp" runat="server">
                    <ItemTemplate>
                        <a href="<%# Eval("Url") %>">
                            <p style="color: blue"><%# Eval("Name") %></p>
                            <img rel="preload" src="assets/images/popUp/<%# Eval("Image") %>" style="width: 200px" />

                        </a>
                        <div class="close-button" onclick="closePopup()">&#x2716;</div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="navbar">
            <div class="logo">
                <img src="assets/images/websiteico.jpg" alt="Logo" />
            </div>
            <div class="carousel-container">
                <div class="carousel-item"><a href="#cok-satanlar">ÇOK SATANLAR</a></div>
                <asp:Repeater ID="rp_categories" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item"><a href='<%# "#" + Eval("SpecialID") %>'><%# Eval("Name") %></a></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <hr />
        <h1 id="cok-satanlar" class="section-title">ÇOK SATANLAR</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_best" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="MrWaffle" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />

        <asp:Repeater ID="rp_menuCategory" runat="server" OnItemDataBound="rp_menuCategory_ItemDataBound">
            <ItemTemplate>
                <h1 id='<%# Eval("SpecialID") %>' class="section-title"><%# Eval("Name") %></h1>
                <hr />
                <div class="menu">
                    <div class="menu-items">
                        <asp:Repeater ID="rp_menuProduct" runat="server">
                            <ItemTemplate>
                                <div class="menu-item" style="display: flex; align-items: center;">
                                    <img rel="preload" class="responsive-img" src='assets/images/product/<%# Eval("Image") %>' alt="<%# Eval("Name") %>" style="width: 100px" />
                                    <div class="item-details">
                                        <h3><%# Eval("Name") %></h3>
                                        <p><%# Eval("Description") %></p>
                                    </div>
                                    <p class="price"><b><%# Eval("Price") %>₺</b></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>




        <%--<h1 id="coldSandwich" class="section-title">Soğuk Sandviç</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_coldSandwich" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Waffle" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                                <p class="price"><%# Eval("Price") %>₺</p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="atistirmalik" class="section-title">TOST-MENEMEN</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_food" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Tost - Menemen" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <h1 id="waffle" class="section-title">WAFFLE</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_waffle" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Waffle" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="pasta" class="section-title">Tatlılar(El Yapımı)</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_cake" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Pastalar" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="lemonade" class="section-title">Limonatalar</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_lemonade" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Espress Kahveler" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="redbull" class="section-title">Redbull Kokteyller</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_redbull" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Kokteyl" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="sicak" class="section-title">SICAK İÇECEKLER</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_hot" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Sıcak İçecekler" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
        <h1 id="soguk" class="section-title">SOĞUK İÇECEKLER</h1>
        <hr />
        <div class="menu">
            <div class="menu-items">
                <asp:Repeater ID="rp_cold" runat="server">
                    <ItemTemplate>
                        <div class="menu-item" style="display: flex; align-items: center;">
                            <img rel="preload" class=".responsive-img" src='assets/images/product/<%# Eval("image") %>' alt="Soğuk İçecekler" style="width: 100px" />
                            <div class="item-details">
                                <h3><%# Eval("Name") %></h3>
                                <p><%#Eval("Description") %></p>
                            </div>
                            <p class="price"><b><%# Eval("Price") %>₺</b></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />--%>



        <div class="footer">
            <p><a href="https://appsoly.com/" style="color: white;">Appsoly</a> &copy; 2024</p>
        </div>
    </form>
</body>
</html>
