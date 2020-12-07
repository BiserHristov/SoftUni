import { createApiOffer, editApiOfferById, getAllApiDestByUser, getApiOfferById, deleteDestByOwnerAndId } from "../data.js";
import { showError, showInfo, showLoading, hideLoading } from "../notification.js";
// import { showError, showInfo } from "../notification.js";
import { errorHandler, getUser, preloadPartials } from "./util.js";



export async function createOfferPage(context) {

    Object.assign(context, getUser())
    showLoading();
    await preloadPartials(context)
    hideLoading();
    this.partial('/templates/create.hbs')
}

export async function createOfferPost(context) {


    let { destination, city, duration, departureDate, imgUrl } = context.params
    try {
        if (destination == '' ||
            city == '' ||
            duration == '' ||
            departureDate == '' ||
            imgUrl == '') {
            throw new Error('All fields are required!')
        }

        if (duration < 1 || duration > 100) {
            throw new Error('Duration should be between 1 and 100!')
        }

        let dest = Object.assign({}, context.params)
        dest._ownerId = getUser().localId;

        showLoading();
        let response = await createApiOffer(dest)
        hideLoading();
        showInfo('Destination added sucessfully!')
        context.redirect('/home')

    } catch (error) {
        showError(error.message)
    }

}

export async function detailsPage(context) {
    let { _ownerId, _id } = context.params
    try {
        showLoading();
        let dest = await getApiOfferById(_ownerId, _id)
        hideLoading();
        dest.isOwner = getUser().localId == dest._ownerId
        let dateArr = dest.departureDate.split('-');
        let year = dateArr[0];
        var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        let month = months[dateArr[1] - 1]
        let date = dateArr[2]
        dest.departureDate = `${date} ${month} ${year}`

        Object.assign(context, getUser(), dest)
        await preloadPartials(context)
        this.partial('/templates/details.hbs')


    } catch (error) {

        showError(error.message)
    }

}

export async function editOfferPage(context) {

    let { _ownerId, _id } = context.params

    if (_ownerId != getUser().localId) {
        return
    }

    try {
        showLoading();
        let dest = await getApiOfferById(getUser().localId, _id)
        hideLoading();
        if (dest._ownerId == getUser().localId) {
            dest.isOwner = true;
            Object.assign(context, getUser(), dest)
            await preloadPartials(context)

            this.partial('/templates/edit.hbs')
        }

    } catch (error) {
        showError(error.message)
    }

}

export async function editOfferPost(context) {
    let destId = context.params._id;
    let { destination, city, duration, departureDate, imgUrl, _ownerId, _id } = context.params
    try {
        if (getUser()) {
            if (destination == '' ||
                city == '' ||
                duration == '' ||
                departureDate == '' ||
                imgUrl == '') {
                throw new Error('All fields are required')
            }

            if (duration < 1 || duration > 100) {
                throw new Error('Duration should be between 1 and 100!')
            }

            let editedDest = Object.assign({}, context.params)
            showLoading();
            let response = await editApiOfferById(getUser().localId, destId, editedDest);
            hideLoading();
            showInfo('Successfully edited destination.')
            context.redirect(`/details/${_ownerId}/${_id}`)
        }

    } catch (error) {
        showError(error.message)
    }


}

export async function myDestinationsPage(context) {

    let userId = getUser().localId
    try {
        showLoading();
        let destinations = await getAllApiDestByUser(userId)
        hideLoading();
        Object.assign(context, getUser(), { destinations })
        await preloadPartials(context)
        this.partial('/templates/userDestinations.hbs', context)

    } catch (error) {
        showError(error.message)
    }



}



export async function deleteOfferPage(context) {
    let { _ownerId, _id } = context.params
    try {
        if (getUser()) {
            if (_ownerId == getUser().localId) {
                showLoading();
                let response = await deleteDestByOwnerAndId(_ownerId, _id)
                hideLoading();
                showInfo("Destination deleted.")
                this.redirect(`/myDestinations`)
            }
        }


    } catch (error) {
        showError(error.message)
    }

}






