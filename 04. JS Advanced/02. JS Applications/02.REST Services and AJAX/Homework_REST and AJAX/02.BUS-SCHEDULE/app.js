function solve() {
    let currentId = 'depot';

    let stopName = '';
    let span = document.querySelector('span')
    let buttons = document.querySelector('#controls').children
    let departBtn = buttons[0]
    let arriveBtn = buttons[1]


    function depart() {
        let url = `https://judgetests.firebaseio.com/schedule/${currentId}.json `
        fetch(url)
            .then(response => response.json())
            .then(data => {
                currentId = data.next
                stopName = data.name;
                span.textContent = `Next stop ${stopName}`
                departBtn.setAttribute('disabled', 'true');
                arriveBtn.removeAttribute('disabled');
            })
            .catch(() => {
                span.textContent = `Error`
                departBtn.setAttribute('disabled', 'true');
                arriveBtn.setAttribute('disabled', 'true');
            })
    }

    function arrive() {
        span.textContent = `Arriving at ${stopName}`
        arriveBtn.setAttribute('disabled', 'true');
        departBtn.removeAttribute('disabled');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();