import * as api from './api.js';

const endpoints = {
    catalog: '/data/cars?sortBy=_createdOn%20desc',//
    create: '/data/cars',//
    edit: (id) => `/data/cars/${id}`,//
    details: (id) => `/data/cars/${id}`,//
    delete: (id) => `/data/cars/${id}`,//
    profile: (id) => `/data/cars?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`,//
    search: (query) => `/data/cars?where=year%3D${query}`
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllCars() {
    return api.get(endpoints.catalog);
}

export async function getMyCars(userId) {
    return api.get(endpoints.profile(userId));
}

export async function getCarById(id) {
    return api.get(endpoints.details(id));
}

export async function createCar(car) {
    return api.post(endpoints.create, car);
}

export async function editCar(id, car) {
    return api.put(endpoints.edit(id), car);
}

export async function deleteCar(id) {
    return api.del(endpoints.delete(id));
}

export async function searchCar(query) {
    return api.get(endpoints.search(query));
}