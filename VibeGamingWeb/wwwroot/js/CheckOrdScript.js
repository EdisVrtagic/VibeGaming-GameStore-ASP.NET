document.addEventListener("DOMContentLoaded", function () {
    var ordItems = document.querySelectorAll(".fill-order");
    var emptyOrderDiv = document.getElementById("empty-order");
    var orderContentDiv = document.getElementById("order-content");

    if (ordItems.length === 0) {
        emptyOrderDiv.style.display = "block";
        orderContentDiv.style.display = "none";
    } else {
        emptyOrderDiv.style.display = "none";
        orderContentDiv.style.display = "block";
    }
});
