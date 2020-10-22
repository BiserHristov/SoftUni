function solve() {

    let nameEl = document.querySelector('#container').children[0];
    let ageEl = document.querySelector('#container').children[1];
    let kindEl = document.querySelector('#container').children[2];
    let ownerEl = document.querySelector('#container').children[3];
    let addBtn = document.querySelector('#container').children[4];



    addBtn.addEventListener('click', function (e) {
        e.preventDefault();

        if (nameEl.value == '' ||
            ageEl.value == '' ||
            kindEl.value == '' ||
            ownerEl.value == '' ||
            isNaN(ageEl.value)) {
            return
        }

        let li = create('li');
        let p = create('p');
        p.innerHTML = (`<strong>${nameEl.value}</strong> is a <strong>${ageEl.value}</strong> year old <strong>${kindEl.value}</strong>`);
        let span = create('span', `Owner: ${ownerEl.value}`)
        let petButtonElement = create('button', 'Contact with owner')

        li.appendChild(p);
        li.appendChild(span);
        li.appendChild(petButtonElement)

        let adoptionUlElement = document.querySelector('#adoption ul');
        adoptionUlElement.appendChild(li)


        nameEl.value = '';
        ageEl.value = '';
        kindEl.value = '';
        ownerEl.value = '';
        petButtonElement.addEventListener('click', function (contactEvent) {

            petButtonElement.remove();

            let div = create('div');
            let input = create('input', '', { placeholder: 'Enter your names' })
            let takeBtn = create('button', 'Yes! I take it!')


            div.appendChild(input);
            div.appendChild(takeBtn);
            li.appendChild(div);
            takeBtn.addEventListener('click', function (takeEvent) {

                if (input.value == '') {
                    return
                }

                let spanForDelete = li.querySelector('span');
                let divForDelete = li.querySelector('div');

                let checkedBtn = create('button', 'Checked')
                let newOwnerSpan = create('span', `New Owner: ${input.value}`)
                spanForDelete.remove();
                divForDelete.remove();
                li.appendChild(newOwnerSpan);
                li.appendChild(checkedBtn);
                let adoptedUlElement = document.querySelector('#adopted ul');
                adoptedUlElement.appendChild(li)

                checkedBtn.addEventListener('click', function (checkedEvent) {

                    li.remove();
                })




            })




        })


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
