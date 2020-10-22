function solve() {
    let inputElements = Array.from(document.querySelectorAll('#container input'));
    let onScreenBtn = document.querySelector('#container button')

    onScreenBtn.addEventListener('click', function (onScreenEvent) {
        onScreenEvent.preventDefault();
        let nameElement = inputElements[0];
        let hallElement = inputElements[1];
        let priceElement = inputElements[2];

        if (nameElement.value == '' ||
            hallElement.value == '' ||
            priceElement.value == '' ||
            isNaN(priceElement.value)) {
            return
        }

        let li = create('li');
        let span = create('span', `${nameElement.value}`);
        let strong = create('strong', `Hall: ${hallElement.value}`)
        let div = create('div');
        let strongDiv = create('strong', `${priceElement.value}`)
        let ticketCountInput = create('input', '', { placeholder: 'Tickets Sold' })
        let archiveBtn = create('button', 'Archive');

        div.appendChild(strongDiv);
        div.appendChild(ticketCountInput);
        div.appendChild(archiveBtn);

        li.appendChild(span);
        li.appendChild(strong);
        li.appendChild(div);

        let ulMovies = document.querySelector('#movies ul');
        ulMovies.appendChild(li);

        archiveBtn.addEventListener('click', function (archiveBtnEvent) {
            if (ticketCountInput.value == '' || isNaN(ticketCountInput.value)) {
                return
            }
            let price = Number(archiveBtnEvent.target.parentElement.children[0].textContent)
            let name = archiveBtnEvent.target.parentElement.parentElement.children[0].textContent;
            let liArchive = create('li');
            let spanArchive = create('span', `${name}`);
            let strongArchive = create('strong', `Total amount: ${(ticketCountInput.value * price).toFixed(2)}`)
            let deleteBtn = create('button', 'Delete');

            liArchive.appendChild(spanArchive);
            liArchive.appendChild(strongArchive);
            liArchive.appendChild(deleteBtn);

            let ulArchive = document.querySelector('#archive ul');
            ulArchive.appendChild(liArchive);

            li.remove();

            deleteBtn.addEventListener('click', function () {
                liArchive.remove();
            })
        })

        nameElement.value = ''
        hallElement.value = ''
        priceElement.value = ''
    })


    let clearBtn = document.querySelector('#archive button');

    clearBtn.addEventListener('click', function (clearBtnEvent) {
        clearBtnEvent.target.previousElementSibling.innerHTML = '';
    })



    //const inputEl = create('input', '', { placeholder: 'Enter your names' });
    function create(type, content, attributes) {
        let result = document.createElement(type);

        if (content) {
            result.textContent = content;
        }

        if (attributes) {
            Object.assign(result, attributes);
        }

        return result;
    }
}