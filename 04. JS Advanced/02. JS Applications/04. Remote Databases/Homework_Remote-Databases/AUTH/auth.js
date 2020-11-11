document.querySelector('#registerBtn')
    .addEventListener('click', registerUser)

document.querySelector('#loginBtn')
    .addEventListener('click', loginUser)

document.querySelector('button.logoutBtn')
    .addEventListener('click', logoutUser)
function registerUser(e) {
    e.preventDefault();
    let emailElement = document.querySelector('#registerForm input[name="email"]')
    let passwordElement = document.querySelector('#registerForm input[name="psw"]')

    if (emailElement.value == '' || passwordElement.value == '') {
        alert('Email/password can not be empty!')
        return;
    }

    firebase.auth().createUserWithEmailAndPassword(emailElement.value, passwordElement.value)
        .then(data => {
            console.log(data)
        })
        .catch(console.error)
}

function loginUser(e) {
    e.preventDefault();
    let emailElement = document.querySelector('#loginForm input[name="email"]')
    let passwordElement = document.querySelector('#loginForm input[name="psw"]')

    if (emailElement.value == '' || passwordElement.value == '') {
        alert('Email/password can not be empty!')
        return;
    }

    firebase.auth().signInWithEmailAndPassword(emailElement.value, passwordElement.value)
        .then(data => {
            console.log(data)
        })
        .catch(console.error)
}

function logoutUser(e) {
    firebase.auth().signOut()
        .then(data => {
            console.log(data)
        })
        .catch(console.error)
}