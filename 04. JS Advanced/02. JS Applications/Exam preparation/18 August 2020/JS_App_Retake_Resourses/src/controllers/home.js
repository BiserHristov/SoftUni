import { getAllApiShoes } from "../data.js";
import { getUser, preloadPartials } from "./util.js"

export async function homePage(context) {

    context = Object.assign(context, getUser());

    let shoes = await getAllApiShoes()
    context.shoes = shoes;

    await preloadPartials(context)
    this.partial('/templates/home.hbs', context)
}