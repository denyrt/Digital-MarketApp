document.addEventListener('DOMContentLoaded', () => {
    const username = document.getElementById('username');
    const usernameHelp = document.getElementById('usernameHelp');
    username.addEventListener('focus',
        () => {
            if (usernameHelp) usernameHelp.innerHTML = '';
        },
        { once: true }
    );

    const password = document.getElementById('password');
    const passwordHelp = document.getElementById('passwordHelp');
    password.addEventListener('focus',
        () => {
            if (passwordHelp) passwordHelp.innerHTML = '';
        },
        { once: true }
    );

    const checkbox = document.getElementById('rememberMe') as HTMLInputElement;
    if (checkbox) {
        if (checkbox.value == 'True') {
            checkbox.checked = true;
        }
        checkbox.addEventListener('change', (event) => {
            if (checkbox.checked) {
                checkbox.value = 'True';
            } else {
                checkbox.value = 'False'
            }
        });
    }
}, { once: true });