import { getAllApiPostsByUser } from "../data.js";
import { getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    if (getUser()) {
        let posts = await getAllApiPostsByUser(getUser().localId)
        posts = posts.filter(p => p._ownerId == getUser().localId) //just in case :)
        context = Object.assign(context, getUser(), { posts });
    }

    await preloadPartials(context)
    this.partial('/templates/home.hbs', context)
}