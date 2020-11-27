import { getURL, preloadPartials, errorHandler } from './util.js'
import { login, register, getAllOffers, createOffer, getOfferByKey, editOffer, deleteOffer as apiDelete } from '../data.js'

export async function createPage(context) {
    await preloadPartials(context)

    this.partial('./templates/create-offer.hbs')

}

export async function createPost(context) {

    let { model, price, imgURL, description, brand } = context.params

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
        owner: JSON.parse(localStorage.loggedUser).email,
        buyers: []
    }

    await createOffer(offer)
    this.redirect('#/home')

}

export async function editPage(context) {

    let offer = await getOfferByKey(context.params.key)
    context = Object.assign({ offer }, this.app.userData);
    await preloadPartials(context);
    this.partial('./templates/edit.hbs')

    // context.key = context.params.key
    // fetch(getURL(context.params.key))
    //     .then(res => res.json())
    //     .then(data => {
    //         context.brand = data.brand
    //         context.model = data.model
    //         context.imgURL = data.imgURL
    //         context.description = data.description
    //         context.price = data.price

    //         preloadPartials(context)
    //             .then(function () {
    //                 this.partial('./templates/edit.hbs')

    //             })

    //     })
    //     .catch(errorHandler)

}

export async function editPost(context) {
    const { model, price, imgURL, description, brand } = context.params
    let editedOffer = {
        model,
        price,
        imgURL,
        description,
        brand
    }

    await editOffer(context.params.key, editedOffer)
    this.redirect(`#/details/${context.params.key}`)

    // const { model, price, imgURL, description, brand } = context.params
    // let editedOffer = {
    //     model,
    //     price,
    //     imgURL,
    //     description,
    //     brand
    // }

    // fetch(getURL(context.params.key), { method: 'PATCH', body: JSON.stringify(editedOffer) })
    //     .then(res => res.json())
    //     .then(data => {
    //         this.redirect(`#/details/${context.params.key}`)
    //     })
    //     .catch(errorHandler)
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
    context.isOwner = offer.owner == JSON.parse(localStorage.loggedUser).email
    context.notBought = true;

    if (offer.buyers) {
        context.notBought = !offer.buyers.some(b => b == JSON.parse(localStorage.loggedUser).email)
    }

    await preloadPartials(context)

    this.partial('./templates/details.hbs')

    // let key = context.params.key
    // fetch(getURL(key))
    //     .then(response => response.json())
    //     .then(data => {
    //         let { brand, model, imgURL, description, price, buyers } = data
    //         context.brand = brand
    //         context.model = model
    //         context.imgURL = imgURL
    //         context.description = description
    //         context.price = price
    //         context.key = key
    //         context.count = (buyers || []).length
    //         context.isOwner = data.owner == JSON.parse(localStorage.loggedUser).email


    //         context.notBought = true;

    //         if (data.buyers) {
    //             context.notBought = !data.buyers.some(b => b == JSON.parse(localStorage.loggedUser).email)
    //         }

    //         preloadPartials(context)
    //             .then(function () {
    //                 this.partial('./templates/details.hbs')

    //             })
    //     })
    //     .catch(errorHandler)



}

export async function detailsPage(context) {
    await preloadPartials(context)

    this.partial('./templates/details.hbs')


}

export async function deleteOffer(context) {
    let key = context.params.key
    await apiDelete(key)
    this.redirect(`#/home`)
    // let key = context.params.key

    // fetch(getURL(key), { method: 'DELETE' })
    //     .then(response => response.json())
    //     .then(data => {
    //         this.redirect(`#/home`)
    //     })
    //     .catch(errorHandler)


}

export function buyPage(context) {
    let key = context.params.key

    fetch(getURL(key))
        .then(response => response.json())
        .then(data => {

            let updatedBuyers = []
            let currentUser = JSON.parse(localStorage.loggedUser).email
            if (data.hasOwnProperty('buyers')) {
                updatedBuyers = [currentUser, ...data.buyers]
            } else {
                updatedBuyers.push(currentUser)
            }

            let updatedBuyersObj = {
                buyers: updatedBuyers
            }

            fetch(getURL(key), { method: 'PATCH', body: JSON.stringify(updatedBuyersObj) })
                .then(response => response.json())
                .then(data => {


                    this.redirect(`#/details/${key}`)


                })
                .catch(errorHandler)
        })

}