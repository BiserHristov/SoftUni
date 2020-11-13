window.addEventListener('load', () => {
    let divElement = document.querySelector('div.monkeys')

    fetch('./templates/monkey-template.hbs')
        .then(response => response.text())
        .then(htmlView => {

            let mokeyFn = Handlebars.compile(htmlView)
            let generatedHTML = mokeyFn({ monkeys })
            divElement.innerHTML = generatedHTML

        })

    divElement.addEventListener('click', showInfo)

    function showInfo(e) {
        if (e.target.tagName != 'BUTTON') {
            return
        }

        let pElement = e.target.nextElementSibling;

        pElement.style.display = pElement.style.display == 'none' ? 'block' : 'none'
    }


})