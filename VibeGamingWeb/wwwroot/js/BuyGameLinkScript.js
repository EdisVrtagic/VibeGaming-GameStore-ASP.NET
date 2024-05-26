jQuery(function ($) {
    $(".buyGameLink").on("click", function (e) {
        e.preventDefault();
        var gameId = $(this).data("game-id");
        var gameTitle = $(this).data("game-title");
        var url = `/p/${gameId}-buy-${gameTitle}`;
        window.location.href = url;
    });
});