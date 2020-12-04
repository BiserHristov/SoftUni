export async function preloadPartials(context) {

    const partials = await Promise.all([
        context.load('/templates/common/header.hbs'),
        context.load('/templates/common/footer.hbs')
    ])
    context.partials = {
        header: partials[0],
        footer: partials[1]
    }

}

export function setUserData(data) {
    data.isLoggedIn = true;
    localStorage.setItem('loggedUser', JSON.stringify(data))
}

export function objectToArray(data) {
    if (data === null) {
        return []
    } else {
        return Object.entries(data).map(([key, value]) => {

            //value.buyers = value.buyers || [] //CHECK IF I NEED THAT!!!!
            return Object.assign({ _id: key }, value)
        })
    }
}



export function getUser() {

    const loggedUser = localStorage.getItem('loggedUser')

    return loggedUser ? JSON.parse(loggedUser) : null;

}

export function errorHandler(error) {
    console.log(error)
}

export function checkForError(response) {

    if (response.hasOwnProperty('error')) {

        throw new Error(response.error.message)
    }
}