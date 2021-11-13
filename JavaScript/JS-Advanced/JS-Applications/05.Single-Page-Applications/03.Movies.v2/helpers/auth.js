import viewFinder from "../src/viewFinder.js";
import { jsonRequest } from "./request.js";

export function setAuthToken(token) {
    localStorage.setItem('authToken', token);
}

export function getAuthToken() {
    return localStorage.getItem('authToken');
}

export function getUserId() {
    return localStorage.getItem('userId');
}

export function setUserId(userId) {
    localStorage.setItem('userId', userId);
}

export function isLoggedIn() {
    return localStorage.getItem('authToken') !== null &&
        localStorage.getItem('authToken') !== undefined;
}

export async function logout() {
    let result = await jsonRequest('http://localhost:3030/users/logout', 'GET', undefined, true, true);
    localStorage.clear();
    return viewFinder.redirectTo('login');
}

let auth = {
    setAuthToken,
    getAuthToken,
    isLoggedIn,
    logout,
    getUserId,
    setUserId
};

export default auth;