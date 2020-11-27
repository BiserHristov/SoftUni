
const apiKey = "AIzaSyChmbdiHeX1HZue7rEAEyPsCiNWZFY9Exo"
const databaseURL = "https://shoesite-cb8df.firebaseio.com/"

const endpoints = {
    LOGIN: 'https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=',
    REGISTER: 'https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=',
    ALL_SHOES: '.json'
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
    let response = await post(endpoints.LOGIN + apiKey, { email, password });

    let data = await response.json();
    localStorage.setItem('auth', JSON.stringify(data)); //duplicate ?
    return data;
}

export async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, { email, password });
    localStorage.setItem('auth', JSON.stringify(response)); //duplicate ?
    return response
}

// window.login = login;
// window.register = register;

export async function getAllOffers() {
    return get(databaseURL + endpoints.ALL_SHOES)
}

//window.getAllShoes = getAllOffers;

export async function createOffer(offer) {

    return post(databaseURL + endpoints.ALL_SHOES, offer)
}
//window.createOffer = createOffer;

export async function getOfferByKey(key) {


    return get(databaseURL + key + endpoints.ALL_SHOES)
}
//window.getOfferByKey = getOfferByKey;

//edit offer
export async function editOffer(key, updatedOffer) {
    return patch(databaseURL + key + endpoints.ALL_SHOES, updatedOffer)
}
//window.editOffer = editOffer;
//Delete offer
export async function deleteOffer(key) {
    return del(databaseURL + key + endpoints.ALL_SHOES)
}
//window.deleteOffer=deleteOffer


//Buy shoe