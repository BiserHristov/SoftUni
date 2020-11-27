
export async function preloadPartials(context) {


    // const partials = await Promise.all([
    //     context.load('./templates/common/header.hbs'),
    //     context.load('./templates/common/footer.hbs')
    // ])

    context.partials = {
        header: await context.load('./templates/common/header.hbs'),
        footer: await context.load('./templates/common/footer.hbs')
    }

}

export function getURL(endpoint) {
    let result = `https://shoesite-cb8df.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
    return result;
}

// export function takeExistingUser(email) {
//     return JSON.parse(localStorage.usersInfo).find(u => u.email == email)
// }

export function getUser() {

    const loggedUser = localStorage.getItem('loggedUser')

    return loggedUser ? JSON.parse(loggedUser) : null;

    // if (localStorage.loggedUser) {
    //     let user = JSON.parse(localStorage.loggedUser)
    //     context.isLoggedIn = true;
    //     context.email = user.email;
    //     context.uid = user.uid
    // }
    // else {
    //     context.isLoggedIn = false;

    // }


}

export function errorHandler(error) {
    console.log(error)
}
