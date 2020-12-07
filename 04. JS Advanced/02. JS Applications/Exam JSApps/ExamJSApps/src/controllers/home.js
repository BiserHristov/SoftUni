import { getAllOffers } from "../data.js";
import { showError, hideLoading, showLoading } from "../notification.js";
import { getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    try {
        showLoading();
        let destinations = await getAllOffers();
        hideLoading();
        Object.assign(context, getUser(), { destinations })
        await preloadPartials(context)
        this.partial('/templates/home.hbs', context)
    } catch (error) {
        showError(error.message)
    }
}