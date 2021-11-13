import auth from "../helpers/auth.js";
import { jsonRequest } from "../helpers/request.js";
import viewFinder from "../src/viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector('#register-form');
    form.addEventListener('submit', registerUser);
}

async function getView() {
    return section;
}

async function registerUser(e) {
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('repeatPassword');

    if (email === '' ||
        password === '' ||
        password.length < 6 ||
        password !== repeatPassword) {
        alert('Fields must not be empty and passwords must match');
    }

    let user = {
        email: email,
        password: password
    };

    const url = 'http://localhost:3030/users/register';
    let result = await jsonRequest(url, 'POST', user);

    auth.setAuthToken(result.accessToken);
    auth.setUserId(result._id);
    form.reset();
    viewFinder.navigateTo('home');
}

let registerPage = {
    initialize,
    getView
};

export default registerPage;