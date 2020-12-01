import { getURL, objectToArray, setUserData } from "./controllers/util.js";

const apiKey = "AIzaSyBdoRPNfeBxS1Pt3_QY5pFfNjgeZZPDFsA" //CHANGE IT!

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    IDEAS: '/ideas', //CHANGE IT!
    IDEA_BY_ID: '/ideas/' //CHANGE IT!
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


export async function createApiIdea(userIdea) {
    return await post(getURL(userIdea._ownerId + endpoints.IDEAS), userIdea)
}
export async function getAllApiIdeasByUser(userId) {

    let response = await get(getURL(userId + endpoints.IDEAS))
    return objectToArray(response);
}

export async function getAllApiIdeas() {

    let allIdeas = await get(getURL())

    let allUsers = Object.keys(allIdeas)
    let result = []

    for (var index = 0; index < allUsers.length; index++) {
        let response = await getAllApiIdeasByUser(allUsers[index])
        response.forEach(el => {
            result.push(el)
        });

    }

    return result;

}
export async function getApiIdeaById(userId, ideaId) {

    let response = await get(getURL(userId + endpoints.IDEA_BY_ID + ideaId))
    response._id = ideaId;
    response.comments = response.comments || []
    return response;
}

export async function updateApiIdeaByOwnerAndId(userId, ideaId, editedIdea) {

    return await patch(getURL(userId + endpoints.IDEA_BY_ID + ideaId), editedIdea)

}

export async function deleteIdeaByOwnerAndId(ownerId,ideaId) {

    return await del(getURL(ownerId + endpoints.IDEA_BY_ID + ideaId))

}
