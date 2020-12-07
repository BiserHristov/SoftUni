import { login, register } from "../data.js"
import { hideLoading, showError, showInfo, showLoading } from "../notification.js"
import { errorHandler, preloadPartials, setUserData } from "./util.js"

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('/templates/register.hbs')


}

export async function registerPost(context) {

    let { email, password, rePassword } = context.params

    try {
        if (email == '' ||
            password == '' ||
            rePassword == '') {
            throw new Error("All fields are required")

        }

        if (password != rePassword) {
            throw new Error("Password and Repeatpassword does not match!")
        }

        showLoading();

        let response = await register(email, password)
        hideLoading();
        setUserData(response);
        document.querySelector('#email').textContent = ''
        document.querySelector('#password').textContent = ''
        document.querySelector('#rePassword').textContent = ''
        showInfo('User registration successful.')
        context.redirect('/home')
    } catch (error) {
        showError(error.message)
    }

}

export async function loginPage(context) {
    await preloadPartials(context)
    this.partial('/templates/login.hbs')
}

export async function loginPost(context) {

    let { email, password } = context.params

    try {
        if (email == '' || password == '') {
            throw new Error("All fields are required")
        }
        showLoading();
        let response = await login(email, password)
        hideLoading();
        setUserData(response);
        document.querySelector('#email').textContent = ''
        document.querySelector('#password').textContent = ''
        showInfo('Login successful.')
        context.redirect('/home')
    } catch (error) {
        showError(error.message)
    }

}


export function logout(context) {

    localStorage.removeItem('loggedUser')
    showInfo('Logout successful.')
    this.redirect('/login')
}


