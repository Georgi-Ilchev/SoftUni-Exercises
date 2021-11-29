import { logout } from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';

import { homePage } from "./views/home.js";
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { createPage } from './views/create.js';
import { allCarsPage } from './views/all-cars.js';
import { myCarsPage } from './views/my-cars.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { searchPage } from './views/search.js';

const root = document.getElementById('site-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/all-cars', allCarsPage);
page('/my-cars', myCarsPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/search', searchPage);

updateUserNav();
page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;
    next();
}

function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}

function updateUserNav() {
    const userData = getUserData();

    if (userData) {
        document.getElementById('profile').style.display = 'block';
        document.getElementById('guest').style.display = 'none';
        document.querySelector('#profile a').textContent = `Welcome, ${userData.username}`;
    } else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}