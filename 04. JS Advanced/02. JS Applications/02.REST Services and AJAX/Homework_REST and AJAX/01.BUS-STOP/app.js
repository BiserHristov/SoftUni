function getInfo() {

    let stopId = document.querySelector('#stopId');
    const stops = ['1287', '1308', '1327', '2334']
    let div = document.querySelector('#stopName')
    let ul = document.querySelector('#buses')
    ul.innerHTML = '';

    if (!stops.includes(stopId.value)) {
        div.textContent = 'Error'
        ul.innerHTML = '';
        stopId.value = '';
        return;
    }


    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json `;
    fetch(url)
        .then(response => response.json())
        .then(data => {

            div.textContent = data.name
            Object.entries(data.buses).forEach(([busNumber, arrivalTime]) => {
                let li = document.createElement('li');
                li.textContent = `Bus ${busNumber} arrives in ${arrivalTime} minutes`
                ul.appendChild(li)
            });

            stopId.value = '';

        })









    //ANOTHER WORKING SOLUTION!

    // const httpRequest = new XMLHttpRequest();
    // let stopId = document.querySelector('#stopId');
    // const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json `;
    // const stops = ['1287', '1308', '1327', '2334']
    // httpRequest.addEventListener('loadend', function () {
    //     let div = document.querySelector('#stopName')
    //     let ul = document.querySelector('#buses')
    //     ul.innerHTML = '';

    //     if (!stops.includes(stopId.value)) {
    //         div.textContent = 'Error'
    //         ul.innerHTML = '';
    //         stopId.value = '';
    //         return;
    //     }

    //     let bussesObj = JSON.parse(this.responseText);
    //     div.textContent = bussesObj.name
    //     Object.entries(bussesObj.buses).forEach(([busNumber, arrivalTime]) => {
    //         let li = document.createElement('li');
    //         li.textContent = `Bus ${busNumber} arrives in ${arrivalTime} minutes`
    //         ul.appendChild(li)
    //     });

    //     stopId.value = '';

    // })

    // httpRequest.open('GET', url);

    // httpRequest.send();

}