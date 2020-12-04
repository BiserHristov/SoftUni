// import { createApiPost, deletePostById, editApiPostById, getApiPostById } from "../data.js";
import { createApiPost, getApiItemById, editApiItemById, deleteItemById } from "../data.js";
import { showError, showInfo } from "../notification.js";
import { errorHandler, getUser, preloadPartials } from "./util.js";



export async function createPage(context) {
    Object.assign(context, getUser())
    await preloadPartials(context)
    this.partial('/templates/create.hbs')
}
export async function createPost(context) {

    let post = Object.assign({}, context.params)
    post._ownerId = getUser().localId;

    try {
        let response = await createApiPost(post)
        showInfo('Sucessfully created post!')
        context.redirect('/home')

    } catch (error) {
        showError(error.message)
    }

}

export async function detailsPage(context) {
    try {
        let shoe = await getApiItemById(context.params._id)
        shoe.isOwner = getUser().localId == shoe._ownerId
        shoe.buyers = shoe.buyers || []
        shoe.count = shoe.buyers.length || 0
        shoe.isBought = shoe.buyers.includes(getUser().email)
        Object.assign(context, getUser(), shoe)
        await preloadPartials(context)
        this.partial('/templates/details.hbs')


    } catch (error) {
        showError(error.message)
    }


}

export async function editPage(context) {
    try {
        let shoe = await getApiItemById(context.params._id)
     
        if (shoe._ownerId == getUser().localId) {
            Object.assign(context, getUser(), shoe)
            await preloadPartials(context)

            this.partial('/templates/edit.hbs')
        }

    } catch (error) {
        showError(error.message)
    }

}

export async function editPost(context) {
    let shoeId = context.params._id;
    let { name, brand, imgURL, description } = context.params
    try {
        if (getUser()) {
            if (name == '' ||
                brand == '' ||
                imgURL == '' ||
                description == ''
            ) {
                throw new Error('All fields are required')
            }
            let editedShoe = Object.assign({}, context.params)

            let response = await editApiItemById(shoeId, editedShoe);
            showInfo('The post is edited')
            context.redirect(`/home`)
        }

    } catch (error) {
        showError(error.message)
    }


}


export async function deletePage(context) {
    let shoeId = context.params._id;
    try {
        if (getUser()) {
            let shoe = await getApiItemById(shoeId)
            if (shoe._ownerId == getUser().localId) {
                let response = await deleteItemById(shoeId)
                showInfo('The post is deleted')
                this.redirect(`/home`)
            }
        }


    } catch (error) {
        showError(error.message)
    }

}


export async function buyOfferPage(context) {
    let shoeId = context.params._id;
    try {

        let shoe = await getApiItemById(shoeId)
        shoe.buyers = shoe.buyers || [];
        shoe.buyers.push(getUser().email)

        let response = await editApiItemById(shoeId, { buyers: shoe.buyers })
        showInfo('You just boight the shoe')
        this.redirect(`/home`)




    } catch (error) {
        showError(error.message)
    }
}