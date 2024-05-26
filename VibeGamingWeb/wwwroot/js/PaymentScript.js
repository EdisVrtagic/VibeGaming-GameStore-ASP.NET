$(function () {
    $('#paymentForm').on('submit', function (event) {
        event.preventDefault();
        var successMessage = $('#successMessage');
        successMessage.fadeIn();
        var form = $('#paymentForm');
        form.hide();
        setTimeout(function () {
            successMessage.fadeOut(function () {
                form.off('submit').trigger('submit');
            });
        }, 2000);
    });
});
