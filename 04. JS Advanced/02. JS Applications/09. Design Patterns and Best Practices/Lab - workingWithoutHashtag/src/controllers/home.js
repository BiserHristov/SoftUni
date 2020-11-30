import { getAllOffers } from "../data.js";
import { errorHandler, getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    Object.assign(context, getUser());
    try {
        let offers = await getAllOffers();
        offers.sort((curr, next) => next.buyers.length - curr.buyers.length)
        Object.assign(context, { offers })
        await preloadPartials(context)
        this.partial('/templates/home.hbs', context)
    } catch (error) {
        errorHandler(error)
    }

}