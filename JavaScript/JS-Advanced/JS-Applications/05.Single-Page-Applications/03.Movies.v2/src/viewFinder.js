import auth from "../helpers/auth.js";
import homePage from "../pages/home.js";
import loginPage from "../pages/login.js";
import movieDetailsPage from "../pages/movieDetails.js";
import registerPage from "../pages/register.js";

let views = {
    'home': async () => await homePage.getView(), //html -> 18 row
    'login': async () => await loginPage.getView(), // -> 27 row
    'register': async () => await registerPage.getView(), // -> 30 row
    'movie-details': async (id) => await movieDetailsPage.getView(id),
    'logout': async () => await auth.logout()
};

function initialize(allLinkElements) {
    allLinkElements.forEach(link => link.addEventListener('click', changeViewHandler));
}


export async function changeViewHandler(e) {
    // data-route="..."     -> dataset.route;
    // data-route-nav="..." -> dataset.routeNav;
    let element = e.target.matches('.link')
        ? e.target
        : e.target.closest('.link');
    let route = element.dataset.route;
    let id = element.dataset.id;
    navigateTo(route, id);
}

export async function navigateTo(route, id) {
    console.log(route);
    if (views.hasOwnProperty(route)) {

        let view = await views[route](id);
        let appElement = document.getElementById('main');
        appElement.querySelectorAll('.view').forEach(v => v.remove());
        appElement.appendChild(view);
    }
}

export async function redirectTo(route) {
    if (views.hasOwnProperty(route)) {
        let viewFunc = views[route]();
        return viewFunc;
    }
}

let viewFinder = {
    initialize,
    navigateTo,
    changeViewHandler,
    redirectTo
};

export default viewFinder;