function solve() {

    let authorElement = document.querySelector('#creator');
    let titleElement = document.querySelector('#title');
    let categoryElement = document.querySelector('#category');
    let contentElement = document.querySelector('#content');
    let addBtn = document.querySelector('.btn.create');

    addBtn.addEventListener('click', function (addBtnEvent) {
        addBtnEvent.preventDefault();
        let article = create('article');
        let h1 = create('h1', `${titleElement.value}`)
        let pCat = create('p');
        pCat.innerHTML = `Category:<strong>${categoryElement.value}</strong>`;
        let pCr = create('p');
        pCr.innerHTML = `Creator:<strong>${authorElement.value}</strong>`;
        let pContent = create('p', `${contentElement.value}`)
        let div = create('div', '', { classList: 'buttons' });
        let delBtn = create('button', 'Delete', { classList: 'btn delete' })
        let archiveBtn = create('button', 'Archive', { classList: 'btn archive' })

        div.appendChild(delBtn);
        div.appendChild(archiveBtn);

        article.appendChild(h1);
        article.appendChild(pCat);
        article.appendChild(pCr);
        article.appendChild(pContent);
        article.appendChild(div);

        let section = document.querySelector('main section');
        section.appendChild(article);

        archiveBtn.addEventListener('click', function (archiveBtnEvent) {
            let ulArchive = document.querySelector('section.archive-section ul');
            let liArr = []
            Array.from(ulArchive.children).forEach(el => liArr.push(el.textContent));
            liArr.push(`${h1.textContent}`)
            liArr = liArr.sort((curr, next) => curr.toLowerCase().localeCompare(next.toLowerCase()))
            ulArchive.innerHTML = '';

            while (liArr.length > 0) {
                let li = create('li', `${liArr.shift()}`)
                ulArchive.appendChild(li);
            }

            article.remove();
        })

        delBtn.addEventListener('click', function () {
            article.remove();

        })


        authorElement.value = ''
        titleElement.value = ''
        categoryElement.value = ''
        contentElement.value = ''
        addBtn.value = ''

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
