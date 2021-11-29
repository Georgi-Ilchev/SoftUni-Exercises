import { login } from '../api/data.js';
import { html } from '../lib.js';

const loginTemplate = (onSubmit) => html`
<section id="login">
    <div class="container">
        <form @submit=${onSubmit} id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>
            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">
            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`;

export function loginPage(ctx) {
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        const username = formData.get('username').trim();
        const password = formData.get('password').trim();

        if (username == '' || password == '') {
            return alert('All fields are required!');
        }

        await login(username, password);
        ctx.updateUserNav();
        ctx.page.redirect('/');
    }
}