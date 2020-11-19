//const { data } = require("jquery");

const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    //Home
    this.get('/home', function (context) {

        fetch(getURL())
            .then(response => response.json())
            .then(data => {

                data = data || {} //??

                context.shoes = []

                Object.entries(data).forEach(([key, value]) => {
                    let { model, price, imgURL, description, brand } = value

                    let shoe = {
                        _id: key,
                        model,
                        price,
                        imgURL,
                        description,
                        brand
                    }

                    context.shoes.push(shoe)

                });

                preloadPartials(context)
                    .then(function () {
                        this.partial('./templates/home.hbs')
                    })

            })
            .catch(err => console.log(err))


    })

    //Catalog
    this.get('/catalog', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/catalog.hbs')

            })
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

        let offer = {
            model,
            price,
            imgURL,
            description,
            brand,
            creator: JSON.parse(localStorage.loggedUser).email,
            buyers: []
        }

        fetch(getURL(), { method: 'POST', body: JSON.stringify(offer) })
            .then(response => response.json())
            .then(data => {
                this.redirect('/home')
            })
            .catch(error => console.log(error))
    })

    //Details
    this.get('/details', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/details.hbs')

            })
    })

    //Edit
    this.get('/edit', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('./templates/edit.hbs')

            })
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
        if (password != repassword) {
            return
        }

        firebase.auth()
            .createUserWithEmailAndPassword(email, password)
            .then(this.redirect('/login'))
            .catch(err => console.log(err))

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
                this.redirect('/home')
            }
            )
            .catch(err => console.log(err))

        context.isLoggedIn = true

    })


    //Logout
    this.get('/logout', function (context) {
        firebase.auth()
            .signOut()
            .then(() => {

                localStorage.removeItem('loggedUser')
                this.redirect('/home')

            })
            .catch(err => console.log(err))
    })



});

(() => {
    app.run('/home')
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


