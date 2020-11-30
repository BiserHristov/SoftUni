import { login, register } from "../data.js"
import { showError, showInfo } from "../notification.js"
import { errorHandler, preloadPartials, setUserData } from "./util.js"

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('/templates/register.hbs')


}

export async function registerPost(context) {

    let { email, password, repeatPassword } = context.params

    try {
        if (email == '' ||
            password == '' ||
            repeatPassword == '') {
            throw new Error("All fields are required")

        }

        if (password.length < 6) {
            throw new Error("Password should be at least 6 characters long!")

        }

        if (password != repeatPassword) {
            throw new Error("Password and Repeatpassword does not match!")
        }



        let response = await register(email, password)

        showInfo('Sucessfully registered!')
        // setUserData(response);
        context.redirect('/login')
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
        if (password.length < 6) {
            throw new Error("Password should be at least 6 characters long!")
        }

        let response = await login(email, password)
        setUserData(response);
        showInfo('Sucessfully logged in')
        context.redirect('/home')
    } catch (error) {
        showError(error.message)
    }

}


export function logout(context) {
    try {

        localStorage.removeItem('loggedUser')
        showInfo('Sucessfully logged out')
        this.redirect('/home')
    } catch (error) {
        showError(error.message)
    }
}


