//import { setUserData } from "./controllers/util.js";

import { getUser, objectToArray } from "./controllers/util.js"


const apiKey = "AIzaSyChmbdiHeX1HZue7rEAEyPsCiNWZFY9Exo" //CHANGE IT!

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    SHOES: 'shoes', //CHANGE IT!
    SHOE_BY_ID: 'shoes/' //CHANGE IT!
}
function getURL(endpoint) {
    let result = `https://shoesite-cb8df.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
    const user = getUser()
    if (user !== null) {
        result += `?auth=${user.idToken}`
    }
    return result;
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

export async function createApiPost(offer) {
    return await post(getURL(endpoints.SHOES), offer);

}

export async function getAllApiShoes() {
    let response = await get(getURL(endpoints.SHOES));
    return objectToArray(response)
}

export async function getApiItemById(id) {
    let response = await get(getURL(endpoints.SHOE_BY_ID + id));
    response._id = id;
    return response;
}

export async function editApiItemById(shoeId, editedShoe) {
    return await patch(getURL(endpoints.SHOE_BY_ID + shoeId), editedShoe);

}

export async function deleteItemById(shoeId) {
    return await del(getURL(endpoints.SHOE_BY_ID + shoeId));

}


