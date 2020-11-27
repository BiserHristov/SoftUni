



const router = Sammy('#main', function () {

    let m = document.getElementById('main');
    m.addEventListener('click', (e) => {
        console.log(e.target)

        if (e.target.className == 'shoe') {
            router.run('/details')
        }
    })
    this.use('Handlebars', 'hbs');


    this.get('/home', async function (context) {
        //const usersInfo = localStorage.getItem('userInfo');
        //console.log(localStorage)
        if (localStorage.userInfo) {
            const { uid, email } = JSON.parse(localStorage.userInfo)
            context.loggedIn = true;
            context.email = email;

        }

        await fetch('https://shoe-self.firebaseio.com/.json')
            .then(response => response.json())
            .then(data => {
                if (data) {

                    //context.hasNoTeam = false
                    context.shoes = Object.keys(data).map(key => ({ key, ...data[key] }))
                    context.shoes.sort((a, b) => b.buyers - a.buyers)


                    console.log(context.shoes)


                }
            })

        await this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',
            //'artikel': './templates/catalog/artikel.hbs',
            'catalogController': './templates/catalog/catalogController.hbs',
        }).then(function () {
            this.partial('../templates/home/guestHome.hbs')
        })


        console.log(context)
    });



    this.get('/login', function () {
        this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',
            'loginForm': './templates/login/loginForm.hbs',
        }).then(function () {
            this.partial('../templates/login/loginPage.hbs')
        })


    });

    this.post('/login', function (context) {

        console.log(context)

        const { email, password } = context.params
        firebase.auth().signInWithEmailAndPassword(email, password)
            .then((userInfo) => {
                localStorage.setItem('userInfo', JSON.stringify({ uid: userInfo.user.uid, email: userInfo.user.email }));
                context.redirect('/home')
                //showMessage(infoBox, "Sucsessfuly logged");
            })
            .catch(function (error) {
                // Handle Errors here.
                var errorCode = error.code;
                var errorMessage = error.message;
                //showMessage(errorBox, errorMessage);
            });

        console.log(localStorage)

    })


    this.get('/register', function () {

        this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',
            'registerForm': './templates/register/registerForm.hbs',
        }).then(function () {
            this.partial('../templates/register/registerPage.hbs')
        })
    });

    this.post('/register', function (context) {
        const { email, password, repeatPassword } = context.params;

        if (password !== repeatPassword) {

            return
        }
        console.log(context)

        firebase.auth().createUserWithEmailAndPassword(email, password)
            .then((createdUser) => {
                context.redirect('/login')
                //showMessage(infoBox, "Sucsessfuly registered");
            })
            .catch(function (error) {
                // Handle Errors here.
                var errorCode = error.code;
                var errorMessage = error.message;
                //showMessage(infoBox, errorMessage);
                // ...
            });
    });


    this.get('/logout', function (context) {
        console.log(context)
        firebase.auth().signOut()
            .then(function () {
                localStorage.removeItem('userInfo');
                context.loggedIn = false
                context.redirect('/home');
                //showMessage(infoBox, "You are logged out");
            }).catch(function (error) {
                //showMessage(infoBox, error.message);
            })

    });

    this.get('/create', function (context) {

        if (localStorage.userInfo) {
            const { uid, email } = JSON.parse(localStorage.userInfo)
            context.loggedIn = true;
            context.email = email;

        }
        this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',
            'createForm': './templates/create/createForm.hbs',
        }).then(function () {
            this.partial('../templates/create/createPage.hbs')
        })

    });


    this.post('/create', function (context) {
        const { name, price, imageUrl, description, brand } = context.params;
        const { uid, email } = JSON.parse(localStorage.userInfo)
        if (!name || !price || !imageUrl || !description || !brand) {
            return
        }
        //const { email, password, repeatPassword } = context.params;
        fetch('https://shoe-self.firebaseio.com/.json', {
            method: "post",
            body: JSON.stringify(
                {
                    name: name,
                    price: price,
                    description: description,
                    brand: brand,
                    imageUrl: imageUrl,
                    buyers: 0,
                    author: email,


                })

        }).then(context.redirect('/home'))
    });

    this.get('/details/:id', async function (context) {

        if (localStorage.userInfo) {
            const { uid, email } = JSON.parse(localStorage.userInfo)
            context.loggedIn = true;
            context.email = email;

        }
        console.log(context)
        const { email, password, repeatPassword } = context.params;

        await fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`)
            .then(response => response.json())
            .then((data) => {
                context.name = data.name
                context.price = data.price
                context.imageUrl = data.imageUrl
                context.description = data.description
                context.brand = data.brand
                context.buyers = data.buyers
                context.id = context.params.id



                if (data.author == context.email) {
                    context.isAuthor = true
                }
            }
            )
        this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',

        }).then(function () {
            this.partial('../templates/details/details.hbs')
        })





    });


    this.get('/delete/:id', async function (context) {

        await fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`,
            {
                method: 'delete'
            })


        context.redirect('/home');

    });


    this.get('/buy/:id', async function (context) {

        await fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`)
            .then(response => response.json())
            .then(async (data) => {
                data.buyers++

                await fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`, {
                    method: "PATCH",
                    body: JSON.stringify(data)
                })
            })


        let buySpan = document.getElementById('buy');
        buySpan.style.display = "block";

        await setTimeout(async () => {
            buySpan.style.display = "none"
            context.redirect(`/details/${context.params.id}`);
        }, 3000);

        context.isBouth = true;


    });

    this.get('/edit/:id', async function (context) {

        if (localStorage.userInfo) {
            const { uid, email } = JSON.parse(localStorage.userInfo)
            context.loggedIn = true;
            context.email = email;

        }

        

        await fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`)
            .then(response => response.json())
            .then((data) => {
                context.author = data.author
                context.name = data.name
                context.price = data.price
                context.imageUrl = data.imageUrl
                context.description = data.description
                context.brand = data.brand
                context.buyers = data.buyers
                context.id = context.params.id



                // if (data.author == email) {
                //     context.isAuthor = true
                // }
            }
            )
        const id = context.params.id

        this.loadPartials({
            'header': './templates/header/header.hbs',
            'footer': './templates/header/footer.hbs',

        }).then(function () {
            this.partial('../templates/edit/editForm.hbs')
        })

        context.id = id
    })





    this.post('/edit/:id', function (context) {

        if (localStorage.userInfo) {
            const { uid, email } = JSON.parse(localStorage.userInfo)
            context.loggedIn = true;
            context.email = email;

        }

        let obj = {
            author: context.email,
            name: context.params.name,
            brand: context.params.brand,
            price: context.params.price,
            description: context.params.description,
            imageUrl: context.params.imageUrl,
            buyers: 0
        }




        fetch(`https://shoe-self.firebaseio.com/${context.params.id}.json`, {
            method: "PUT",
            body: JSON.stringify(obj)
        }).then(async (data) => await context.redirect(`/details/${context.params.id}`))



        //context.redirect(`/details/${context.params.id}`);


    })



});


(() => {
    router.run('/home');
})()