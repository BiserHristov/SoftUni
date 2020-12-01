import { getUser, preloadPartials } from "./util.js"
import { getAllApiIdeas } from "../data.js"

export async function homePage(context) {

    if (getUser()) {
        let ideas = await getAllApiIdeas()
        ideas = ideas.sort((curr, next) => next.likes - curr.likes)
        context = Object.assign(context, getUser(), { ideas });
    }

    await preloadPartials(context)
    this.partial('/templates/home.hbs', context)


}