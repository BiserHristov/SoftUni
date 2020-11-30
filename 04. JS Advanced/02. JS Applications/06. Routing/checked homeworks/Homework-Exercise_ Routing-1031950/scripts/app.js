let userAuth = firebase.auth();
let baseUrl = "https://myteemproject.firebaseio.com/";
let app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs')
    this.get('#/home', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs'
        }).then(function () {
            this.partial('./templates/home/home.hbs')
        })

    });
    this.get('#/about', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs'
        }).then(function () {
            this.partial('./templates/about/about.hbs')
        })
    });
    this.get('#/login', function (context) {
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'loginForm': './templates/login/loginForm.hbs'
        }).then(function () {
            this.partial('./templates/login/loginPage.hbs')
        })
    });
    this.post('#/login', function (context) {
        let { email, password } = context.params;
        userAuth.signInWithEmailAndPassword(email, password)
            .then(({ user: { email, uid } }) => {
                localStorage.setItem('user', JSON.stringify({ email, uid }))
                this.redirect('#/home')
            })
            .catch(catchError)
    });
    this.get('#/register', function (context) {
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'registerForm': './templates/register/registerForm.hbs'
        }).then(function () {
            this.partial('./templates/register/registerPage.hbs')
        })
    });
    this.post('#/register', function (context) {
        let { email, password, repeatPassword } = context.params;
        if (password !== repeatPassword) {
            let infoDiv = document.getElementById("infoBox");
            infoDiv.style.display = 'block';
            infoDiv.innerText = 'Password and RepeatPassword must be the same!'
            setTimeout(function () { infoDiv.style.display = 'none' }, 3000)
            return;
        }
        userAuth.createUserWithEmailAndPassword(email, password)
            .then(this.redirect('#/login'))
            .catch(catchError)
    });
    this.get('#/logout', function (context) {
        userAuth.signOut()
            .then(res => {
                localStorage.clear();
                this.redirect('#/home')
            })
            .catch(catchError)
    });
    this.get('#/catalog', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        let url = baseUrl + 'teams/.json';
        context.teams = [];
        context.hasNoTeam = true;
        fetch(url)
            .then(info => info.json())
            .then(res => {
                if (res) {
                    Object.keys(res)
                        .forEach((key) => {
                            context.teams.push({ _id: key, name: res[key].name, comment: res[key].comment });
                            if (res[key].author === email) {
                                context.hasNoTeam = false;
                            }
                        })
                }
                this.loadPartials({
                    'header': './templates/common/header.hbs',
                    'footer': './templates/common/footer.hbs',
                    'team': './templates/catalog/team.hbs'
                }).then(function () {
                    this.partial('./templates/catalog/teamCatalog.hbs');
                })
            })
            .catch(catchError);
    })
    this.get('#/create', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        this.loadPartials({
            'header': './templates/common/header.hbs',
            'footer': './templates/common/footer.hbs',
            'createForm': './templates/create/createForm.hbs'
        }).then(function () {
            this.partial('./templates/create/createPage.hbs');
        })
    })
    this.post('#/create', function (context) {
        let { email, uid } = getUserInfo();
        let { name, comment } = context.params;
        let url = baseUrl + 'teams/.json';
        let initObj = {
            method: 'post',
            body: JSON.stringify({
                name: name,
                comment: comment,
                members: [email],
                author: email
            })
        }
        fetch(url, initObj)
            .then(res => {
                res.json();
                this.redirect('#/catalog')
            })
            .catch(catchError);

    })
    this.get('#/catalog/:id', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        let id = context.params.id;
        context.teamId = id;
        currUrl = baseUrl + 'teams/' + `${id}/.json`
        fetch(currUrl)
            .then(res => res.json())
            .then(res => {
                let { name, comment, author, members } = res;
                context.name = name;
                context.comment = comment;
                context.members = members;
                context.isAuthor = author === email ? true : false;
                context.isOnTeam = members?members.includes(email):false;
                this.loadPartials({
                    'header': './templates/common/header.hbs',
                    'footer': './templates/common/footer.hbs',
                    'teamMember': './templates/catalog/teamMember.hbs',
                    'teamControls': './templates/catalog/teamControls.hbs'
                }).then(function () {
                    this.partial('./templates/catalog/details.hbs');
                })
            });
    })
    this.get('#/edit/:id', function (context) {
        let { email, uid } = getUserInfo();
        context.loggedIn = uid;
        context.email = email;
        let id = context.params.id;
        context.teamId = id;
        currUrl = baseUrl + 'teams/' + `${id}/.json`
        fetch(currUrl)
            .then(res => res.json())
            .then(res => {
                let { name, comment } = res;
                context.name = name;
                context.comment = comment;
                this.loadPartials({
                    'header': './templates/common/header.hbs',
                    'footer': './templates/common/footer.hbs',
                    'editForm': './templates/edit/editForm.hbs',
                }).then(function () {
                    this.partial('./templates/edit/editPage.hbs');
                })
            })
    })
    this.post('#/edit/:id', function (context) {
        let { name, comment, id } = context.params;
        currUrl = baseUrl + 'teams/' + `${id}/.json`;
        fetch(currUrl)
            .then(res => res.json())
            .then(res => {
                let { author, members } = res;
                let initObj = {
                    method: 'put',
                    body: JSON.stringify({
                        name: name,
                        comment: comment,
                        members: members,
                        author: author
                    })
                }
                fetch(currUrl, initObj)
                    .then(res => {
                        res.json();
                        this.redirect('#/catalog')
                    })
                    .catch(catchError);
            })
    })
    this.get('#/leave/:id', function (context) {
        let id = context.params.id;
        let { email, uid } = getUserInfo();
        currUrl = baseUrl + 'teams/' + `${id}/.json`;
        fetch(currUrl)
            .then(res => res.json())
            .then(res => {
                let {  name, comment,author, members } = res;
                let remIndex = members.indexOf(email);
                if (remIndex > -1) {
                    members.splice(remIndex, 1);
                  }
                let initObj = {
                    method: 'put',
                    body: JSON.stringify({
                        name: name,
                        comment: comment,
                        members: members,
                        author: author
                    })
                }
                fetch(currUrl, initObj)
                    .then(res => {
                        res.json();
                        this.redirect('#/catalog')
                    })
                    .catch(catchError);
            })
    })
    this.get('#/join/:id', function (context) {
        let id = context.params.id;
        let { email, uid } = getUserInfo();
        currUrl = baseUrl + 'teams/' + `${id}/.json`;
        fetch(currUrl)
            .then(res => res.json())
            .then(res => {
                let {  name, comment,author, members } = res;
                members= members?members.push(email):[email];
                let initObj = {
                    method: 'put',
                    body: JSON.stringify({
                        name: name,
                        comment: comment,
                        members: members,
                        author: author
                    })
                }
                fetch(currUrl, initObj)
                    .then(res => {
                        res.json();
                        this.redirect('#/catalog')
                    })
                    .catch(catchError);
            })
        })
});


function getUserInfo() {
    let cuurUser = localStorage.getItem('user')
    return cuurUser ? { email, uid } = JSON.parse(cuurUser) : {};
}

function catchError(err) {
    let errorDiv = document.getElementById("errorBox");
    errorDiv.style.display = 'block';
    errorDiv.innerText = `${err.message}`;
    setTimeout(function () { errorDiv.style.display = 'none' }, 3000)
}

app.run('#/home');
