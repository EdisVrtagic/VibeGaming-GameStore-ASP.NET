function smoothScroll(targetElement) {
    $('html, body').animate({
        scrollTop: targetElement.offset().top - 430
    }, 1000);
}
function handleNavClick(event) {
    event.preventDefault();
    var target = $($(this).attr('href'));
    if (target.length) {
        smoothScroll(target);
    }
}
$(function () {
    $('.nav.pc a.access').on('click', handleNavClick);
    $('.nav.playstation a.access').on('click', handleNavClick);
    $('.nav.xbox a.access').on('click', handleNavClick);
    $('.nav.nintendo a.access').on('click', handleNavClick);
});
