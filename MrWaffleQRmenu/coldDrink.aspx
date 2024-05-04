<%@ Page Title="Soğuk İçecekler" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="coldDrink.aspx.cs" Inherits="MrWaffleQRmenu.coldDrink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- food section -->

    <section class="food_section layout_padding-bottom">
        <div class="container">
            <div class="heading_container heading_center">
                <h2>Soğuk İçecekler
                </h2>
            </div>
            <div class="filters-content">
                <div class="row grid">
                    <asp:Repeater ID="rp_food" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-6 col-lg-4">
                                <div class="box">
                                    <div>

                                        <div class="img-box">
                                            <img loading="lazy" src='../MrWaffleAdminPanelMenu/img/product/<%# Eval("image") %>' alt='<%# Eval("name") %>' />
                                        </div>
                                        <div class="detail-box">
                                            <h5><%# Eval("Name") %>
                                            </h5>
                                            <p>
                                                <%#Eval("Description") %>
                                            </p>
                                            <div class="options">
                                                <h6><%# Eval("Price") %>₺
                                                </h6>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>

    <!-- end food section -->
</asp:Content>
