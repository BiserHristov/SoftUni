import{getUser, getURL} from './controllers/util.js'

const apiKey = "AIzaSyChmbdiHeX1HZue7rEAEyPsCiNWZFY9Exo"

const endpoints = {
    LOGIN: 'https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=',
    REGISTER: 'https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=',
}

async function request(url, method, body) {

    let options = {
        method,
    }

    if (body) {
        Object.assign(options, {
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(body)
        })
    }

    let data = await (await fetch(url, options)).json();
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
    let data = await post(endpoints.LOGIN + apiKey, { email, password });
    return data;
}

export async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, { email, password });
    return response
}

export async function getAllOffers() {
    return get(getURL())
}

export async function createOffer(offer) {

    return post(getURL(), offer)
}

export async function getOfferByKey(key) {
    return get(getURL(key))
}

export async function editOffer(key, updatedOffer) {
    return patch(getURL(key), updatedOffer)
}

export async function deleteOffer(key) {
    return del(getURL(key))
}

export async function buyOffer(context) {
    let key=context.params.key;
    let offer = await getOfferByKey(key);

    let updatedBuyers = []
    let currentUser = getUser().email
    if (offer.hasOwnProperty('buyers')) {
        updatedBuyers = [currentUser, ...offer.buyers]
    } else {
        updatedBuyers.push(currentUser)
    }

    let updatedBuyersObj = {
        buyers: updatedBuyers
    }

    let data = patch(getURL(key), updatedBuyersObj)
    return data;
}