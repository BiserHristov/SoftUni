const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');


    //GET
    this.get('/home', function (context) {
        const userInfo = localStorage.getItem('userInfo')
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true
        }

        fetch(getURL())
            .then(response => response.json())
            .then(data => {
                data = data || {}
                Object.entries(data).forEach(([key, value]) => {

                    if (value.hasOwnProperty('members') && value.members.includes(context.email)) {
                        context.hasTeam = true;
                        context.hasNoTeam = false;
                        context._id = key;

                        const userInfo = localStorage.getItem('userInfo')
                        if (userInfo) {
                            let updatedUserInfo = JSON.parse(userInfo)
                            updatedUserInfo['hasTeam'] = true
                            updatedUserInfo['hasNoTeam'] = false
                            updatedUserInfo['teamKey'] = key;

                            localStorage.setItem('userInfo', JSON.stringify(updatedUserInfo))

                        }

                    }
                })

                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                }).then(function () {
                    this.partial('../templates/home/home.hbs')
                })


            })
            .catch(err => console.log(err))


    })

    this.get('/', function (context) {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
        }).then(function () {
            this.partial('../templates/home/home.hbs')
        })
    })

    this.get('/about', function (context) {
        const userInfo = localStorage.getItem('userInfo')
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true;
        }

        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
        }).then(function () {
            this.partial('../templates/about/about.hbs')
        })
    })

    this.get('/catalog', function (context) {
        const userInfo = localStorage.getItem('userInfo')

        if (userInfo) {
            const { uid, email, hasTeam, teamKey, hasNoTeam } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true
            context.hasTeam = hasTeam ? true : false
            context._id = teamKey
            context.hasNoTeam = !context.hasTeam

        }

        fetch(getURL())
            .then(res => res.json())
            .then(data => {
                data = data || {}

                context.teams = [];

                Object.entries(data).forEach(([key, value]) => {
                    let obj = {
                        _id: key,
                        name: value.name,
                        comment: value.comment
                    }
                    context.teams.push(obj)
                });


                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                    'team': '../templates/catalog/team.hbs',
                }).then(function () {
                    this.partial('../templates/catalog/teamCatalog.hbs')
                })

            })
            .catch(err => console.log(err))

    })

    this.get('/create-team', function (context) {

        const userInfo = localStorage.getItem('userInfo')
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true


        }
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'createForm': '../templates/create/createForm.hbs',

        }).then(function () {
            this.partial('../templates/create/createPage.hbs')
        })



    })

    this.get('/login', function (context) {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'loginForm': '../templates/login/loginForm.hbs'

        }).then(function (context) {
            this.partial('../templates/login/loginPage.hbs')
        })

    })
    this.get('/logout', function (context) {
        firebase.auth()
            .signOut()
            .then(() => {

                localStorage.removeItem('userInfo')
                this.redirect('/home')

            })
            .catch(err => console.log(err))
    })

    this.get('/register', function (context) {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'registerForm': '../templates/register/registerForm.hbs'

        }).then(function () {
            this.partial('../templates/register/registerPage.hbs')
        })

    })

    this.get('/catalog/:_id', function (context) {
        const userInfo = localStorage.getItem('userInfo')
        if (userInfo) {
            const { uid, email, hasNoTeam, hasTeam } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true
            context.hasNoTeam = hasNoTeam
            context.hasTeam = hasTeam
            context._id = context.params._id.split(':')[1]
        }

        fetch(getURL(context.params._id.split(':')[1]))
            .then(response => response.json())
            .then(data => {
                if (data.hasOwnProperty('members')) {
                    context.members = data.members;
                    context.isOnTeam = data.members.includes(JSON.parse(localStorage.userInfo).email)
                }
                else {
                    context.isOnTeam = false;
                }
                context.name = data.name;
                context.comment = data.comment
                context._id = context.params._id.split(':')[1]
                context.isAuthor = JSON.parse(localStorage.userInfo).email == data.owner



                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                    'teamMember': '../templates/catalog/teamMember.hbs',
                    'teamControls': '../templates/catalog/teamControls.hbs'
                })
                    .then(function () {
                        this.partial('../templates/catalog/details.hbs')
                    })
            })


    })

    this.get('/edit/:_id', function (context) {
        const userInfo = localStorage.getItem('userInfo')
        if (userInfo) {
            const { uid, email, hasNoTeam, hasTeam } = JSON.parse(userInfo)
            context.email = email
            context.loggedIn = true
            context.hasNoTeam = hasNoTeam
            context.hasTeam = hasTeam
        }

        fetch(getURL(context.params._id.split(':')[1]))
            .then(response => response.json())
            .then(data => {
                context.name = data.name
                context.comment = data.comment
                context._id = context.params._id.split(':')[1]

                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                    'editForm': '../templates/edit/editForm.hbs'
                })
                    .then(function () {
                        this.partial('../templates/edit/editPage.hbs')
                    })

            })
            .catch(err => console.log(err))





    })





    //POST
    this.post('/register', function (context) {
        const { email, password, repeatPassword } = context.params
        let errorBox = document.querySelector('#errorBox')
        if (password != repeatPassword) {
            errorBox.textContent = 'Both passwords do not match'
            errorBox.style.display = 'block'
            setTimeout(() => errorBox.style.display = 'none', 3000);

            return;
        } else {
            errorBox.textContent = ''
            errorBox.style.display = 'none'
        }

        firebase.auth()
            .createUserWithEmailAndPassword(email, password)
            .then(this.redirect('/login'))
            .catch(err => console.log(err))
    })

    this.post('/login', function (context) {
        const { email, password } = context.params
        let user = {};

        firebase.auth()
            .signInWithEmailAndPassword(email, password)
            .then((userData) => {

                user.uid = userData.user.uid;
                user.email = userData.user.email;
                localStorage.setItem('userInfo', JSON.stringify(user))
                this.redirect('/home')
            })

            .catch(err => console.log(err))

        context.loggedIn = true;


    })


    this.post('/create-team', function (context) {
        const { name, comment } = context.params

        let team = {

            name,
            comment,
            owner: JSON.parse(localStorage.userInfo).email,
            members: [
                JSON.parse(localStorage.userInfo).email
            ]
        }

        fetch(getURL(), { method: 'POST', body: JSON.stringify(team) })
            .then(response => response.json())
            .then(key => {
                const userInfo = localStorage.getItem('userInfo')
                if (userInfo) {
                    let updatedUserInfo = JSON.parse(userInfo)
                    updatedUserInfo['hasTeam'] = true
                    updatedUserInfo['hasNoTeam'] = false
                    updatedUserInfo['name'] = name;
                    updatedUserInfo['teamKey'] = key.name;

                    localStorage.setItem('userInfo', JSON.stringify(updatedUserInfo))
                }

                this.redirect('/catalog')
            })
            .catch(err => console.log(err))

    })

    this.post('/edit/:_id', function (context) {

        const { name, comment } = context.params
        let newFields = {
            name,
            comment
        }

        fetch(getURL(context.params._id.split(':')[1]), { method: 'PATCH', body: JSON.stringify(newFields) })
            .then(res => res.json())
            .then(data => {
                this.redirect(`/catalog/:${context.params._id.split(':')[1]}`)
            })
            .catch(err => console.log(err))


    })

    this.get('/leave/:_id', function (context) {

        let teamKey = context.params._id.split(':')[1];
        fetch(getURL(teamKey))
            .then(res => res.json())
            .then(data => {
                let updatedMembers = [];
                if (data.members.length > 1) {
                    updatedMembers = data.members.filter(m => m != JSON.parse(localStorage.userInfo).email)
                }
                let updatedObj = {
                    members: updatedMembers
                }

                fetch(getURL(teamKey), { method: 'PATCH', body: JSON.stringify(updatedObj) })
                    .then(res => res.json())
                    .then(data => {

                        const userInfo = localStorage.getItem('userInfo')
                        let updatedUserInfo = JSON.parse(userInfo)
                        updatedUserInfo['hasTeam'] = false
                        updatedUserInfo['hasNoTeam'] = true
                        updatedUserInfo['name'] = name;
                        updatedUserInfo['teamKey'] = '';

                        localStorage.setItem('userInfo', JSON.stringify(updatedUserInfo))

                        this.redirect(`/catalog/:${teamKey}`)

                    })
            })
            .catch(err => console.log(err))

    })

    this.get('/join/:_id', function (context) {

        let teamKey = context.params._id.split(':')[1];
       
        fetch(getURL(teamKey))
            .then(res => res.json())
            .then(data => {
                let allMembers = [];
                allMembers.push(JSON.parse(localStorage.userInfo).email);
                if (data.hasOwnProperty('members')) {
                    data.members.forEach(m => allMembers.push(m))
                }


                let updatedObj = {
                    members: allMembers
                }

                fetch(getURL(teamKey), { method: 'PATCH', body: JSON.stringify(updatedObj) })
                    .then(res => res.json())
                    .then(patchData => {

                        const userInfo = localStorage.getItem('userInfo')
                        let updatedUserInfo = JSON.parse(userInfo)
                        updatedUserInfo['hasTeam'] = true
                        updatedUserInfo['hasNoTeam'] = false
                        updatedUserInfo['name'] = data.name;
                        localStorage.setItem('userInfo', JSON.stringify(updatedUserInfo))

                        this.redirect(`/catalog/:${teamKey}`)


                    })
            })
            .catch(err => console.log(err))

    })


});

(() => {
    app.run('/home')
})()


// function preloadPartials(context) {
//     return context.loadPartials({
//         'header': '../templates/common/header.hbs',
//         'footer': '../templates/common/footer.hbs'
//     })

// }

function getURL(endpoint) {
    let result = `https://routing-98ed1.firebaseio.com/` + (endpoint ? `${endpoint}` : '') + `.json`
    return result;
}