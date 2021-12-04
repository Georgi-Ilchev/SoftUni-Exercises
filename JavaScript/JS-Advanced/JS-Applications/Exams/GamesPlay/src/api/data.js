import * as api from './api.js';

const endpoints = {
    catalog: '/data/games?sortBy=_createdOn%20desc&distinct=category', //
    allGames: '/data/games?sortBy=_createdOn%20desc', //
    create: '/data/games', //
    edit: (id) => `/data/games/${id}`, //
    details: (id) => `/data/games/${id}`, //
    delete: (id) => `/data/games/${id}`, //
    comments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
    postComments: '/data/comments'
};

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getCatalog() {
    return api.get(endpoints.catalog);
}

export async function getAllGames() {
    return api.get(endpoints.allGames);
}

export async function getGameById(id) {
    return api.get(endpoints.details(id));
}

export async function createGame(game) {
    return api.post(endpoints.create, game);
}

export async function editGame(id, game) {
    return api.put(endpoints.edit(id), game);
}

export async function deleteGame(id) {
    return api.del(endpoints.delete(id));
}

export async function getComments(id) {
    return api.get(endpoints.comments(id));
}

export async function postComment(comment) {
    return api.post(endpoints.postComments, comment);
}