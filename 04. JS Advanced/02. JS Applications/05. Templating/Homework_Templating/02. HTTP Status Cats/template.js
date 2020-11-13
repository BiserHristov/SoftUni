window.addEventListener('load', () => {
    let element = {
        section: () => document.querySelector('#allCats')
    }

    fetch('./templates/main-template.hbs')
        .then(response => response.text())
        .then(htmlView => {
            let templateFn = Handlebars.compile(htmlView)
            let generatedHTML = templateFn({ cats })
            element.section().innerHTML = generatedHTML;
        })
        .catch(e => console.error(e))


    element.section().addEventListener('click', (e) => {
        if (e.target.tagName != 'BUTTON') {
            return
        }

        let infoDiv = e.target.nextElementSibling
        infoDiv.style.display = infoDiv.style.display == 'none' ? 'block' : 'none'
        e.target.textContent = (e.target.textContent.startsWith('Show') ? 'Hide' : 'Show') + ' status code'
    })
})
