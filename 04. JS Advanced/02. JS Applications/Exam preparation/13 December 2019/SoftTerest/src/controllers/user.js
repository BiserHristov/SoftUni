import { getAllApiIdeasByUser, login, register } from "../data.js"
import { showError, showInfo } from "../notification.js"
import { errorHandler, getUser, preloadPartials, setUserData } from "./util.js"

export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('/templates/register.hbs')


}

export async function registerPost(context) {

    let { username, password, repeatPassword } = context.params

    try {
        if (username.length < 3 ||
            password.length < 3) {
            throw new Error("username/password should be at least 3 characters long")

        }

        if (password != repeatPassword) {
            throw new Error("Password and Repeatpassword does not match!")
        }



        let response = await register(username, password)
        setUserData(response);
        showInfo("User registration successful")
        context.redirect('/home')
    } catch (error) {
        showError(error.message)
        context.redirect('/register')
    }

}

export async function loginPage(context) {
    await preloadPartials(context)
    this.partial('/templates/login.hbs')
}

export async function loginPost(context) {

    let { username, password } = context.params

    try {
        if (username == '' || password == '') {
            throw new Error("All fields are required")
        }

        let response = await login(username, password)
        setUserData(response);
        document.querySelector('#inputUsername').value = ''
        document.querySelector('#inputPassword').value = ''


        showInfo("Login successful.")
        context.redirect('/home')
    } catch (error) {
        showError(error.message)
    }

}


export function logout(context) {

    localStorage.removeItem('loggedUser')
    showInfo("Logout successful.")
    this.redirect('/home')
}

export async function profilePage(context) {
    let allIdeas = await getAllApiIdeasByUser(getUser().localId)
    if (allIdeas.length > 0) {
        context.hasIdeas = true;
        context.ideas = allIdeas.map(i => i.title);
    }
    context.ideasCount = allIdeas.length


    Object.assign(context, getUser())
    await preloadPartials(context)
    this.partial('/templates/profile.hbs')
}

