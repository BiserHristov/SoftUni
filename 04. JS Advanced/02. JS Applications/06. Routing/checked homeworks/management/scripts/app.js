const UserModel = firebase.auth();
const DB = firebase.firestore();

const router = Sammy('#main', function() {

    this.use('Handlebars', 'hbs');

    // GET
    this.get('#/home', function(context) {

        checkLogin(context);
         
        loadPartials(context)
        .then(function() {
            this.partial('../templates/home/home.hbs');
        });
    });

    this.get('#/about', function(context) {

        checkLogin(context);

        loadPartials(context)
        .then(function() {
            this.partial('../templates/about/about.hbs');
        });
    });

    this.get('#/login', function(context) {

        checkLogin(context);

        if (context.loggedIn) {
            context.redirect('#/home');
            return;
        }

        this.loadPartials({
            'header' : '../templates/common/header.hbs',
            'footer' : '../templates/common/footer.hbs',
            'loginForm' : '../templates/login/loginForm.hbs',
        }).then(function() {
            this.partial('../templates/login/loginPage.hbs');
        });
    });

    this.get('#/register', function(context) {

        checkLogin(context);

        if (context.loggedIn) {
            context.redirect('#/home');
            return;
        }

        this.loadPartials({
            'header' : '../templates/common/header.hbs',
            'footer' : '../templates/common/footer.hbs',
            'registerForm' : '../templates/register/registerForm.hbs',
        }).then(function() {
            this.partial('../templates/register/registerPage.hbs');
        });
    });

    this.get('#/logout', function(context) {
        UserModel.signOut()
            .then(response => {
                localStorage.removeItem('userInfo');
                context.redirect('#/home');
            })
            .catch(err => console.log(Err));
    });

    this.get('#/catalog', async function(context) {

        checkLogin(context);

        let teams;
        
        await getTeams().then(data => teams = data);

        console.log(teams);

        context.hasNoTeam = true; // Hard coded
        context.teams = teams;

        this.loadPartials({
            'header' : './templates/common/header.hbs',
            'footer' : './templates/common/footer.hbs',
            'team' : './templates/catalog/team.hbs',
        })
        .then(function() {
            this.partial('./templates/catalog/teamCatalog.hbs');
        });

    });

    this.get('#/create', function(context) {

        checkLogin(context);

        this.loadPartials({
            'header' : '../templates/common/header.hbs',
            'footer' : '../templates/common/footer.hbs',
            'createForm' : '../templates/create/createForm.hbs',
        })
        .then(function() {
            this.partial('../templates/create/createPage.hbs');
        })
    });

    this.get('#/catalog/:id', async function(context) {


        checkLogin(context);

        let team;
        const id = context.params['id'].substring(1);
        await getTeamById(id).then(data => team = data);

        context.name = team.name;
        context.comment = team.comment;
        context.teamId = team._id;
        context.members = team.members;

        console.log(team.members);

        this.loadPartials({
            'header' : './templates/common/header.hbs',
            'footer' : './templates/common/footer.hbs',
            'teamMember' : './templates/catalog/teamMember.hbs',
            'teamControls' : './templates/catalog/teamControls.hbs',
        })
        .then(function() {
            this.partial('./templates/catalog/details.hbs');
        });

        
    });

    this.get('#/join/:id', async function(context) {

        checkLogin(context);

        let team;
        const id = context.params['id'].substring(1);
        await getTeamById(id).then(data => team = data);

        let username = JSON.parse(localStorage.getItem('userInfo')).email;
        team.members[username] = username;

        DB.collection("teams").doc(team.name).set({
            name    : team.name,
            comment : team.comment,
            creator : team.creator,
            members : team.members,
        });

    });

    // POST
    this.post('#/register', function(context) {

        const { username, password, repeatPassword } = context.params;

        if (!username || !password || password != repeatPassword) return;

        UserModel.createUserWithEmailAndPassword(username, password)
            .then(() => this.redirect('#/login'))
            .catch(err => console.log(err));
    });

    this.post('#/login', function(context) {

        const { username, password } = context.params;

        if (!username || !password) return;

        UserModel.signInWithEmailAndPassword(username, password)
            .then(({ user : {uid, email} }) => {

                localStorage.setItem('userInfo', JSON.stringify({ uid, email }));
                context.redirect('#/home');
            })
            .catch(err => console.log(err));
    });

    this.post('#/create', function(context) {

        checkLogin(context);

        if (!context.loggedIn) {
            context.redirect('#/home');
            return;
        }

        const { name, comment } = context.params;

        if (!name || !comment) {
            context.redirect('#/create');
            return;
        }

        DB.collection("teams").doc(name).set({
            name,
            comment,
            creator : JSON.parse(localStorage.getItem('userInfo').uid),
        });

        context.redirect('#/catalog');

    });
});

function loadPartials(context) {
    return context.loadPartials({
        'header' : '../templates/common/header.hbs',
        'footer' : '../templates/common/footer.hbs',
    });
}

function checkLogin(context) {
    const userInfo = localStorage.getItem('userInfo');

    if (userInfo) {
        const { uid, email } = JSON.parse(userInfo);
        context.loggedIn = true;
        context.username = email;
    }
}

async function getTeams() {
    const snapshot = await firebase.firestore().collection('teams').get(); //.docs.map(doc => doc.data());
    const teams = snapshot.docs.map(doc => doc.data());

    for (let team in teams) {
        teams[team]._id = team;
    }

    return teams;
}

async function getTeamById(id) {
    
    let teams;

    await getTeams().then(data => teams = data);

    return teams[id];
}

(() => {
    router.run('#/home');
})();