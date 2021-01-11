import { loginPage, loginPost, logout, registerPage, registerPost } from './controllers/user.js';
import { homePage } from './controllers/home.js';
import { createOfferPage, createOfferPost, deleteOfferPage, detailsPage, editOfferPage, editOfferPost, myDestinationsPage } from './controllers/catalog.js';



const app = Sammy('#container', function () {
  this.use('Handlebars', 'hbs')


  //   const user = getUser()

  //  this.userData = {
  //      isLoggedIn: !!user,
  //      ...user
  //  };

  //Home
  this.get('/home', homePage);
  this.get('home', homePage);
  this.get('/', homePage);




  //Create
  this.get('create', createOfferPage)
  this.post('create', (ctx) => { createOfferPost(ctx); })

  //Details
  this.get('details/:_ownerId/:_id', detailsPage)

  //Edit
  this.get('edit/:_ownerId/:_id', editOfferPage)
  this.post('edit/:_ownerId/:_id', (ctx) => { editOfferPost(ctx); })

  //Mydestinations
  this.get('myDestinations', myDestinationsPage)

  //Delete
  this.get('delete/:_ownerId/:_id', deleteOfferPage)








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