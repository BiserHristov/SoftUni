import { getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    context = Object.assign(context, getUser());

    await preloadPartials(context)
    this.partial('/templates/home.hbs', context)
}