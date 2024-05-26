// Prva JavaScript skripta
let search = document.querySelector(".search");
let clear = document.querySelector(".clear");
search.onclick = function () {
    document.querySelector(".container").classList.toggle('active');
}
clear.onclick = function () {
    document.getElementById("search").value = "";
    document.querySelector(".container").classList.toggle('active');
    $('#game-container').hide();
}

// Druga JavaScript skripta
jQuery(function ($) {
    $('#search').on('input', function () {
        var searchTerm = $(this).val().toLowerCase().trim();
        $('.game-avail').hide();
        $('.game-name-avail').each(function () {
            var gameName = $(this).text().toLowerCase();
            if (gameName.includes(searchTerm)) {
                $(this).closest('.game-avail').show();
            }
        });
        if (searchTerm !== '') {
            $('#game-container').show();
        } else {
            $('#game-container').hide();
        }
    });
});


