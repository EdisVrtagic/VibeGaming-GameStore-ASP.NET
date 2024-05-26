document.addEventListener("DOMContentLoaded", function () {
    var selectElements = document.querySelectorAll("[id^='quantity-']");
    selectElements.forEach(function (selectElement) {
        selectElement.addEventListener("change", function () {
            var cartId = this.id.split("-")[1];
            var quantity = this.value;
            updateQuantity(cartId, quantity);
        });
    });

    function updateQuantity(cartId, quantity) {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Cart/UpdateQuantity", true);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                window.location.reload();
            }
        };
        xhr.send("cartId=" + cartId + "&quantity=" + quantity);
    }
});
