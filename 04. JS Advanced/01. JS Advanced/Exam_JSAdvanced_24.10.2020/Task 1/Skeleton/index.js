function solve() {

    let inputs = Array.from(document.querySelectorAll('div.form-control'));
    let addBtnElement = inputs[3].querySelector('button');

    addBtnElement.addEventListener('click', function (addBtnElementEvent) {
        addBtnElementEvent.preventDefault();
        let nameElement = inputs[0].querySelector('input');
        let dateElement = inputs[1].querySelector('input');
        let moduleElement = inputs[2].querySelector(`select`);

        if (nameElement.value == '' ||
            dateElement.value == '' ||
            moduleElement.value == '' ||
            moduleElement.value == 'Select module') {
            return;
        }

        let date = dateElement.value.split('T')[0];

        while (date.indexOf('-') > 0) {
            date = date.replace('-', '/');
        }

        let hour = dateElement.value.split('T')[1];

        let div = create('div', '', { classList: 'module' });
        let h3 = create('h3', `${moduleElement.value.toUpperCase()}-MODULE`)
        let ul = create('ul');
        let li = create('li', '', { classList: 'flex' })
        let h4 = create('h4', `${nameElement.value} - ${date} - ${hour}`);
        let delBtn = create('button', 'Del', { classList: 'red' })

        li.appendChild(h4);
        li.appendChild(delBtn);
        ul.appendChild(li);

        div.appendChild(h3);
        div.appendChild(ul);

        let trainingDiv = document.querySelector('div.modules');
        let existingH3 = Array.from(trainingDiv.querySelectorAll('h3'))
            .find(e => e.textContent == `${moduleElement.value.toUpperCase()}-MODULE`)

        if (existingH3) {
            existingH3.nextElementSibling.appendChild(li)
            let liForSort = Array.from(existingH3.nextElementSibling.children);
            let arr = [];
            liForSort.forEach(el => {
                let [lecture, date, time] = Array.from(el.children[0].textContent.split(' - '));
                let obj = { lecture, date, time }
                arr.push(obj)

            });

            arr.sort((curr, next) => curr.date.localeCompare(next.date))


            for (let i = 0; i < liForSort.length; i++) {
                let currentLi = liForSort[i];
                currentLi.children[0].textContent = `${arr[i].lecture} - ${arr[i].date} - ${arr[i].time}`

            }
        }
        else {
            trainingDiv.appendChild(div);
        }


        delBtn.addEventListener('click', function (delBtnEvent) {

            if (delBtnEvent.target.parentElement.parentElement.childElementCount > 1) {
                delBtnEvent.target.parentElement.remove();
            }
            else {
                delBtnEvent.target.parentElement.parentElement.parentElement.remove();
            }

        })


    })

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
};