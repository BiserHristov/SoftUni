//import { Form } from 'sammy';
import { homePage } from './controllers/home.js'
import { registerPage, registerPost, loginPage, loginPost, logout } from './controllers/user.js'
import { createPage, deleteOffer, detailsPage, editPage, buyPage, createPost, editPost, detailsOffer } from './controllers/catalog.js'
import init from './db-init.js'
import { getUser } from './controllers/util.js';

const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    const user = getUser()

    this.userData = {
        isLoggedIn: !!user,
        ...user
    };


    //Home
    this.get('/home', homePage)

    //Create-offer
    this.get('/create-offer', createPage)
    this.post('/create-offer', createPost)

    // Details
    this.get('/details', detailsPage)
    this.get('/details/:key', detailsOffer)

    //Edit
    this.get('/edit/:key', editPage)
    this.post('/edit/:key', editPost)

    //Buy
    this.get('/buy/:key', buyPage)

    //Delete
    this.get('/delete/:key', deleteOffer)

    //Register
    this.get('/register', registerPage)
    this.post('/register', registerPost)

    //LogIn
    this.get('/login', loginPage)
    this.post('/login', loginPost)

    //Logout
    this.get('/logout', logout)

});
init();
app.run('#/home')

