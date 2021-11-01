function attachEvents() {
    const forecastDiv = document.getElementById('forecast');
    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');

    const weatherBtn = document.getElementById('submit');
    const location = document.getElementById('location');

    const locationsUrl = `http://localhost:3030/jsonstore/forecaster/locations`;
    const baseUrl = `http://localhost:3030/jsonstore/forecaster/`;

    const symbols = {
        Sunny: '&#x2600', // ☀
        "Partly sunny": "&#x26C5", // ⛅
        Overcast: "&#x2601", // ☁
        Rain: "&#x2614", // ☂
        Degrees: '&#176',   // °
    }

    weatherBtn.addEventListener('click', () => {
        fetch(locationsUrl)
            .then(res => res.json())
            .then(data => {
                let { code } = data.find(c => c.name === location.value);
                location.value = '';

                let current = fetch(baseUrl + `today/${code}`)
                    .then(res => res.json());

                let upcoming = fetch(baseUrl + `upcoming/${code}`)
                    .then(res => res.json());

                Promise.all([current, upcoming])
                    .then(([currentData, upcomingData]) => {
                        displayCurrentWeather(currentData);
                        displayUpcomingWeather(upcomingData);
                    })

            })
            .catch(error => {
                if (error) {
                    checkForError();
                }
            });
    });



    function displayUpcomingWeather(upcomingData) {
        let forecastInfo = e('div', { className: 'forecast-info' });

        upcomingData.forecast.forEach(obj => {
            let currentSymbol = getSymbolOfThreeDays(obj);
            let spanWithSymbol = e('span', { className: 'symbol' });
            spanWithSymbol.innerHTML = currentSymbol;

            let temperature = getTemperatureOfThreeDays(obj);
            let temperatureSpan = e('span', { className: 'forecast-data' });
            temperatureSpan.innerHTML = temperature;

            let upcomingElements =
                e('span', { className: 'upcoming' },
                    spanWithSymbol,
                    temperatureSpan,
                    e('span', { className: 'forecast-data' }, obj.condition));

            forecastInfo.appendChild(upcomingElements);
        });

        checkForClearInUpcoming();
        upcomingDiv.appendChild(forecastInfo);
        forecastDiv.style.display = 'block';
    }

    function displayCurrentWeather(currentData) {
        let currentSymbol = getSymbol(currentData);
        let temperature = getTemperature(currentData);

        let conditionWithSymbol = e('span', { className: 'condition symbol' });
        conditionWithSymbol.innerHTML = currentSymbol;

        let temperatureSpan = e('span', { className: 'forecast-data' });
        temperatureSpan.innerHTML = temperature;

        let forecastsDiv =
            e('div', { className: 'forecasts' },
                conditionWithSymbol,
                e('span', { className: 'condition' },
                    e('span', { className: 'forecast-data' }, currentData.name),
                    temperatureSpan,
                    e('span', { className: 'forecast-data' }, currentData.forecast.condition)));

        checkForClearInError();
        currentDiv.appendChild(forecastsDiv);
        forecastDiv.style.display = 'block';
    }

    function getTemperatureOfThreeDays(data) {
        return `${data.low}${symbols.Degrees}/${data.high}${symbols.Degrees}`;
    }

    function getTemperature(data) {
        return `${data.forecast.low}${symbols.Degrees}/${data.forecast.high}${symbols.Degrees}`;
    }

    function getSymbolOfThreeDays(data) {
        return symbols[data.condition];
    }

    function getSymbol(data) {
        return symbols[data.forecast.condition];
    }

    function checkForClearInError() {
        if (currentDiv.children.length === 2) {
            currentDiv.lastChild.remove();
        }
    }

    function checkForClearInUpcoming() {
        if (upcomingDiv.children.length === 2) {
            upcomingDiv.lastChild.remove();
        }
    }

    function checkForError() {
        checkForClearInError();

        let divElement = document.createElement('div');
        divElement.classList.add('forecasts');
        divElement.innerHTML = 'Error';
        currentDiv.appendChild(divElement);
        forecastDiv.style.display = 'block';

        if (upcomingDiv.children.length === 2) {
            upcomingDiv.lastChild.remove();
        }
        let divElementNext = document.createElement('div');
        divElementNext.classList.add('forecast-info');
        divElementNext.innerHTML = 'Error';
        upcomingDiv.appendChild(divElementNext);
        upcomingDiv.style.display = 'block';

        location.value = '';
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }

        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}

attachEvents();