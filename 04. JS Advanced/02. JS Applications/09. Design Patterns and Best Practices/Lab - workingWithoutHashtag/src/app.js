import { loginPage, loginPost, logout, registerPage, registerPost } from './controllers/user.js';
import { homePage } from './controllers/home.js';
import { getUser } from './controllers/util.js';
import { buyOfferPage, createOfferPage, createOfferPost, deleteOfferPage, detailsPage, editOfferPage, editOfferPost } from './controllers/catalog.js';


const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs')

    const user = getUser()

    // this.userData = {
    //     isLoggedIn: !!user,
    //     ...user
    // };

    //Home
    this.get('/home', homePage);
    this.get('home', homePage);
    this.get('/', homePage);

    //Create
    this.get('create-offer', createOfferPage)
    this.post('create-offer', (ctx) => { createOfferPost(ctx); })

    //Details
    this.get('details/:_id', detailsPage)

    //Edit
    this.get('edit/:_id', editOfferPage)
    this.post('edit/:_id', (ctx) => { editOfferPost(ctx); })

    //Delete
    this.get('delete/:_id', deleteOfferPage)

   //Buy
   this.get('buy/:_id', buyOfferPage)


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