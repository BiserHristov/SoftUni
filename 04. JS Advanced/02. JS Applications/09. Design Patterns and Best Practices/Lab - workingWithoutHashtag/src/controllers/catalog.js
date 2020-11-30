import { createOffer, deleteOfferById, editOfferById, getOfferById } from "../data.js";
import { errorHandler, getUser, preloadPartials } from "./util.js";

export async function createOfferPage(context) {

    Object.assign(context, getUser())
    await preloadPartials(context)
    this.partial('/templates/create-offer.hbs')
}

export async function createOfferPost(context) {

    let offer = Object.assign({}, context.params)
    offer._ownerId = getUser().localId;

    try {
        let response = await createOffer(offer)
        context.redirect('/home')

    } catch (error) {
        errorHandler(error);
    }

}

export async function detailsPage(context) {
    try {
        let offer = await getOfferById(context.params._id)
        offer.count = offer.buyers ? offer.buyers.length : 0
        offer.isOwner = offer._ownerId == getUser().localId;
        offer.notBought = offer.buyers ? !offer.buyers.some(e => e == getUser().email) : true
        Object.assign(context, getUser(), offer)
        await preloadPartials(context)
        this.partial('/templates/details.hbs')

    } catch (error) {
        errorHandler(error);
    }


}

export async function editOfferPage(context) {
    try {
        let offer = await getOfferById(context.params._id)
        Object.assign(context, getUser(), offer)
        await preloadPartials(context)
        this.partial('/templates/edit.hbs')
    } catch (error) {
        errorHandler(error);
    }

}

export async function editOfferPost(context) {
    let id = context.params._id;
    let { model, price, imgURL, description, brand } = context.params
    try {
        if (model == '' ||
            price == '' ||
            imgURL == '' ||
            description == '' ||
            brand == '') {
            throw new Error('All fields are required')
        }
        let editedOffer = Object.assign({}, context.params)
        let response = await editOfferById(id, editedOffer);
        context.redirect(`/details/${id}`)
    } catch (error) {
        errorHandler(error);
    }


}




export async function deleteOfferPage(context) {

    try {
        let response = await deleteOfferById(context.params._id)
        this.redirect(`/home`)
    } catch (error) {
        errorHandler(error);
    }

}

export async function buyOfferPage(context) {

    let id = context.params._id;
    try {
        let offer = await getOfferById(id)

        if (offer._ownerId != getUser().localId) {

            if (!offer.buyers) {
                offer.buyers = []
                offer.buyers.push(getUser().email)
            } else {
                if (!offer.buyers.some(e => e == getUser().email)) {
                    offer.buyers.push(getUser().email)
                }
            }


            let response = await editOfferById(id, offer)

            this.redirect(`/details/${id}`)

        }
    } catch (error) {

    }




}