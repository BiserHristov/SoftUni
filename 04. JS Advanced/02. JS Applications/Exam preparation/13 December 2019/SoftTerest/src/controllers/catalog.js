import { createApiIdea, getApiIdeaById, updateApiIdeaByOwnerAndId, deleteIdeaByOwnerAndId } from "../data.js";
import { showError, showInfo } from "../notification.js";
import { errorHandler, getUser, preloadPartials } from "./util.js";

export async function createPage(context) {

    Object.assign(context, getUser())
    await preloadPartials(context)

    this.partial('/templates/create.hbs')

}


export async function createPost(context) {
    try {
        let { title, description, imageURL } = context.params
        if (title.length < 6) {
            throw new Error('Title must be at least 6 chars long')
        }
        if (description.length < 10) {
            throw new Error('Description must be at least 10 chars long')
        }

        if (!imageURL.startsWith('http://') && !imageURL.startsWith('https://')) {
            throw new Error('imageURL should start with http:// or https://')
        }

        let idea = Object.assign({}, context.params)
        idea._ownerId = getUser().localId;
        idea.likes = 0;
        idea.comments = [];


        let response = await createApiIdea(idea)
        showInfo('Idea created')
        context.redirect('/home')

    } catch (error) {
        showError(error.message)
    }

}

export async function detailsPage(context) {
    let { _ownerId, _id } = context.params


    try {
        let idea = await getApiIdeaById(_ownerId, _id)
        idea.isCreator = idea._ownerId == getUser().localId
        Object.assign(context, getUser(), idea)
        await preloadPartials(context)
        this.partial('/templates/details.hbs')


    } catch (error) {
        showError(error.message)
    }


}

export async function commentPost(context) {
    try {
        let { newComment, _ownerId, _id } = context.params
        newComment = `${getUser().email.split('@')[0]} : ${newComment}`
        if (_ownerId == getUser().localId) {
            return
        }

        let comments = Array.from(document.querySelectorAll('.comment')).map(e => e.textContent)
        if (comments.length == 1 && comments[0] == 'No comments yet :(') {
            comments = [];
            comments.push(newComment)
        } else {
            comments.push(newComment)
        }
        let updatedObj = {
            comments
        }

        let idea = await updateApiIdeaByOwnerAndId(_ownerId, _id, updatedObj)

        Object.assign(context, getUser())


        context.redirect(`/details/${_ownerId}/${_id}`)


    } catch (error) {
        showError(error.message)
    }

}

export async function likePage(context) {
    try {
        let { _ownerId, _id } = context.params

        if (_ownerId == getUser().localId) {
            return
        }

        let likes = Number(document.querySelector('large').textContent);
        likes++;

        let updatedObj = {
            likes
        }

        let idea = await updateApiIdeaByOwnerAndId(_ownerId, _id, updatedObj)

        Object.assign(context, getUser())


        context.redirect(`/details/${_ownerId}/${_id}`)


    } catch (error) {
        showError(error.message)
    }

}

export async function deletePage(context) {
    let { _ownerId, _id } = context.params
    try {
        if (getUser()) {
            if (_ownerId == getUser().localId) {
                let response = await deleteIdeaByOwnerAndId(_ownerId, _id)
                showInfo("Idea deleted successfully.")
                this.redirect(`/home`)
            }
        }


    } catch (error) {
        showError(error.message)
    }

}






