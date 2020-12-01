import { loginPage, loginPost, logout, registerPage, registerPost, profilePage } from './controllers/user.js';
import { homePage } from './controllers/home.js';
import { createPage, createPost, detailsPage, commentPost, likePage, deletePage } from './controllers/catalog.js';



const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs')


    // console.log('Handlebars -> ' + Handlebars)
    // console.log('Sammy -> ' + Sammy)

    // const user = getUser()

    // this.userData = {
    //     isLoggedIn: !!user,
    //     ...user
    // };

    //Home
    this.get('/home', homePage);
    this.get('home', homePage);
    this.get('/', homePage);




    //Create
    this.get('create', createPage)
    this.post('create', (ctx) => { createPost(ctx); })

    //Details
    this.get('details/:_ownerId/:_id', detailsPage)

    //Comment
    this.post('comment/:_ownerId/:_id', (ctx) => { commentPost(ctx); })

    //Like
    this.get('like/:_ownerId/:_id', likePage)

    //Delete
    this.get('delete/:_ownerId/:_id', deletePage)

    //Profile
    this.get('profile', profilePage)


    


    //Register
    this.get('/register', registerPage);
    this.post('/register', (ctx) => { registerPost(ctx); });



    //Login
    this.get('/login', loginPage);
    this.post('/login', (ctx) => { loginPost(ctx); });

    //Logout
    this.get('/logout', logout);




})

app.run();