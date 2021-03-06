import { getURL, preloadPartials, errorHandler } from './util.js'
import { createOffer, editOffer, getOfferByKey, deleteOffer as apiDelete, buyOffer } from '../data.js'




export async function createPage(context) {
    context = Object.assign(context, this.app.userData)
    await preloadPartials(context)
    this.partial('./templates/create-offer.hbs') 
}

export async function createPost(context) {

    let { model, price, imgURL, description, brand } = this.params

    if (model == '' ||
        price == '' ||
        imgURL == '' ||
        description == '' ||
        brand == '') {
        alert("All fields are required")
        return
    }

    let offer = {
        model,
        price,
        imgURL,
        description,
        brand,
        owner: this.app.userData.email,
        buyers: []
    }
    try {
        await createOffer(offer);

        this.redirect('#/home')

    } catch (error) {
        console.error(error)
    }

}

export async function editPage(context) {
    let key = context.params.key;
    let offer = await getOfferByKey(key)
    context = Object.assign(context, offer, this.app.userData);
    context.key = key;
    await preloadPartials(context);
    this.partial('./templates/edit.hbs')

}

export async function editPost(context) {

    const { model, price, imgURL, description, brand } = this.params
    let editedOffer = {
        model,
        price,
        imgURL,
        description,
        brand
    }

    await editOffer(this.params.key, editedOffer)
    this.redirect(`#/details/${this.params.key}`)
}

export async function detailsOffer(context) {
    let key = context.params.key

    let offer = await getOfferByKey(key)
    let { brand, model, imgURL, description, price, buyers } = offer
    context.brand = brand
    context.model = model
    context.imgURL = imgURL
    context.description = description
    context.price = price
    context.key = key
    context.count = (buyers || []).length
    context.email = this.app.userData.email
    context.isOwner = offer.owner == this.app.userData.email
    context.isLoggedIn = this.app.userData.isLoggedIn
    context.notBought = true;

    if (offer.buyers) {
        context.notBought = !offer.buyers.some(b => b == JSON.parse(localStorage.loggedUser).email)
    }

    await preloadPartials(context)

    this.partial('./templates/details.hbs')


}

export async function detailsPage(context) {
    await preloadPartials(context)

    this.partial('./templates/details.hbs')

}

export async function deleteOffer(context) {
    let key = context.params.key
    await apiDelete(key)
    this.redirect(`#/home`)


}

export async function buyPage(context) {
    let key = context.params.key
    await buyOffer(context)

    this.redirect(`#/details/${key}`)



}