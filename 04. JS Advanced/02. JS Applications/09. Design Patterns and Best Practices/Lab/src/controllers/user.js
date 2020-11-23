import { preloadPartials, errorHandler } from './util.js'


export async function registerPage(context) {

    await preloadPartials(context)
    this.partial('./templates/register.hbs')


}

export function registerPost(context) {

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

export function logout(context) {
    firebase.auth()
        .signOut()
        .then(() => {
            localStorage.removeItem('loggedUser')
            this.redirect('#/login')

        })
        .catch(errorHandler)
}

export function loginPost(context) {

    let { email, password } = context.params

    firebase.auth()
        .signInWithEmailAndPassword(email, password)
        .then(data => {

            let user = {
                email,
                uid: data.user.uid
            }


            localStorage.setItem('loggedUser', JSON.stringify(user));



            // if (!localStorage.usersInfo) {
            //     const users = []
            //     users.push(user);
            //     localStorage.setItem('usersInfo', JSON.stringify(users));
            //     localStorage.setItem('loggedUser', JSON.stringify(user));

            // } else {

            //     let existingUser = takeExistingUser(email)

            //     if (!existingUser) {

            //         let updatedInfoArr = JSON.parse(localStorage.usersInfo)
            //         updatedInfoArr.push(user);
            //         localStorage.usersInfo = JSON.stringify(updatedInfoArr)

            //         localStorage.setItem('loggedUser', JSON.stringify(user));

            //     }
            //     else (
            //         localStorage.setItem('loggedUser', JSON.stringify(existingUser))

            //     )
            // }
            this.redirect('#/home')
        })
        .catch(errorHandler)

    context.isLoggedIn = true

}