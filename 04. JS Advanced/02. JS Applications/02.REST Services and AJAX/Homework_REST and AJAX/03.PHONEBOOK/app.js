function attachEvents() {

    let ul = document.querySelector('#phonebook');
    let loadBtn = document.querySelector('#btnLoad');
    loadBtn.addEventListener('click', (e) => {
        ul.innerHTML = ''
        fetch(getURL())
            .then(response => response.json())
            .then(data => {
                Object.entries(data).forEach(([key, value]) => {
                    let li = document.createElement('li');
                    let button = document.createElement('button');
                    button.textContent = 'Delete';
                    li.textContent = `${value.person}:${value.phone}`
                    li.appendChild(button)
                    ul.appendChild(li);

                    button.addEventListener('click', (buttonEvent) => {
                        fetch(getURL(key), { method: 'DELETE' })
                        buttonEvent.target.parentElement.remove();
                    })

                });
            })
    })

    let createBtn = document.querySelector('#btnCreate');
    createBtn.addEventListener('click', () => {
        let name = document.querySelector('#person');
        let phone = document.querySelector('#phone');

        let person = {
            person: name.value,
            phone: phone.value
        }

        fetch(getURL(), { method: 'POST', body: JSON.stringify(person) })

        name.value = ''
        phone.value = ''

    })


    function getURL(postfix) {
        let result = `https://phonebook-nakov.firebaseio.com/phonebook` + (postfix ? `/${postfix}` : '') + `.json`
        return result;
    }
}

attachEvents();