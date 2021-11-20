import { html, render } from '../node_modules/lit-html/lit-html.js';
import { until } from '../node_modules/lit-html/directives/until.js';

const host = 'http://localhost:3030/jsonstore/collections';

async function request(url, method = 'GET', data) {
    const options = {
        method,
        headers: {}
    };

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const response = await fetch(host + url, options);

    if (response.ok != true) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    return response.json();
}

async function getBooks() {
    return request('/books');
}

async function getBookById(id) {
    return request('/books/' + id);
}

async function createBook(book) {
    return request('/books', 'POST', book);
}

async function updateBook(id, book) {
    return request('/books/' + id, 'PUT', book);
}

async function deleteBook(id) {
    return request('/books/' + id, 'DELETE');
}

export {
    html,
    render,
    until,
    getBooks,
    getBookById,
    createBook,
    updateBook,
    deleteBook
};