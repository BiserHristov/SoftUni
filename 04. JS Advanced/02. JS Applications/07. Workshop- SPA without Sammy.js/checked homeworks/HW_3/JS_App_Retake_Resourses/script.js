const auth = firebase.auth();
const shoesURL = `https://shoe-shelf-c0c62.firebaseio.com/Shoes`;
const app = Sammy('#app', function () {

    this.use('Handlebars', 'hbs');

    this.get('/home', function (context) {
        checkLoginStatus(context);

        fetch(`${shoesURL}.json`)
            .then(res => res.json())
            .then(shoes => {

                shoes = shoes ? Object.keys(shoes).map(id => ({ id, ...shoes[id] })) : undefined
                context.shoes = shoes;
                loadAllPartials(context).then(function () {
                    this.partial('./templates/home.hbs')
                })
            })

    })

    //For guest
    this.get('/register', function (context) {
        loadAllPartials(context).then(function () {
            this.partial('./templates/register.hbs')
        })
    })
    this.get('/login', function (context) {
        loadAllPartials(context).then(function () {
            this.partial('./templates/login.hbs')
        })
    })

    this.post('/register', function (context) {
        let { email, password, rePassword } = context.params;

        if (password != rePassword) {
            alert('Passwords must match');
            return;
        }

        if (password.length < 6) {
            alert('Password must be longer than 5 symbols');
            return;
        }

        auth.createUserWithEmailAndPassword(email, password)
            .then(() => {
                context.redirect('/login');
            })
            .catch(errorHandler)
    })
    this.post('/login', function (context) {
        let { email, password } = context.params;

        auth.signInWithEmailAndPassword(email, password)
            .then(data => {
                let { uid, email } = data.user;
                localStorage.setItem('user', JSON.stringify({ uid, email }))
                context.redirect('/home');
            })
            .catch(errorHandler);
    })

    // For users
    this.get('/logout', function (context) {
        localStorage.removeItem('user');
        context.redirect('/home')
    })
    this.get('/create-offer', function (context) {
        checkLoginStatus(context);

        loadAllPartials(context).then(function () {
            this.partial('./templates/createOffer.hbs')
        })
    })

    this.post('/create-offer', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        const { name, price, imageUrl, description, brand } = context.params;

        fetch(`${shoesURL}.json`, {
            method: 'POST',
            body: JSON.stringify({
                name,
                price,
                imageUrl,
                description,
                brand,
                ownerID: JSON.parse(localStorage.getItem('user')).uid,
                buyers: []
            })
        })
            .then(() => {
                context.redirect('/home');
            })
    })

    this.get('/offer-details/:offerID', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        let { offerID } = context.params;



        fetch(`${shoesURL}/${offerID}.json`)
            .then(res => res.json())
            .then(shoe => {
                const { name, description, imageUrl, price } = shoe;
                const userData = JSON.parse(localStorage.getItem('user'))
                context.id = offerID;
                context.name = name;
                context.description = description;
                context.imageUrl = imageUrl;
                context.price = price;

                if (userData.uid == shoe.ownerID) {
                    context.isOwner = true;
                } else {
                    if (!shoe.buyers || !shoe.buyers.includes(userData.uid)) {
                        context.hasNotBought = true;
                    }
                    
                }

                loadAllPartials(context).then(function () {
                    this.partial('./templates/offerDetails.hbs')
                })
            })
    })
    this.get('/edit/:id', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        const { id } = context.params;

        fetchShoeData(id)
            .then(shoe => {
                const { name, description, imageUrl, price, brand } = shoe;
                context.id = id;
                context.name = name;
                context.description = description;
                context.imageUrl = imageUrl;
                context.price = price;
                context.brand = brand;

                loadAllPartials(context).then(function () {
                    this.partial('./templates/editOffer.hbs')
                })
            })
    })

    this.post('/edit/:id', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        const { id, name, description, imageUrl, price, brand } = context.params;
        fetch(`${shoesURL}/${id}.json`, {
            method: "PATCH",
            body: JSON.stringify({
                name,
                description,
                imageUrl,
                price,
                brand
            })
        })
        .then(function() {
            context.redirect(`/home`)
        })

    })

    this.get('/delete/:id', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        const { id } = context.params;

        fetch(`${shoesURL}/${id}.json`, { method: "DELETE" })
        .then(function() {
            context.redirect(`/home`)
        })
    })
    this.get('/buy/:id', function (context) {
        checkLoginStatus(context);
        if (!context.isLoggedOn) {
            context.redirect('/home');
            return;
        }
        const { id } = context.params;

        fetchShoeData(id)
            .then(shoe => {  
                // checks to see if array exists, if so add person, if not creates the array
                let newBuyers = shoe.buyers ? shoe.buyers.push(JSON.parse(localStorage.getItem('user')).uid) : [JSON.parse(localStorage.getItem('user')).uid];
                fetch(`${shoesURL}/${id}.json`, { method: "PATCH", body: JSON.stringify({ buyers: newBuyers }) })
                .then(function() {
                    context.redirect(`/offer-details/${id}`)
                })
            })
    })
});

function fetchShoeData(id) {
    return fetch(`${shoesURL}/${id}.json`)
        .then(res => res.json())
}

function checkLoginStatus(context) {
    let userData = localStorage.getItem('user')
    if (userData) {
        let { email, uid } = JSON.parse(userData)
        context.isLoggedOn = true;
        context.email = email;
        context.uid = uid;

    }
}

function loadAllPartials(context, partials = {}) {
    let allPartials = {
        'header': './common/header.hbs'
    }
    Object.assign(allPartials, partials);
    return context.loadPartials(allPartials);
}

function errorHandler(err) {
    alert(err.message)
}
(() => {
    app.run('/home');
})();