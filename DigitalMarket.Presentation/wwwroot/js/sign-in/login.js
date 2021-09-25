"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
function login() {
    var usernameInput = $('#username');
    var passwordInput = $('#password');
    var errorsBlock = $('#errorsBlock');
    var submitButton = $('#submit');
    usernameInput.removeClass("input-error");
    passwordInput.removeClass("input-error");
    errorsBlock.empty();
    submitButton.attr("disabled", "true");
    var query = {
        username: usernameInput.val(),
        password: passwordInput.val()
    };
    $.ajax('/api/sign-in/login', {
        type: 'post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(query),
        success: function () {
            redirect('https://' + document.location.host);
        },
        error: function (error) {
            var response = error.responseJSON;
            usernameInput.addClass("input-error");
            passwordInput.addClass("input-error");
            errorsBlock.append("<span class='error-msg'>" + response.message + "</span>");
            submitButton.removeAttr("disabled");
        }
    });
}
function redirect(url) {
    var ua = navigator.userAgent.toLowerCase(), isIE = ua.indexOf('msie') !== -1, version = parseInt(ua.substr(4, 2), 10);
    // Internet Explorer 8 and lower
    if (isIE && version < 9) {
        var link = document.createElement('a');
        link.href = url;
        document.body.appendChild(link);
        link.click();
    }
    // All other browsers can use the standard window.location.href (they don't lose HTTP_REFERER like Internet Explorer 8 & lower does)
    else {
        window.location.href = url;
    }
}
//# sourceMappingURL=login.js.map