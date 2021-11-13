import auth from "../helpers/auth.js";
import { jsonRequest } from "../helpers/request.js";
import viewFinder from "../src/viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector('#login-form');
    form.addEventListener('submit', loginUser);
}

async function getView() {
    return section;
}

async function loginUser(e) {
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get('email'),
        password: formData.get('password')
    };

    const url = 'http://localhost:3030/users/login';
    let result = await jsonRequest(url, 'POST', user);

    auth.setAuthToken(result.accessToken);
    auth.setUserId(result._id);
    form.reset();
    viewFinder.navigateTo('home');
}

let loginPage = {
    initialize,
    getView
};

export default loginPage;