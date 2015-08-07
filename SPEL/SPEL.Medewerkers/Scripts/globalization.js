$(document).ready(function () {

    // Set Globalize to the current culture driven by the html lang property
    var currentCulture = $("html").prop("lang");
    if (currentCulture) {
        Globalize.culture(currentCulture);
    }
});