// import { createApiOffer, deleteOfferById, editApiOfferById, getApiOfferById, } from "../data.js";
// import { showError, showInfo } from "../notification.js";
// import { errorHandler, getUser, preloadPartials } from "./util.js";



// export async function createOfferPage(context) {

//     Object.assign(context, getUser())
//     await preloadPartials(context)
//     this.partial('/templates/create.hbs')
// }

// export async function createOfferPost(context) {

//     let post = Object.assign({}, context.params)
//     post._ownerId = getUser().localId;

//     try {
//         let response = await createApiOffer(post)
//         showInfo('Sucessfully created offer!')
//         context.redirect('/home')

//     } catch (error) {
//         showError(error.message)
//     }

// }

// export async function detailsPage(context) {
//     try {
//         let shoe = await getApiOfferById(context.params._id)
//         shoe.isOwner = getUser().localId == shoe._ownerId
//         shoe.buyers = shoe.buyers || []
//         shoe.count = shoe.buyers.length || 0
//         shoe.isBought = shoe.buyers.includes(getUser().email)
      
//         //if (shoe._ownerId == getUser().localId) {  //just in case :)
//         Object.assign(context, getUser(), shoe)
//         await preloadPartials(context)
//         this.partial('/templates/details.hbs')
//         //}

//     } catch (error) {
//         showError(error.message)
//     }

// }

// export async function editOfferPage(context) {
//     try {
//         let post = await getApiOfferById(context.params._id)
//         // if (post._ownerId == getUser().localId) {
//         Object.assign(context, getUser(), post)
//         await preloadPartials(context)

//         this.partial('/templates/edit.hbs')
//         //}

//     } catch (error) {
//         showError(error.message)
//     }

// }

// export async function editOfferPost(context) {
//     let postId = context.params._id;
//     let { model, price, imgURL, description, brand } = context.params
//     try {
//         if (getUser()) {
//             if (model == '' ||
//                 price == '' ||
//                 imgURL == '' ||
//                 description == '' ||
//                 brand == '') {
//                 throw new Error('All fields are required')
//             }
//             let editedpost = Object.assign({}, context.params)

//             let response = await editApiOfferById(postId, editedpost);
//             showInfo('The post is edited')
//             context.redirect(`/home`)
//         }

//     } catch (error) {
//         showError(error.message)
//     }


// }




// export async function deleteOfferPage(context) {
//     let postId = context.params._id;
//     try {
//         if (getUser()) {
//             let post = await getApiOfferById(postId)
//             if (post._ownerId == getUser().localId) {
//                 let response = await deleteOfferById(postId)
//                 showInfo('The post is deleted')
//                 this.redirect(`/home`)
//             }
//         }


//     } catch (error) {
//         showError(error.message)
//     }

// }

// export async function buyOfferPage(context) {

//     let id = context.params._id;
//     try {
//         let offer = await getApiOfferById(id)

//         if (offer._ownerId != getUser().localId) {

//             offer.buyers = offer.buyers || [];

//             offer.buyers.push(getUser().email)

//             if (!offer.buyers.includes(getUser().email)) {
//                 offer.buyers.push(getUser().email)
//             }


//             let response = await editApiOfferById(id, { buyers: offer.buyers })

//             this.redirect(`/details/${id}`)

//         }
//     } catch (error) {
//         showError(error.message)
//     }




// }
