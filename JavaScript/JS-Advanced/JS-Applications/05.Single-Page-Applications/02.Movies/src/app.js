import { showHome } from "./home.js";
import { showLogin } from "./login.js";
import { showRegister } from "./register.js";

const views = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister

};

const nav = document.querySelector('nav');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
nav.addEventListener('click', (ev) => {
    // ev.target.tagName == 'A' -> where the user clicked
    const view = views[ev.target.id];
    if (typeof view == 'function') {
        ev.preventDefault();
        view();
    }
});

//start app
updateNav();
showHome();

export function updateNav() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        nav.querySelector('#welcomeMsg').textContent = `Welcome ${userData.email}`;
        // will return Node list -> have to transfer to Array
        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'none');
    } else {
        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'block');
    }
}

async function onLogout(ev) {
    ev.preventDefault();
    ev.stopImmediatePropagation();

    const { token } = JSON.parse(sessionStorage.getItem('userData'));

    await fetch('http://localhost:3030/users/logout', {
        headers: {
            'X-Authorization': token
        }
    });

    sessionStorage.removeItem('userData');
    updateNav();
    showHome();
}