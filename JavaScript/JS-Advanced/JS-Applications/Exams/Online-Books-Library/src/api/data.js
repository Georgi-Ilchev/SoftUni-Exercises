import * as api from './api.js';

const endpoints = {
    catalog: '/data/books?sortBy=_createdOn%20desc',
    create: '/data/books',
    like: '/data/likes',
    edit: (id) => `/data/books/${id}`,
    details: (id) => `/data/books/${id}`,
    delete: (id) => `/data/books/${id}`,
    profile: (id) => `/data/books?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`,
    total: (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    own: (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllBooks() {
    return api.get(endpoints.catalog);
}

export async function getBookById(id) {
    return api.get(endpoints.details(id));
}

export async function getMyBooks(userId) {
    return api.get(endpoints.profile(userId));
}

export async function createBook(book) {
    return api.post(endpoints.create, book);
}

export async function editBook(id, book) {
    return api.put(endpoints.edit(id), book);
}

export async function deleteBook(id) {
    return api.del(endpoints.delete(id));
}

export async function likeBook(bookId) {
    return api.post(endpoints.like, {
        bookId
    });
}

export async function getLikesByBookId(bookId) {
    return api.get(endpoints.total(bookId));
}

export async function getOwnLikesByBookId(bookId, userId) {
    return api.get(endpoints.own(bookId, userId));
}