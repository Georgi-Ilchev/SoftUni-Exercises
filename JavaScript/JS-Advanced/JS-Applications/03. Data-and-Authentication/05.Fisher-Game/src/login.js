window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('#login-view #login');
    form.addEventListener('submit', onLoginHandler);
})

async function onLoginHandler(e) {
    e.preventDefault();

    const url = `http://localhost:3030/users/login`;
    const formData = new FormData(e.target);
    const notification = document.querySelector('.notification');
    notification.textContent = '';

    const email = formData.get('email');
    const password = formData.get('password');

    const body = JSON.stringify({
        email,
        password
    });

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body
        });

        const result = await response.json();

        if (response.ok != true) {
            const message = result.message
                .split('Login')
                .filter(x => x !== '')
                .map(x => 'Email' + x);

            throw new Error(message);

            // const error = await response.json();
            // throw new Error(error.message);
        }

        const userData = {
            email: result.email,
            id: result._id,
            token: result.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));
        window.location = '/index.html';
    } catch (error) {
        notification.textContent = error.message;
    }
}