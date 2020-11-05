function attachEvents() {
    let addBtn = document.querySelector('button.add');
    let baseURL = 'https://fisher-game.firebaseio.com/catches'

    let angler = document.querySelector('#addForm input.angler');
    let weight = document.querySelector('#addForm input.weight');
    let species = document.querySelector('#addForm input.species');
    let location = document.querySelector('#addForm input.location');
    let bait = document.querySelector('#addForm input.bait');
    let captureTime = document.querySelector('#addForm input.captureTime');

    addBtn.addEventListener('click', () => {

        let fishCatch = {
            angler: angler.value,
            weight: weight.value,
            species: species.value,
            location: location.value,
            bait: bait.value,
            captureTime: captureTime.value
        }

        fetch(baseURL + '.json', { method: "POST", body: JSON.stringify(fishCatch) })

        angler.value = '';
        weight.value = ''
        species.value = ''
        location.value = '';
        bait.value = ''
        captureTime.value = ''

    })

    let loadBtn = document.querySelector('button.load');

    loadBtn.addEventListener('click', () => {

        fetch(baseURL + '.json')
            .then(response => response.json())
            .then(data => {
                let allCatchesDiv = document.querySelector('#catches');
                if (allCatchesDiv.childElementCount > 1) {

                    while (allCatchesDiv.childElementCount != 1) {
                        allCatchesDiv.children[1].remove();
                    }
                }
                Object.keys(data).forEach(key => {

                    let divCatch = create('div', '', { classList: 'catch' })
                    divCatch.setAttribute("data-id", `${key}`)

                    let anglerLabel = create('label', 'Anger')
                    let anglerInput = create('input', '', { classList: 'angler', type: 'text', value: `${data[key].angler}` })
                    let anglerHr = create('hr');

                    let weightLabel = create('label', 'Weight')
                    let weightInput = create('input', '', { type: 'number', classList: 'weight', value: `${data[key].weight}` })
                    let weightHr = create('hr');

                    let speciesLabel = create('label', 'Species')
                    let speciesInput = create('input', '', { type: 'text', classList: 'species', value: `${data[key].species}` })
                    let speciesHr = create('hr');

                    let locationLabel = create('label', 'Location')
                    let locationInput = create('input', '', { type: 'text', classList: 'location', value: `${data[key].location}` })
                    let locationHr = create('hr');

                    let baitLabel = create('label', 'Bait')
                    let baitInput = create('input', '', { type: 'text', classList: 'bait', value: `${data[key].bait}` })
                    let baitHr = create('hr');

                    let captureTimeLabel = create('label', 'Capture Time')
                    let captureTimeInput = create('input', '', { type: 'number', classList: 'captureTime', value: `${data[key].captureTime}` })
                    let captureTimeHr = create('hr');

                    let updateBtn = create('button', 'Update', { classList: 'update' })
                    let deleteBtn = create('button', 'Delete', { classList: 'delete' })

                    divCatch.appendChild(anglerLabel);
                    divCatch.appendChild(anglerInput);
                    divCatch.appendChild(anglerHr);

                    divCatch.appendChild(weightLabel);
                    divCatch.appendChild(weightInput);
                    divCatch.appendChild(weightHr);

                    divCatch.appendChild(speciesLabel);
                    divCatch.appendChild(speciesInput);
                    divCatch.appendChild(speciesHr);

                    divCatch.appendChild(locationLabel);
                    divCatch.appendChild(locationInput);
                    divCatch.appendChild(locationHr);

                    divCatch.appendChild(baitLabel);
                    divCatch.appendChild(baitInput);
                    divCatch.appendChild(baitHr);

                    divCatch.appendChild(captureTimeLabel);
                    divCatch.appendChild(captureTimeInput);
                    divCatch.appendChild(captureTimeHr);

                    divCatch.appendChild(updateBtn);
                    divCatch.appendChild(deleteBtn);

                    allCatchesDiv.appendChild(divCatch)

                    updateBtn.addEventListener('click', (updateBtnEvent) => {
                        let updateCatchKey = updateBtnEvent.target.parentElement.getAttribute("data-id")

                        let updatedFishCatch = {
                            angler: anglerInput.value,
                            weight: weightInput.value,
                            species: speciesInput.value,
                            location: locationInput.value,
                            bait: baitInput.value,
                            captureTime: captureTimeInput.value
                        }

                        fetch(baseURL + `/${updateCatchKey}.json`, { method: "PUT", body: JSON.stringify(updatedFishCatch) })


                    })

                    deleteBtn.addEventListener('click', (deleteBtnEvent) => {
                        let deletecatchKey = deleteBtnEvent.target.parentElement.getAttribute("data-id")
                        fetch(baseURL + `/${deletecatchKey}.json`, { method: "DELETE" })

                        deleteBtnEvent.target.parentElement.remove();
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

attachEvents();

