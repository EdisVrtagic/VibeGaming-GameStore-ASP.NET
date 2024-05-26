document.addEventListener("DOMContentLoaded", function () {
    var cartItems = document.querySelectorAll(".gla-cart");
    var emptyCartDiv = document.getElementById("empty-cart");
    var cartContentDiv = document.getElementById("cart-content");

    if (cartItems.length === 0) {
        emptyCartDiv.style.display = "block";
        cartContentDiv.style.display = "none";
    } else {
        emptyCartDiv.style.display = "none";
        cartContentDiv.style.display = "block";
    }
});
