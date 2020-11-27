const app = Sammy('#container', function () {

    this.use('Handlebars', 'hbs');


    //Home
    this.get('home', homePage)
    this.get('index.html', homePage)
    this.get('/', homePage)



    function homePage(context) {

        fetch(getURL())
            .then(response => response.json())
            .then(data => {

                data = data || {}

                context.movies = []

                //Bonus search option
                let searchedTitle = context.params.title;

                if (searchedTitle) {
                    Object.entries(data).forEach(([key, value]) => {
                        let { title, description, imageUrl, owner, likes } = value

                        if (title.includes(searchedTitle)) {
                            let movie = {
                                key,
                                title,
                                description,
                                imageUrl,
                                owner,
                                likes: likes || []

                            }

                            context.movies.push(movie)
                        }

                    });
                }
                //End bonus search option
                else {

                    Object.entries(data).forEach(([key, value]) => {
                        let { title, description, imageUrl, owner, likes } = value

                        let movie = {
                            key,
                            title,
                            description,
                            imageUrl,
                            owner,
                            likes: likes || []

                        }

                        context.movies.push(movie)


                    });
                }

                preloadPartials(context)
                    .then(function () {
                        this.partial('/templates/home.hbs')
                    })
            })
            .catch(errorHandler)

    }


    //Add-movie
    this.get('/add-movie', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('/templates/add-movie.hbs')

            })
    })

    this.post('/add-movie', function (context) {

        let { title, description, imageUrl } = context.params

        if (title == '' ||
            description == '' ||
            imageUrl == '') {
            alert("All fields are required")
            return
        }

        let movie = {
            title,
            description,
            imageUrl,
            owner: JSON.parse(localStorage.loggedUser).email,
            likes: []
        }

        fetch(getURL(), { method: 'POST', body: JSON.stringify(movie) })
            .then(response => response.json())
            .then(data => {
                this.redirect('/home')
            })
            .catch(errorHandler)
    })



    //Details
    this.get('/details/:key', function (context) {
        let key = context.params.key;
        fetch(getURL(key))
            .then(response => response.json())
            .then(data => {
                let { title, description, imageUrl, owner, likes } = data
                context.key = key
                context.title = title;
                context.description = description;
                context.imageUrl = imageUrl;
                context.owner = owner;
                context.isOwner = JSON.parse(localStorage.loggedUser).email == data.owner ? true : false;

                context.likesCount = (likes || []).length;


                if (data.hasOwnProperty('likes')) {
                    context.isNotLiked = !data.likes.includes(JSON.parse(localStorage.loggedUser).email)
                }
                else {
                    context.isNotLiked = true;

                }

                preloadPartials(context)
                    .then(function () {
                        this.partial('/templates/details.hbs')
                    })

            })
            .catch(errorHandler)
    })


    //Edit
    this.get('/edit/:key', function (context) {
        let key = context.params.key;

        fetch(getURL(key))
            .then(response => response.json())
            .then(data => {


                context.key = key
                context = Object.assign(context, data)



                preloadPartials(context)
                    .then(function () {
                        this.partial('/templates/edit.hbs')
                    })

            })
            .catch(errorHandler)

    })

    this.post('/edit/:key', function (context) {

        // context.key = context.params.key


        // context.brand = data.brand
        // context.model = data.model
        // context.imgURL = data.imgURL
        // context.description = data.description
        // context.price = data.price


        const { title, description, imageUrl } = context.params
        let movie = {
            title,
            description,
            imageUrl
        }

        fetch(getURL(context.params.key), { method: 'PATCH', body: JSON.stringify(movie) })
            .then(res => res.json())
            .then(data => {
                this.redirect(`/details/${context.params.key}`)
            })
            .catch(errorHandler)
    })





    //Delete
    this.get('/delete/:key', function (context) {
        let key = context.params.key

        fetch(getURL(key), { method: 'DELETE' })
            .then(response => response.json())
            .then(data => {
                this.redirect(`/home`)
            })
            .catch(errorHandler)


    })


    //Like
    this.get('/like/:key', function (context) {
        let key = context.params.key

        fetch(getURL(key))
            .then(response => response.json())
            .then(data => {

                let allLikes = [];

                allLikes.push(JSON.parse(localStorage.loggedUser).email);

                if (data.hasOwnProperty('likes')) {
                    data.likes.forEach(l => allLikes.push(l))
                }


                let updatedObj = {
                    likes: allLikes
                }

                fetch(getURL(key), { method: 'PATCH', body: JSON.stringify(updatedObj) })
                    .then(response => response.json())
                    .then(patchData => {

                        this.redirect(`/details/${key}`)

                    })



            })
            .catch(errorHandler)
    })


    //Register
    this.get('/register', function (context) {

        preloadPartials(context)
            .then(function () {
                this.partial('/templates/register.hbs')

            })
    })

    this.post('/register', function (context) {

        let { email, password, repeatPassword } = context.params

        if (email == '' ||
            password == '' ||
            repeatPassword == '') {
            alert("All fields are required")
            return
        }

        if (password.length < 6) {
            alert("Password should be at least 6 characters long!")
            return
        }
        if (password != repeatPassword) {
            alert("Repeat Password does not match!")
            return
        }

        firebase.auth()
            .createUserWithEmailAndPassword(email, password)
            .then(data => {

                let user = {
                    email,
                    uid: data.user.uid
                }


                localStorage.setItem('loggedUser', JSON.stringify(user));
                this.redirect('/home')
            })
            .catch(errorHandler)

    })


    //LogIn
    this.get('/login', function (context) {
        preloadPartials(context)
            .then(function () {
                this.partial('/templates/login.hbs')

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


                localStorage.setItem('loggedUser', JSON.stringify(user));

                this.redirect('/home')
            })
            .catch(errorHandler)

        context.isLoggedIn = true

    })


    //Logout
    this.get('/logout', function (context) {
        firebase.auth()
            .signOut()
            .then(() => {

                localStorage.removeItem('loggedUser')
                this.redirect('/login')

            })
            .catch(errorHandler)
    })


});

(() => {
    app.run('/home')
})()

function preloadPartials(context) {

    validateLoggedUser(context);

    return context.loadPartials({
        'header': '/templates/common/header.hbs',
        'footer': '/templates/common/footer.hbs',
    })

}

function getURL(endpoint) {
    let result = `https://movie-catalog-2c109.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
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