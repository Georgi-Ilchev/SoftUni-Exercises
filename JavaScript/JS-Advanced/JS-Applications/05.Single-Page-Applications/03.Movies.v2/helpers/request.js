import auth from "./auth.js";

export async function jsonRequest(url, method, body, isAuthorized, skipResult) {
    try {
        if (method === undefined) {
            method = 'GET';
        }

        let headers = {};
        if (['post', 'put', 'patch'].includes(method.toLowerCase())) {
            headers['Content-Type'] = 'application/json';
        }

        if (isAuthorized) {
            headers['X-Authorization'] = auth.getAuthToken();

        }

        let options = {
            method,
            headers
        };

        if (body !== undefined) {
            options.body = JSON.stringify(body);
        }


        let response = await fetch(url, options);
        if (response.ok != true) {
            let message = await response.text();
            throw new Error(`${response.status}: ${response.statusText}\n${message}`);
        }

        let result = undefined;
        if (!skipResult) {
            result = await response.json();
        }

        return result;
    } catch (err) {
        alert(err);
    }
}