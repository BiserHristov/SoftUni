import { preloadPartials, errorHandler } from './util.js'
import { login as apiLogin, loguot, register } from './data.js'

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('./templates/register.hbs')


}

export async function registerPost(context) {

    let { email, password, repassword } = context.params

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

    firebase.auth()
        .createUserWithEmailAndPassword(email, password)
        .then(this.redirect('#/home'))
        .catch(errorHandler)

}

export async function loginPage(context) {
    await preloadPartials(context)
    this.partial('./templates/login.hbs')
}

window.loginPost = loginPost;
export async function loginPost(context) {

    let { email, password } = context.params

    let res = await apiLogin(email, password);



    let user = {
        email,
        uid: data.user.uid,
        ...res
    }


    localStorage.setItem('loggedUser', JSON.stringify(user));

    context.isLoggedIn = true


    this.redirect('#/home')

}


export function logout(context) {
    firebase.auth()
        .signOut()
        .then(() => {
            localStorage.removeItem('loggedUser')
            this.redirect('#/login')

        })
        .catch(errorHandler)
}