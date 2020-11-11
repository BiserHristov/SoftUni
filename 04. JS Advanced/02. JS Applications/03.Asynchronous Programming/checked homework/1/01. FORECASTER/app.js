function attachEvents() {
    
    let weatherBtn = document.getElementById('submit');
    let locationName = document.getElementById('location');
    let currentDiv = document.getElementById('current');
    let upcomingDiv = document.getElementById('upcoming');
    let forecastDiv = document.getElementById('forecast');

    const locationUrl = 'https://judgetests.firebaseio.com/locations.json';
    const baseUrl = 'https://judgetests.firebaseio.com/forecast/';

    const symbols = {
        Sunny: "&#x2600", // ☀
        "Partly sunny":	"&#x26C5", // ⛅
        Overcast:	"&#x2601", // ☁
        Rain:	"&#x2614", // ☂
        degrees: "&#176"   // °
    }

    weatherBtn.addEventListener('click', () => {
        fetch(locationUrl)
        .then(response => response.json())
        .then(data => {
            let {name,code} = data.find(city => city.name === locationName.value);

            let current = fetch(baseUrl + `today/${code}.json`)
                            .then(response => response.json())

            let upcoming = fetch(baseUrl + `upcoming/${code}.json`)
                            .then(response => response.json())
        
        .catch((e) => {
        forecastDiv.textContent = 'Error'    
        })   
            Promise.all([current, upcoming])
            .then(showForecast) 
        });
       currentDiv.innerHTML = '';
       upcomingDiv.innerHTML = '';

    })

    function createElement(ele, classes, content){
        let element = document.createElement(ele);
        element.className = classes;
        element.innerHTML = content;

        return element;
    }

    function showForecast([currentData, upcomingData]){
        forecastDiv.style.display = 'block';

        showCurrent(currentData);
        showUpcoming(upcomingData);
    }

    function showCurrent(currentData){
        let currentForecastDiv = createElement('div', 'forecasts', '');

        let currentSymbol = symbols[currentData.forecast.condition];
        let conditionSymbolSpan = createElement('span', 'condition symbol', currentSymbol);
        let conditionInfoSpan = createElement('span', 'condition', '');

        let forecastDataCity = createElement('span', 'forecast-data', currentData.name);

        let highLow = `${currentData.forecast.low}${symbols.degrees}/${currentData.forecast.high}${symbols.degrees}`;
        let forecastDataTemp = createElement('span', 'forecast-data', highLow);
        let forecastDataCondition = createElement('span', 'forecast-data', currentData.forecast.condition);

        conditionInfoSpan.appendChild(forecastDataCity);
        conditionInfoSpan.appendChild(forecastDataTemp);
        conditionInfoSpan.appendChild(forecastDataCondition);

        currentForecastDiv.appendChild(conditionSymbolSpan);
        currentForecastDiv.appendChild(conditionInfoSpan);

        currentDiv.appendChild(currentForecastDiv);

    }

    function showUpcoming(upcomingData){
    let forecastInfo = createElement('div', 'forecast-info', '');

    upcomingData.forecast.forEach(obj => {
        let upcomingSpan = createElement('span', 'upcoming', '');
        let conditionSymbolSpan = createElement('span', 'symbol', symbols[obj.condition]);

        let highLow = `${obj.low}${symbols.degrees}/${obj.high}${symbols.degrees}`;
        let forecastDataTemp = createElement('span', 'forecast-data', highLow);
        let forecastDataCondition = createElement('span', 'forecast-data', obj.condition);
        
        upcomingSpan.appendChild(conditionSymbolSpan);
        upcomingSpan.appendChild(forecastDataTemp);
        upcomingSpan.appendChild(forecastDataCondition);

        forecastInfo.appendChild(upcomingSpan);
    });

    upcomingDiv.appendChild(forecastInfo);
    }
}

attachEvents();