import { clearUserData, getUserData, setUserData } from "../util.js";
import { notify } from "../notify.js";

const host = 'http://localhost:3030';

async function request(url, options) {
    try {
        const response = await fetch(host + url, options);

        if (response.ok != true) {
            if (response.status == 403) {
                clearUserData();
            }
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            return await response.json();
        } catch (err) {
            return response;
        }

    } catch (err) {
        // alert(err.message);
        notify(err.message);
        throw err;
    }
}

function createOptions(method = 'GET', data) {
    const options = {
        method,
        headers: {}
    };

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = getUserData();

    if (userData != null) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('POST', data));
}

export async function put(url, data) {
    return request(url, createOptions('PUT', data));
}

export async function del(url) {
    return request(url, createOptions('DELETE'));
}

export async function login(email, password) {
    const result = await post('/users/login', { email, password });

    const userData = {
        username: result.username,
        email: result.email,
        id: result._id,
        gender: result.gender,
        token: result.accessToken
    };

    setUserData(userData);
}

export async function register(username, email, password, gender) {
    const result = await post('/users/register', { username, email, password, gender });

    const userData = {
        username: result.username,
        email: result.email,
        id: result._id,
        gender: result.gender,
        token: result.accessToken
    };

    setUserData(userData);
}

export async function logout() {
    get('/users/logout');
    clearUserData();
}