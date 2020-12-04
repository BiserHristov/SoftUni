// import { getAllOffers } from "../data.js";
// import { showError } from "../notification.js";
// import { getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    try {
        // let shoes = await getAllOffers();
        // shoes.sort((curr, next) => next.buyers.length - curr.buyers.length)
        // Object.assign(context, getUser(), { shoes })
        await preloadPartials(context)
        this.partial('/templates/home.hbs', context)
    } catch (error) {
        showError(error.message)
    }
}