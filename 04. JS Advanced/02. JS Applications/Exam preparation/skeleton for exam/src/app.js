// import { loginPage, loginPost, logout, registerPage, registerPost } from './controllers/user.js';
// import { homePage } from './controllers/home.js';
// import { buyOfferPage, createOfferPage,createOfferPost, deleteOfferPage, detailsPage, editOfferPage, editOfferPost } from './controllers/catalog.js';
// import { getUser } from './controllers/util.js';
// import { showError,showInfo } from './notification.js';


const app = Sammy('#rootContainer', function () {
  this.use('Handlebars', 'hbs')


  console.log('Handlebars -> ' + Handlebars)
  console.log('Sammy -> ' + Sammy)
 
  //   const user = getUser()

  //  this.userData = {
  //      isLoggedIn: !!user,
  //      ...user
  //  };

  // //Home
  // this.get('/home', homePage);
  // this.get('home', homePage);
  // this.get('/', homePage);




  // //Create
  // this.get('create', createOfferPage)
  // this.post('create', (ctx) => { createOfferPost(ctx); })

  // //Details
  // this.get('details/:_id', detailsPage)

  // //Edit
  // this.get('edit/:_id', editOfferPage)
  // this.post('edit/:_id', (ctx) => { editOfferPost(ctx); })

  // //Delete
  // this.get('delete/:_id', deleteOfferPage)

  // //Buy
  // this.get('buy/:_id', buyOfferPage)






  // //Register
  // this.get('/register', registerPage);
  // this.post('/register', (ctx) => { registerPost(ctx); });



  // //Login
  // this.get('/login', loginPage);
  // this.post('/login', (ctx) => { loginPost(ctx); });

  // //Logout
  // this.get('/logout', logout);



})

app.run();