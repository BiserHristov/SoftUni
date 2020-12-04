import { login, register } from "../data.js"
import { errorHandler, preloadPartials, setUserData } from "./util.js"

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('/templates/register.hbs')


}

export async function registerPost(context) {

    let { email, password, repassword } = context.params

    try {
        if (email == '' ||
            password == '' ||
            repassword == '') {
            throw new Error("All fields are required")

        }

        if (password.length < 6) {
            throw new Error("Password should be at least 6 characters long!")

        }

        if (password != repassword) {
            throw new Error("Password and Repeatpassword does not match!")
        }



        let response = await register(email, password)
        setUserData(response);
        context.redirect('/home')
    } catch (error) {
        errorHandler(error)
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
        if (password.length < 6) {
            throw new Error("Password should be at least 6 characters long!")
        }

        let response = await login(email, password)
        setUserData(response);
        context.redirect('/home')
    } catch (error) {
        errorHandler(error)
    }

}


export function logout(context) {

    localStorage.removeItem('loggedUser')
    this.redirect('/login')
}


