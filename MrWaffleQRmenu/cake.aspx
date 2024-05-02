<%@ Page Title="Pasta" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="cake.aspx.cs" Inherits="MrWaffleQRmenu.cake" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- food section -->

    <section class="food_section layout_padding-bottom">
        <div class="container">
            <div class="heading_container heading_center">
                <h2>Pastalar
                </h2>
            </div>
            <div class="filters-content">
                <div class="row grid">
                    <asp:Repeater ID="rp_fair" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-6 col-lg-4">
                                <div class="box">
                                    <div>

                                        <div class="img-box">
                                            <img loading="lazy" src='images/cake/<%# Eval("image") %>' alt='<%# Eval("title") %>' />
                                        </div>
                                        <div class="detail-box">
                                            <h5>Delicious Pizza
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div class="options">
                                                <h6>$20
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
