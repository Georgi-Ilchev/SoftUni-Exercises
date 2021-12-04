import * as api from './api.js';

const endpoints = {
    home: '/data/wiki?sortBy=_createdOn%20desc&distinct=category',
    catalog: '/data/wiki?sortBy=_createdOn%20desc',
    create: '/data/wiki',
    edit: (id) => `/data/wiki/${id}`,
    delete: (id) => `/data/wiki/${id}`,
    details: (id) => `/data/wiki/${id}`,
    search: (query) => `/data/wiki?where=title%20LIKE%20%22${query}%22`
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getCatalog() {
    return api.get(endpoints.catalog);
}

export async function getRecentResouce() {
    return api.get(endpoints.home);
}

export async function getResourceById(id) {
    return api.get(endpoints.details(id));
}

export async function createResource(resource) {
    return api.post(endpoints.create, resource);
}

export async function editResource(id, resource) {
    return api.put(endpoints.edit(id), resource);
}

export async function deleteResource(id) {
    return api.del(endpoints.delete(id));
}

export async function searchResource(query) {
    return api.get(endpoints.search(query));
}