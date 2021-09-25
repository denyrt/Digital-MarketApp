import * as $ from "jquery";
import { LoginQuery } from "../../models/login-query";
import { LoginResponse } from "../../models/login-response";

function login(): void
{
    let usernameInput = $('#username');
    let passwordInput = $('#password');
    let errorsBlock = $('#errorsBlock');
    let submitButton = $('#submit');

    usernameInput.removeClass("input-error");
    passwordInput.removeClass("input-error");
    errorsBlock.empty();
    submitButton.attr("disabled", "true");

    let query: LoginQuery =
    {
        username: usernameInput.val() as string,
        password: passwordInput.val() as string
    };
    
    $.ajax('/api/sign-in/login', {
        type: 'post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(query),
        success: () => {
            redirect('https://' + document.location.host);
        },
        
        error: (error) => {
            let response = error.responseJSON as LoginResponse;
            usernameInput.addClass("input-error");
            passwordInput.addClass("input-error");
            errorsBlock.append(`<span class='error-msg'>${response.message}</span>`);
            submitButton.removeAttr("disabled");
        }
    });
}

function redirect(url: string): void {
    let ua = navigator.userAgent.toLowerCase(),
        isIE = ua.indexOf('msie') !== -1,
        version = parseInt(ua.substr(4, 2), 10);

    // Internet Explorer 8 and lower
    if (isIE && version < 9) {
        let link = document.createElement('a');
        link.href = url;
        document.body.appendChild(link);
        link.click();
    }

    // All other browsers can use the standard window.location.href (they don't lose HTTP_REFERER like Internet Explorer 8 & lower does)
    else {
        window.location.href = url;
    }
}