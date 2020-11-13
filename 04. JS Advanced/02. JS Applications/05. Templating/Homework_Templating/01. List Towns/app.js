window.addEventListener('load', () => {

    const inputElement = document.querySelector('#towns')
    let divElement = document.querySelector('#root')

    document.querySelector('#btnLoadTowns').addEventListener('click', renderBooks);

    function renderBooks(e) {
        e.preventDefault();
        const towns = inputElement.value.split(', ')
        let mainPromise = fetch('./templates/main-template.hbs').then(response => response.text())
        let partialPromise = fetch('./templates/town-template.hbs').then(response => response.text())

        Promise.all([mainPromise, partialPromise])
            .then(([mainPromise, partialPromise]) => {
                Handlebars.registerPartial('town', partialPromise)
                const templateFn = Handlebars.compile(mainPromise)
                const generatedHtml = templateFn({ towns })
                divElement.innerHTML = generatedHtml
                inputElement.value = ''
            })
            .catch(e => console.error(e))

    }
})


//ANOTHER WORKING SOLUTION (async->await)!

// window.addEventListener('load', async () => {

//     const htmlView = await (await fetch('./templates/main-template.hbs')).text()
//     Handlebars.registerPartial('town', await (await fetch('./templates/town-template.hbs')).text())

//     const templateFn = Handlebars.compile(htmlView)

//     document.querySelector('#btnLoadTowns').addEventListener('click', renderBooks);


//     const inputElement = document.querySelector('#towns')
//     let divElement = document.querySelector('#root')

//     function renderBooks(e) {
//         e.preventDefault();

//         const towns = inputElement.value.split(', ')
//         const generatedHtml = templateFn({ towns })
//         divElement.innerHTML = generatedHtml

//     }
// })



