import * as api from './api.js';

const pageSize = 4;
const endpoints = {
    all: `/data/catalog?pageSize=${pageSize}&offset=`,
    count: '/data/catalog?count',
    byId: '/data/catalog/',
    myItems: (userId) => `/data/catalog?where=_ownerId%3D%22${userId}%22`,
    countMyItems: (userId) => `/data/catalog?where=_ownerId%3D%22${userId}%22&count`,
    create: '/data/catalog',
    edit: '/data/catalog/',
    delete: '/data/catalog/',
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAll(page, search) {
    let url = endpoints.all + (page - 1) * pageSize;
    let urlSearchCount = endpoints.count;

    if (search) {
        url += '&where=' + encodeURIComponent(`make LIKE "${search}"`);
        urlSearchCount += '&where=' + encodeURIComponent(`make LIKE "${search}"`);
    }

    const [data, count] = await Promise.all([
        api.get(url),
        api.get(urlSearchCount)
    ]);

    return {
        data,
        pages: Math.ceil(count / pageSize)
    };
}

export async function getById(id) {
    return api.get(endpoints.byId + id);
}

export async function getMyItems(userId) {
    const [data, count] = await Promise.all([
        api.get(endpoints.myItems(userId)),
        api.get(endpoints.countMyItems(userId))
    ]);
    return {
        data,
        pages: Math.ceil(count / pageSize)
    };
}

export async function createItem(data) {
    return api.post(endpoints.create, data);
}

export async function editItem(id, data) {
    return api.put(endpoints.edit + id, data);
}

export async function deleteItem(id) {
    return api.del(endpoints.delete + id);
}