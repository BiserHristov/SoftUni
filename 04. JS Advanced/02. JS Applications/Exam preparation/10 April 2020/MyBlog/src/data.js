import { getURL, objectToArray, setUserData } from "./controllers/util.js";

const apiKey = "AIzaSyAgkHlyFFctB1eUQMtzWZS1qZgjsn9TM7k"
const baseURL = 'https://employees-5a4ef.firebaseio.com/'
const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    POSTS: '/posts', //CHANGE IT!
    POST_BY_ID: '/posts/' //CHANGE IT!
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

export async function createApiPost(userPost) {
    return await post(getURL(userPost._ownerId + endpoints.POSTS), userPost)
}

export async function getAllApiPostsByUser(userId) {

    let response = await get(getURL(userId + endpoints.POSTS))
    return objectToArray(response);
}

export async function getApiPostById(userId,postId) {

    let response= await get(getURL(userId + endpoints.POST_BY_ID + postId))
    response._id=postId;
    return response;
}

export async function editApiPostById(userId,postId, editedPost) {

    return await patch(getURL(userId + endpoints.POST_BY_ID + postId), editedPost)
    
}

export async function deletePostById(userId,postId) {

    return await del(getURL(userId + endpoints.POST_BY_ID + postId))
    
}

