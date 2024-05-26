$("#addToCartForm").on("submit", function (event) {
    event.preventDefault();
    $.ajax({
        type: "POST",
        url: "/BuyGame/BuyGame",
        data: $(this).serialize(),
        success: function (response) {
            updateCartItemCount();
            showAddedToCartMessage();
        },
        error: function () {
            alert("An error occurred while adding to cart.");
        }
    });
});
function showAddedToCartMessage() {
    var messageContainer = $('.prosucc-container');
    messageContainer.fadeIn();
    setTimeout(function () {
        messageContainer.fadeOut();
    }, 1000);
}
function updateCartItemCount() {
    $.ajax({
        type: "GET",
        url: "/BuyGame/GetCartItemCount",
        success: function (response) {
            $(".icon-cart-num").text(response.cartItemCount);
        },
        error: function () {
            alert("An error occurred while updating cart item count.");
        }
    });
}
