const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');


    //Home
    this.get('/home', function (context) {

        fetch(getURL())
            .then(response => response.json())
            .then(data => {

                data = data || {}

                context.shoes = []

                Object.entries(data).forEach(([key, value]) => {
                    let { model, price, imgURL, description, brand, buyers } = value

                    let shoe = {
                        key,
                        model,
                        price,
                        imgURL,
                        description,
                        brand,
                        buyers: buyers || []

                    }

                    context.shoes.push(shoe)

                });


                context.shoes = context.shoes.sort((curr, next) => next.buyers.length - curr.buyers.length)

                preloadPartials(context)
                    .then(function () {
                        this.partial('./templates/home.hbs')
                    })

            })
            .catch(errorHandler)


    })
    this.get('/home/:key', function (context) {
        let key = context.params.key
        fetch(getURL(key))
            .then(response => response.json())
            .then(data => {
                let { brand, model, imgURL, description, price, buyers } = data
                context.brand = brand
                context.model = model
                context.imgURL = imgURL
                context.description = description
                context.price = price
                context.key = key
                context.count = (buyers || []).length
                context.isOwner = data.owner == JSON.parse(localStorage.loggedUser).email


                context.notBought = true;

                if (data.buyers) {
                    context.notBought = !data.buyers.some(b => b == JSON.parse(localStorage.loggedUser).email)
                }

                preloadPartials(context)
                    .then(function () {
                        this.partial('./templates/details.hbs')

                    })
            })
            .catch(errorHandler)



    })



    //Create-offer
    this.get('/create-offer', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/create-offer.hbs')

            })
    })

    this.post('/create-offer', function (context) {

        let { model, price, imgURL, description, brand } = context.params

        if (model == '' ||
            price == '' ||
            imgURL == '' ||
            description == '' ||
            brand == '') {
            alert("All fields are required")
            return
        }

        let offer = {
            model,
            price,
            imgURL,
            description,
            brand,
            owner: JSON.parse(localStorage.loggedUser).email,
            buyers: []
        }

        fetch(getURL(), { method: 'POST', body: JSON.stringify(offer) })
            .then(response => response.json())
            .then(data => {
                this.redirect('#/home')
            })
            .catch(errorHandler)
    })

    // Details
    this.get('/details', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/details.hbs')

            })
    })



    //Edit
    this.get('/edit/:key', function (context) {
        context.key = context.params.key

        fetch(getURL(context.params.key))
            .then(res => res.json())
            .then(data => {
                context.brand = data.brand
                context.model = data.model
                context.imgURL = data.imgURL
                context.description = data.description
                context.price = data.price

                preloadPartials(context)
                    .then(function () {
                        this.partial('./templates/edit.hbs')

                    })

            })
            .catch(errorHandler)



    })

    this.post('/edit/:key', function (context) {

        const { model, price, imgURL, description, brand } = context.params
        let editedOffer = {
            model,
            price,
            imgURL,
            description,
            brand
        }

        fetch(getURL(context.params.key), { method: 'PATCH', body: JSON.stringify(editedOffer) })
            .then(res => res.json())
            .then(data => {
                this.redirect(`#/home/${context.params.key}`)
            })
            .catch(errorHandler)
    })


    //Buy
    this.get('/buy/:key', function (context) {
        let key = context.params.key

        fetch(getURL(key))
            .then(response => response.json())
            .then(data => {

                let updatedBuyers = []
                let currentUser = JSON.parse(localStorage.loggedUser).email
                if (data.hasOwnProperty('buyers')) {
                    updatedBuyers = [currentUser, ...data.buyers]
                } else {
                    updatedBuyers.push(currentUser)
                }

                let updatedBuyersObj = {
                    buyers: updatedBuyers
                }

                fetch(getURL(key), { method: 'PATCH', body: JSON.stringify(updatedBuyersObj) })
                    .then(response => response.json())
                    .then(data => {


                        this.redirect(`#/home/${key}`)


                    })
                    .catch(errorHandler)
            })

    })


    //Delete
    this.get('/delete/:key', function (context) {
        let key = context.params.key

        fetch(getURL(key), { method: 'DELETE' })
            .then(response => response.json())
            .then(data => {
                this.redirect(`#/home`)
            })
            .catch(errorHandler)


    })





    //Register
    this.get('/register', function (context) {

        preloadPartials(context)
            .then(function () {
                this.partial('./templates/register.hbs')

            })
    })

    this.post('/register', function (context) {

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

    })





    //LogIn
    this.get('/login', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/login.hbs')

            })
    })

    this.post('/login', function (context) {

        let { email, password } = context.params

        firebase.auth()
            .signInWithEmailAndPassword(email, password)
            .then(data => {

                let user = {
                    email,
                    uid: data.user.uid
                }

                if (!localStorage.usersInfo) {
                    const users = []
                    users.push(user);
                    localStorage.setItem('usersInfo', JSON.stringify(users));
                    localStorage.setItem('loggedUser', JSON.stringify(user));

                } else {

                    let existingUser = takeExistingUser(email)

                    if (!existingUser) {

                        let updatedInfoArr = JSON.parse(localStorage.usersInfo)
                        updatedInfoArr.push(user);
                        localStorage.usersInfo = JSON.stringify(updatedInfoArr)

                        localStorage.setItem('loggedUser', JSON.stringify(user));

                    }
                    else (
                        localStorage.setItem('loggedUser', JSON.stringify(existingUser))

                    )
                }
                this.redirect('#/home')
            }
            )
            .catch(errorHandler)

        context.isLoggedIn = true

    })


    //Logout
    this.get('/logout', function (context) {
        firebase.auth()
            .signOut()
            .then(() => {

                localStorage.removeItem('loggedUser')
                this.redirect('#/login')

            })
            .catch(errorHandler)
    })



});

(() => {
    app.run('#/home')
})()

function preloadPartials(context) {

    validateLoggedUser(context);

    return context.loadPartials({
        'header': './templates/common/header.hbs',
        'footer': './templates/common/footer.hbs',
    })

}

function getURL(endpoint) {
    let result = `https://shoesite-cb8df.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
    return result;
}

function takeExistingUser(email) {
    return JSON.parse(localStorage.usersInfo).find(u => u.email == email)
}

function validateLoggedUser(context) {
    if (localStorage.loggedUser) {
        let user = JSON.parse(localStorage.loggedUser)
        context.isLoggedIn = true;
        context.email = user.email;
        context.uid = user.uid
    }
    else {
        context.isLoggedIn = false;

    }


}

function errorHandler(error) {
    console.log(error)
}


