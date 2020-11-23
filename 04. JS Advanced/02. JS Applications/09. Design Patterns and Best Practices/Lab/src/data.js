
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

async function login(email, password) {
    let response = await post(endpoints.LOGIN + apiKey, { email, password });

    let data = await response.json();
    localStorage.setItem('auth', JSON.stringify(data)); //duplicate ?
    return data;
}

async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, { email, password });
    localStorage.setItem('auth', JSON.stringify(response)); //duplicate ?
    return response
}

window.login = login;
window.register = register;

async function getAllOffers() {
    return get(databaseURL + endpoints.ALL_SHOES)
}

window.getAllShoes = getAllOffers;

async function createOffer() {

    let offer = {
        model: 'Testmodel',
        price: 111,
        imgURL: '',
        description: 'testdesc',
        brand: 'testbrand',
        owner: 'testOwner',
        buyers: []
    }

    return post(databaseURL + endpoints.ALL_SHOES, offer)
}

window.createOffer = createOffer;