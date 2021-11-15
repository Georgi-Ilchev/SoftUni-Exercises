import { login } from '../api/data.js';

const section = document.getElementById('loginPage');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onLogin);
let ctx = null;

// section.remove();

export async function showLoginPage(ctxTarget) {
    ctx = ctxTarget;
    ctx.showSection(section);
}

async function onLogin(ev) {
    ev.preventDefault();
    const formData = new FormData(form);
    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    await login(email, password);
    form.reset();
    ctx.goTo('home');
    ctx.updateNav();
}