function attachEvents() {
    let submitBtn = document.querySelector("#submit");
    let location = document.querySelector("#location");
    let url = 'https://judgetests.firebaseioO.com/';

    submitBtn.addEventListener('click', () => {

        (async function getWeather() {
            
            let townsPromise = await fetch(url + 'locations.json');
            let towns = await townsPromise.json();
            let searchedTown = towns.find(t => t.name == location.value)

            let todayPromise = await fetch(url + `forecast/today/${searchedTown.code}.json `)
            let today = await todayPromise.json();

            let upcomingPromise = await fetch(url + `forecast/upcoming/${searchedTown.code}.json`)
            let upcoming = await upcomingPromise.json();

            let mainDiv = document.querySelector("#forecast")
            mainDiv.style.display = 'block'

            let curentWeatherDiv = document.querySelector("#current");
            let mainDivUpcoming = document.querySelector('#upcoming');

            Promise.all([today, upcoming])
                .then(showForecast)
                .catch(error => {
                    let currentErrorDiv = document.createElement('div');
                    currentErrorDiv.textContent = 'Error'
                    curentWeatherDiv.appendChild(currentErrorDiv)

                    let upcomingErrorDiv = document.createElement('div');
                    upcomingErrorDiv.textContent = 'Error'
                    mainDivUpcoming.appendChild(upcomingErrorDiv)
                })

            function showForecast([today, upcoming]) {

                let symbol = {
                    Rain: '&#9748',
                    Sunny: '&#x2600',
                    "Partly sunny": '&#x26C5',
                    Overcast: '&#x2601',
                    Degrees: '&#176'
                }

                loadToday();
                loadUpcoming();
               

                function loadToday() {


                    if (curentWeatherDiv.childElementCount > 1) {
                        curentWeatherDiv.children[1].remove()
                    }

                    let divForecast = document.createElement('div')
                    divForecast.classList = 'forecasts'
                    let spanSymbol = document.createElement('span')
                    spanSymbol.classList = 'condition symbol'



                    spanSymbol.innerHTML = symbol[today.forecast.condition];

                    let spanForecast = document.createElement('span')
                    spanForecast.classList = 'condition'

                    let spanTown = document.createElement('span')
                    spanTown.classList = 'forecast-data'
                    spanTown.textContent = today.name;

                    let spanDegrees = document.createElement('span')
                    spanDegrees.classList = 'forecast-data'
                    spanDegrees.textContent = `${today.forecast.low}${String.fromCharCode(176)}/${today.forecast.high}${String.fromCharCode(176)}`

                    let spanCondition = document.createElement('span')
                    spanCondition.classList = 'forecast-data'
                    spanCondition.textContent = today.forecast.condition;

                    spanForecast.appendChild(spanTown)
                    spanForecast.appendChild(spanDegrees)
                    spanForecast.appendChild(spanCondition)

                    divForecast.appendChild(spanSymbol)
                    divForecast.appendChild(spanForecast)
                    curentWeatherDiv.appendChild(divForecast);



                }

                function loadUpcoming() {

                    if (mainDivUpcoming.childElementCount > 1) {
                        mainDivUpcoming.children[1].remove()
                    }
                    let divUpcoming = document.createElement('div')
                    divUpcoming.classList = 'forecast-info'

                    upcoming.forecast.forEach(f => {


                        let spanUpcoming = document.createElement('span')
                        spanUpcoming.classList = 'upcoming'

                        let spanSymbolUpcoming = document.createElement('span')
                        spanSymbolUpcoming.classList = 'symbol'
                        spanSymbolUpcoming.innerHTML = symbol[f.condition];

                        let spanDegreesUpcoming = document.createElement('span')
                        spanDegreesUpcoming.classList = 'forecast-data'
                        spanDegreesUpcoming.textContent = `${f.low}${String.fromCharCode(176)}/${f.high}${String.fromCharCode(176)}`

                        let spanConditionUpcoming = document.createElement('span')
                        spanConditionUpcoming.classList = 'forecast-data'
                        spanConditionUpcoming.textContent = f.condition;

                        spanUpcoming.appendChild(spanSymbolUpcoming)
                        spanUpcoming.appendChild(spanDegreesUpcoming)
                        spanUpcoming.appendChild(spanConditionUpcoming)
                        divUpcoming.appendChild(spanUpcoming)
                    })

                    mainDivUpcoming.appendChild(divUpcoming)

                }
            }

        })()

    })
}

attachEvents();