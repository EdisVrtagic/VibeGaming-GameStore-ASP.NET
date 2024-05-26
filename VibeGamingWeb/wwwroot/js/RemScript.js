
var currentUrl = window.location.href;
var questionMarkIndex = currentUrl.indexOf("?");
if (questionMarkIndex !== -1) {
    var baseUrl = currentUrl.substring(0, questionMarkIndex);
    window.history.replaceState({}, document.title, baseUrl);
}
