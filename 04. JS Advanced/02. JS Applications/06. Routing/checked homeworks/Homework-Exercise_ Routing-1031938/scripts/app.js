const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    //GET
    this.get('#/home', function (context) {

        const userInfo = localStorage.getItem('userInfo');

        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs'
        }).then(function () {
            this.partial('./templates/home/home.hbs')
        });
    });

    this.get('#/login', function () {
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'loginForm': './templates/login/loginForm.hbs'
        }).then(function () {
            this.partial('./templates/login/loginPage.hbs')
        });
    });

    this.get('#/logout', function (context) {
        firebase.auth().signOut()
            .then((res) => {
                localStorage.removeItem('userInfo');
                context.redirect('#/home')
            }).catch((e) => console.log(e))
    })

    this.get('#/register', function () {
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'registerForm': './templates/register/registerForm.hbs'
        }).then(function () {
            this.partial('./templates/register/registerPage.hbs')
        });
    });

    this.get('#/about', function () {
        const userInfo = localStorage.getItem('userInfo');

        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
        }).then(function () {
            this.partial('./templates/about/about.hbs')
        });
    });

    this.get('#/catalog', function (context) {

        const userInfo = localStorage.getItem('userInfo');

        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.hasNoTeam = true;
            context.email = email;
        }

        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'team': './templates/catalog/team.hbs'
        }).then(function () {
            this.partial('./templates/catalog/teamCatalog.hbs')
        })
    })

    this.get('#/create-team', function (context) {
        const userInfo = localStorage.getItem('userInfo');

        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'createForm': './templates/create/createForm.hbs',
        }).then(function () {
            this.partial('./templates/create/createPage.hbs')
        })
    })
    //POST

    this.post('#/register', function (context) {

        const { email, password, repeatPassword } = context.params; // идва от name attribute


        //set timeout
        if (password !== repeatPassword) {
            let err = document.querySelector('#errorBox')
            err.textContent = 'Passwords should match each other'
            err.style.display = 'block';
            return;
        }

        firebase.auth().createUserWithEmailAndPassword(email, password)
            .then((createdUser) => {
                console.log(createdUser);
            }).catch((e) => console.log(e))

        this.redirect('#/login');

    })

    this.post('#/login', function (context) {

        const { email, password } = context.params;

        firebase.auth().signInWithEmailAndPassword(email, password)
            .then(({ user: { uid, email } }) => {

                localStorage.setItem('userInfo', JSON.stringify({ uid, email }))

                context.redirect('#/home');
            }).catch((e) => console.log(e))

    })

    this.post('#/create-team', function (context) {

    })
});

(() => {
    app.run('#/home'); //default page
})()