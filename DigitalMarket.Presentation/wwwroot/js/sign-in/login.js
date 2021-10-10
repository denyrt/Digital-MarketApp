document.addEventListener('DOMContentLoaded', function () {
    var username = document.getElementById('username');
    var usernameHelp = document.getElementById('usernameHelp');
    console.log(username);
    username.addEventListener('focus', function () {
        if (usernameHelp)
            usernameHelp.innerHTML = '';
    }, { once: true });
    var password = document.getElementById('password');
    var passwordHelp = document.getElementById('passwordHelp');
    password.addEventListener('focus', function () {
        if (passwordHelp)
            passwordHelp.innerHTML = '';
    }, { once: true });
    var checkbox = document.getElementById('rememberMe');
    if (checkbox) {
        if (checkbox.value == 'True') {
            checkbox.checked = true;
        }
        checkbox.addEventListener('change', function (event) {
            if (checkbox.checked) {
                checkbox.value = 'True';
            }
            else {
                checkbox.value = 'False';
            }
        });
    }
}, { once: true });
//# sourceMappingURL=login.js.map