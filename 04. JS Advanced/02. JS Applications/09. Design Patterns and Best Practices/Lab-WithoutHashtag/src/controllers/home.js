import { getURL, preloadPartials, checkForError,errorHandler } from './util.js'
export async function homePage(context) {

    let shoes = []

    try {
        let data = await (await fetch(getURL())).json()
        checkForError(data)
        data = data || {}

        Object.entries(data).forEach(([key, value]) => {
            let { model, price, imgURL, description, brand, buyers } = value

            let shoe = {
                key,
                model,
                price,
                imgURL,
                description,
                brand,
                buyers: buyers || []

            }

            shoes.push(shoe)

        });

        shoes = shoes.sort((curr, next) => next.buyers.length - curr.buyers.length)

    } catch (error) {
        errorHandler(error)
    }

    await preloadPartials(context)
    const data = Object.assign({ shoes }, this.app.userData)
    this.partial('templates/home.hbs', data)


}