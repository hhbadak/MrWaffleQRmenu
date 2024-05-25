<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MrWaffleQRmenu.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>QR Menu</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="https://fonts.cdnfonts.com/css/exo-2" />
    <style>
       .menu-container {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
}

.categories {
    flex: 0 0 30%; /* Kategorilerin genişliği */
}

.menu-items {
    flex: 0 0 70%; /* Menü öğelerinin genişliği */
}

    </style>
</head>
<body>
     <div class="menu-container">
        <div class="categories">
            <!-- Kategori butonları buraya eklenecek -->
        </div>
        <div class="menu-items">
            <!-- Menü öğeleri buraya eklenecek -->
        </div>
    </div>
    <script>
        // Örnek kategori ve menü verileri
        var categories = ["Appetizers", "Main Dishes", "Desserts", "Drinks"];
        var menuItems = {
            "Appetizers": ["Salad", "Soup", "Spring Rolls"],
            "Main Dishes": ["Burger", "Pizza", "Pasta"],
            "Desserts": ["Ice Cream", "Cake", "Fruit Salad"],
            "Drinks": ["Water", "Soda", "Juice"]
        };

        // Kategori butonları oluşturma
        var categoryContainer = document.querySelector('.categories');
        categories.forEach(function (category) {
            var button = document.createElement('button');
            button.textContent = category;
            button.addEventListener('click', function () {
                showMenuItems(category);
            });
            categoryContainer.appendChild(button);
        });

        // Menü öğelerini gösterme işlevi
        function showMenuItems(category) {
            var menuItemsContainer = document.querySelector('.menu-items');
            menuItemsContainer.innerHTML = ''; // Önceki menü öğelerini temizle
            menuItems[category].forEach(function (item) {
                var menuItem = document.createElement('div');
                menuItem.textContent = item;
                menuItemsContainer.appendChild(menuItem);
            });
        }

    </script>
</body>
</html>
