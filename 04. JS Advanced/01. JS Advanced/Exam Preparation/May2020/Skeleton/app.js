function solve() {
    let taskEl = document.querySelector('#task');
    let descriptionEl = document.querySelector('#description');
    let dateEl = document.querySelector('#date');
    let addBtn = document.querySelector('#add');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (taskEl.value == "" ||
            descriptionEl.value == "" ||
            dateEl.value == "") {
            return;
        }

        let article = create('article');
        let h3 = create('h3', taskEl.value);
        let decP = create('p', `Description: ${descriptionEl.value}`);
        let dateP = create('p', `Due Date: ${dateEl.value}`);
        let div = create('div', '', { classList: 'flex' });
        let btnGreen = create('button', 'Start', { classList: 'green' });
        let btnRed = create('button', 'Delete', { classList: 'red' });

        //let deleteBtn = document.querySelector("div.flex button[class='red']");
        btnRed.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        })

        //let startBtn = document.querySelector("div.flex button[class='green']");
        btnGreen.addEventListener('click', (e) => {

            let InProgressBtns = Array.from(article.querySelectorAll('button'))
            InProgressBtns[0].classList = 'red';
            InProgressBtns[0].textContent = 'Delete';
            InProgressBtns[1].classList = 'orange';
            InProgressBtns[1].textContent = 'Finish';
            let inProgressOpenDiv = document.querySelectorAll('section')[2].children[1]
            inProgressOpenDiv.appendChild(article);

            InProgressBtns = Array.from(article.querySelectorAll('button'))
            InProgressBtns[0].addEventListener('click', (event) => {
                event.target.parentElement.parentElement.remove();

            })

            InProgressBtns[1].addEventListener('click', (event) => {

                let completeDiv = document.querySelectorAll('section')[3].children[1]
                completeDiv.appendChild(article)
                event.target.parentElement.remove();
            })

        })

        article.appendChild(h3)
        article.appendChild(decP)
        article.appendChild(dateP)
        div.appendChild(btnGreen)
        div.appendChild(btnRed)
        article.appendChild(div)
        let openDiv = document.querySelectorAll('section')[1].children[1]
        openDiv.appendChild(article);



        taskEl.value = '';
        descriptionEl.value = ''
        dateEl.value = ''


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