function attachEvents() {
    let locationField = document.getElementById('location');
    let submitBtn = document.getElementById('submit');
    let forecastSection = document.getElementById('forecast');
    let currentSection = document.getElementById('current');

    let conditionSymbol = {
        'Sunny': '&#x2600;', // ☀
        'Partly sunny': '&#x26C5;', // ⛅
        'Overcast': '&#x2601;',// ☁
        'Rain': '&#x2614;',// ☁
        'Degrees': '&#176;'// °
    }

    submitBtn.addEventListener('click', async function () {
        try {
            let data = await sendRequest(`https://judgetests.firebaseio.com/locations.json`, 'GET');
            let searchedObj;
            data.forEach(element => {
                if (element.name === locationField.value) {
                    searchedObj = element;
                }
            });

            let currentConditions = await sendRequest(`https://judgetests.firebaseio.com/forecast/today/${searchedObj.code}.json`, 'GET');
            let symbolCondition = conditionSymbol[currentConditions.forecast.condition];
            let location = currentConditions.name;
            let temp = `${currentConditions.forecast.low}${conditionSymbol['Degrees']}/${currentConditions.forecast.high}${conditionSymbol['Degrees']}`;
            let condition = currentConditions.forecast.condition;
            currentSection.innerHTML = '<div class="label">Current conditions</div>';
            generateForecastHTML(symbolCondition, location, temp, condition);
            let upcoming = await sendRequest(`https://judgetests.firebaseio.com/forecast/upcoming/${searchedObj.code}.json`, 'GET');
            let divForcastInfo = document.createElement('div');
            divForcastInfo.classList.add('forecast-info');
            for (const element of upcoming.forecast) {
                let condition = element.condition;
                let symbol = conditionSymbol[condition];
                let lowTemp = element.low;
                let highTemp = element.high;
                let temp = `${lowTemp}${conditionSymbol['Degrees']}/${highTemp}${conditionSymbol['Degrees']}`;
                divForcastInfo.appendChild(generateUpcomingHTML(symbol, temp, condition));
            }
            document.getElementById('upcoming').innerHTML = '<div class="label">Three-day forecast</div>';
            document.getElementById('upcoming').appendChild(divForcastInfo);
        } catch (error) {
            if (!currentSection.innerHTML.includes('Error')) {
                currentSection.innerHTML += 'Error';
                document.getElementById('upcoming').innerHTML += 'Error';
            }
        }
    });

    async function sendRequest(url, method) {
        forecastSection.style.display = 'block';
        try {
            let response = await fetch(url, { method });
            if (response.status !== 200) {
                throw new Error('Error');
            }
            let data = await response.json();
            return data;
        } catch (error) {
            forecastSection.textContent = error.message;
        }
    }

    function generateForecastHTML(symbolCondition, location, temp, condition) {
        let divForecasts = document.createElement('div');
        divForecasts.classList.add('forecasts');

        let spanConditionSymbol = document.createElement('span');
        spanConditionSymbol.classList.add('condition', 'symbol');
        spanConditionSymbol.innerHTML = symbolCondition;
        divForecasts.appendChild(spanConditionSymbol);

        let spanCondition = document.createElement('span');
        spanCondition.classList.add('condition');

        let spanForcastDataLocation = document.createElement('span');
        spanForcastDataLocation.classList.add('forecast-data');
        spanForcastDataLocation.textContent = location;
        spanCondition.appendChild(spanForcastDataLocation);

        let spanForcastDataTemp = document.createElement('span');
        spanForcastDataTemp.classList.add('forecast-data');
        spanForcastDataTemp.innerHTML = temp;
        spanCondition.appendChild(spanForcastDataTemp);

        let spanForcastDataCondition = document.createElement('span');
        spanForcastDataCondition.classList.add('forecast-data');
        spanForcastDataCondition.innerHTML = condition;
        spanCondition.appendChild(spanForcastDataCondition);

        divForecasts.appendChild(spanCondition);
        currentSection.appendChild(divForecasts);
    }

    function generateUpcomingHTML(symbol, temp, condition) {

        let spanUpcoming = document.createElement('span')
        spanUpcoming.classList.add('upcoming');

        let spanSymbol = document.createElement('span');
        spanSymbol.classList.add('symbol');
        spanSymbol.innerHTML = symbol;

        let spanForcastDataTemp = document.createElement('span');
        spanForcastDataTemp.classList.add('forecast-data');
        spanForcastDataTemp.innerHTML = temp;

        let spanForcastDataCondition = document.createElement('span');
        spanForcastDataCondition.classList.add('forecast-data');
        spanForcastDataCondition.innerHTML = condition;

        spanUpcoming.appendChild(spanSymbol);
        spanUpcoming.appendChild(spanForcastDataTemp);
        spanUpcoming.appendChild(spanForcastDataCondition);
        return spanUpcoming;
    }
}

attachEvents();