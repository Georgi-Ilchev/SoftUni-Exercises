window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('#register-view #register');
    form.addEventListener('submit', onRegisterHandler);
})

async function onRegisterHandler(e) {
    e.preventDefault();

    const url = `http://localhost:3030/users/register`;
    const formData = new FormData(e.target);
    const notification = document.querySelector('.notification');
    notification.textContent = '';

    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (password !== rePass) {
        p.textContent = "Passwords doen't match";
        return;
    }

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
            throw new Error(result.message);
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