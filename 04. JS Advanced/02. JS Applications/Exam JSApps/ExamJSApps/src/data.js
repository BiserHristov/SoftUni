import { getUser, objectToArray, setUserData } from "./controllers/util.js";

const apiKey = "AIzaSyBdoRPNfeBxS1Pt3_QY5pFfNjgeZZPDFsA" //CHANGE IT!

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    DEST: '/destinations', //CHANGE IT!
    DEST_BY_ID: '/destinations/' //CHANGE IT!
}
function getURL(endpoint) {
    let result = `https://examprep-myblog.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
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

export async function createApiOffer(destination) {
    return await post(getURL(destination._ownerId + endpoints.DEST), destination)
}

export async function getAllApiDestByUser(userId) {

    let response = await get(getURL(userId + endpoints.DEST))
    return objectToArray(response);
}
export async function getAllOffers() {

    let allDest = await get(getURL())
    let result = []
    if (!allDest) {
        return result;
    }
    let allUsers = Object.keys(allDest)


    for (var index = 0; index < allUsers.length; index++) {
        let response = await getAllApiDestByUser(allUsers[index])
        response.forEach(el => {
            result.push(el)
        });

    }

    return result;
}

export async function getApiOfferById(userId, destId) {

    let response = await get(getURL(userId + endpoints.DEST_BY_ID + destId))
    response._id = destId
    return response
}

export async function editApiOfferById(userId, destId, editedDest) {

    return await patch(getURL(userId + endpoints.DEST_BY_ID + destId), editedDest)

}

export async function deleteDestByOwnerAndId(ownerId, destId) {

    return await del(getURL(ownerId + endpoints.DEST_BY_ID + destId))

}
