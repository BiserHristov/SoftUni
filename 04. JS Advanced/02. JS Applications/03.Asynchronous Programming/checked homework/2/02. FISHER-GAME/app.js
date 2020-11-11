function attachEvents() {
    const loadBtnElement = document.querySelector('.load');
    loadBtnElement.addEventListener('click', loadCatches);
    const addBtn = document.querySelector('.add');
    addBtn.addEventListener('click', addCatch);
    function loadCatches() {
        const catchesDiv = document.querySelector('#catches');
        fetch(`https://fisher-game.firebaseio.com/catches.json`)
        .then(res => res.json())
        .then(info => {
            Object.entries(info).forEach(([key, value]) => {
                const updateBtn = el('button', 'Update');
                const deleteBtn = el('button', 'Delete');
                const catchDiv = el('div', [
                    el('label', 'Angler'),
                    el('input', '', {className: 'angler', value: value.angler}),
                    el('hr', ''),
                    el('label', 'Weight'),
                    el('input', '', {className: 'weight', value: value.weight, type: 'number'}),
                    el('hr', ''),
                    el('label', 'Species'),
                    el('input', '', {className: 'species', value: value.species}),
                    el('hr', ''),
                    el('label', 'Location'),
                    el('input', '', {className: 'location', value: value.location}),
                    el('hr', ''),
                    el('label', 'Bait'),
                    el('input', '', {className: 'bait', value: value.bait}),
                    el('hr', ''),
                    el('label', 'Capture Time'),
                    el('input', '', {className: 'captureTime', value: value.captureTime, type: 'number'}),
                    el('hr', ''),
                    updateBtn,
                    deleteBtn,
                ], {className: 'catch'});
                catchDiv.setAttribute('data-id', key);
                catchesDiv.appendChild(catchDiv);
                updateBtn.addEventListener('click', updateCatch);
                deleteBtn.addEventListener('click', deleteCatch);
            })
        })
        .catch(e => console.log(e));
    }
    function deleteCatch(e) {
        const catchElement = e.target.parentNode;
        const catchId = catchElement.attributes[1].nodeValue;
        fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`,
        {
            method: 'DELETE',

        })
        catchElement.remove();
        
    }
    function updateCatch(e) {
        const catchElement = e.target.parentNode;
        const catchId = catchElement.attributes[1].nodeValue;
        const info = catchElement.querySelectorAll('input');
        
        const bodyObj = renderRequestBody(info);
        fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, {

            method: 'PUT',
            body: JSON.stringify(bodyObj),
        });
        
        
    }
    function addCatch() {
        const addForm = document.querySelector('#addForm');
        const info = addForm.querySelectorAll('input');
        try {
            [...info].forEach(i => {
                if (!i.value) {
                    throw new Error('Invalid Input');
                }
            });
        } catch (error) {
            console.log(error.message);
            return;
        }
        
        const bodyObj = renderRequestBody(info);
        fetch(`https://fisher-game.firebaseio.com/catches.json`,
        {
            method: 'POST',
            body: JSON.stringify(bodyObj),

        }).then(res => console.log(res.text()))
    }
    //creating request body
    function renderRequestBody(source) {
        const bodyObj = {
            angler: source[0].value,
            weight: source[1].value,
            species: source[2].value,
            location: source[3].value,
            bait: source[4].value,
            captureTime: source[5].value,
        };
        return bodyObj;
    }
    //creating dom elements
    function el(type, content, attributes) {
        const result = document.createElement(type);
        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }

        if (Array.isArray(content)) {
            content.forEach(append);
        } else {
            append(content);
        }

        function append(node) {
            if (typeof node == 'string') {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }
        return result;
    }
}

attachEvents();

