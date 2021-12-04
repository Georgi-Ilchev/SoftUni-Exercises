export function getUserData() {
    return JSON.parse(sessionStorage.getItem('userData'));
}

export function setUserData(data) {
    sessionStorage.setItem('userData', JSON.stringify(data));
}

export function clearUserData() {
    sessionStorage.removeItem('userData');
}

export function parseQueryString(str) {
    const params = str
        .split('&')
        .map(p => p.split('='))
        .reduce((a, [k, v]) => Object.assign(a, { [k]: v }), {});

    return params;
}