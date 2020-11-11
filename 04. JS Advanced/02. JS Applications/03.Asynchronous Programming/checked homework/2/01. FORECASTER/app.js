function attachEvents() {
    const forecastElement = document.querySelector('#forecast');
    const submitBtnElement = document.querySelector('#submit');


    submitBtnElement.addEventListener('click', getWeather);

   async function getWeather() {
        const locationInputElement = document.querySelector('#location');
        const location = locationInputElement.value;
        if (!location) {
            return;
        }
        //Declaring references
        const errorMsg = el('h3', 'Error', {className: 'error'});
        const symbols = {
            'Sunny': '&#x2600;',
            'Partly sunny': '&#x26C5;',
            'Overcast': '&#x2601;',
            'Rain': '&#x2614;',
            'Degrees': '&#176;',
        }
        const currentDivElement = document.querySelector('#current');
        const upcomingDivElement = document.querySelector('#upcoming');

        // Clearing user window
        let errorMsgToRemove = document.querySelector('.error');
        if (errorMsgToRemove) {
            errorMsgToRemove.remove();
        }
        let divToRemoveOne = document.querySelector('.forecasts');
        let divToRemoveTwo = document.querySelector('.forecast-info');
        if (divToRemoveOne && divToRemoveTwo) {
            divToRemoveOne.remove();
            divToRemoveTwo.remove();
            forecastElement.style.display = 'none';
        }

       await getForecast(location).
        then(f => {
            let [today, upcoming] = f;
            
            const todayDiv = el('div', [
                el('span', symbols[today.forecast.condition], {className: 'condition symbol'}),
                el('span', [
                    el('span', today.name, {className: 'forecast-data'}),
                    el('span', `${today.forecast.low}${symbols.Degrees}/${today.forecast.high}${symbols.Degrees}`, {className: 'forecast-data'}),
                    el('span', today.forecast.condition, {className: 'forecast-data'})
                ], {className: 'condition'})
            ], {className: 'forecasts'});

            const upcomingDiv = el('div', [
                el('span', [
                    el('span', symbols[upcoming.forecast[0].condition], {className: 'symbol'}),
                    el('span',`${upcoming.forecast[0].low}${symbols.Degrees}/${upcoming.forecast[0].high}${symbols.Degrees}`, {className: 'forecast-data'}),
                    el('span', upcoming.forecast[0].condition, {className: 'forecast-data'})
                ], {className: 'upcoming'}),
                el('span', [
                    el('span', symbols[upcoming.forecast[1].condition], {className: 'symbol'}),
                    el('span',`${upcoming.forecast[1].low}${symbols.Degrees}/${upcoming.forecast[1].high}${symbols.Degrees}`, {className: 'forecast-data'}),
                    el('span', upcoming.forecast[1].condition, {className: 'forecast-data'})
                ], {className: 'upcoming'}),
                el('span', [
                    el('span', symbols[upcoming.forecast[2].condition], {className: 'symbol'}),
                    el('span',`${upcoming.forecast[2].low}${symbols.Degrees}/${upcoming.forecast[2].high}${symbols.Degrees}`, {className: 'forecast-data'}),
                    el('span', upcoming.forecast[2].condition, {className: 'forecast-data'})
                ], {className: 'upcoming'})
            ], {className: 'forecast-info'})

            currentDivElement.appendChild(todayDiv);
            upcomingDivElement.appendChild(upcomingDiv);
            
        })
        .catch(err => {
            currentDivElement.appendChild(errorMsg);
        });
        
        forecastElement.style.display = 'block';
    }

    async function getForecast(location) {
       const locations = await fetch('https://judgetests.firebaseio.com/locations.json')
        .then(res => res.json());

       location = locations
       .find(l => l.name.toLowerCase() == location.toLowerCase());
       
       let today = await fetch(`https://judgetests.firebaseio.com/forecast/today/${location.code}.json`)
       .then(res => res.json());
       let upcoming = await fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${location.code}.json`)
       .then(res => res.json());

       return [today, upcoming];
    }

    //Creating dom elements
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
                result.innerHTML = node;
                return;
            }
            result.appendChild(node);
        }
        return result;
    }
}

attachEvents();