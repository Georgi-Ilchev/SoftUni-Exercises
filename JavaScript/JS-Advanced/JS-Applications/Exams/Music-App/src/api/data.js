import * as api from './api.js';

const endpoints = {
    catalog: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/albums',
    edit: (id) => `/data/albums/${id}`,
    details: (id) => `/data/albums/${id}`,
    delete: (id) => `/data/albums/${id}`,
    search: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllAlbums() {
    return api.get(endpoints.catalog);
}

export async function getAlbumById(id) {
    return api.get(endpoints.details(id));
}

export async function searchAlbum(query) {
    return api.get(endpoints.search(query));
}

export async function createAlbum(album) {
    return api.post(endpoints.create, album);
}

export async function editAlbum(id, album) {
    return api.put(endpoints.edit(id), album);
}

export async function deleteAlbum(id) {
    return api.del(endpoints.delete(id));
}