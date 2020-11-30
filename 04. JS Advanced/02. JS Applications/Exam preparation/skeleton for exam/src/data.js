import { setUserData } from "./controllers/util.js";

const apiKey = "AIzaSyAu7gY4-oLHC2It1xtm604sFUHD2pukv7o" //CHANGE IT!

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    SHOES: 'shoes', //CHANGE IT!
    SHOE_BY_ID: 'shoes/' //CHANGE IT!
}

async function request(url, method, body) {

    let options = {
        method,
    }

    if (body) {
        Object.assign(options, {
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(body)
        })
    }

    let data = await (await fetch(url, options)).json();

    if (data && data.hasOwnProperty('error')) {
        throw new Error(data.error.message)
    }

    return data;
}

async function get(url) {
    return request(url, 'GET')
}

async function post(url, body) {
    return request(url, 'POST', body)
}

async function del(url) {
    return request(url, 'DELETE')
}

async function patch(url, body) {
    return request(url, 'PATCH', body)
}

export async function login(email, password) {
    return await post(endpoints.LOGIN + apiKey, { email, password, returnSecureToken: true });

}

window.login = login;

export async function register(email, password) {
    return await post(endpoints.REGISTER + apiKey, { email, password, returnSecureToken: true });

}
window.register = register;