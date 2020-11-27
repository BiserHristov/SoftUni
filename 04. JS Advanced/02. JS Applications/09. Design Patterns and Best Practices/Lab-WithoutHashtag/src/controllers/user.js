import { preloadPartials, checkForError, errorHandler } from './util.js'
import { login, register } from '../data.js'

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('templates/register.hbs')


}

export async function registerPost(context) {

    let { email, password, repassword } = this.params

    if (email == '' ||
        password == '' ||
        repassword == '') {
        alert("All fields are required")
        return
    }

    if (password.length < 6) {
        alert("Password should be at least 6 characters long!")
        return
    }
    if (password != repassword) {
        alert("Repeat Password does not match!")
        return
    }

    try {
        let response = await register(email, password)

        checkForError(response)

        let user = {
            email: response.email,
            uid: response.idToken
        }

        localStorage.setItem('loggedUser', JSON.stringify(user));
        this.app.userData.email = user.email;
        this.app.userData.uid = user.uid;
        this.app.userData.isLoggedIn = true;

        this.redirect('/home')
    } catch (error) {
        errorHandler(error)
    }



}


export async function loginPost(context) {
    let { email, password } = this.params

    try {
        let response = await login(email, password)

        checkForError(response)

        let user = {
            email: response.email,
            uid: response.idToken
        }

        localStorage.setItem('loggedUser', JSON.stringify(user));
        this.app.userData.email = user.email;
        this.app.userData.uid = user.uid;
        this.app.userData.isLoggedIn = true;

        this.redirect('/home')
    } catch (err) {
        errorHandler(err)
    }


}

export async function loginPage(context) {
    await preloadPartials(context)
    this.partial('templates/login.hbs')
}

export function logout(context) {

    localStorage.removeItem('loggedUser')
    this.app.userData = {};
    this.redirect('/login')
}


