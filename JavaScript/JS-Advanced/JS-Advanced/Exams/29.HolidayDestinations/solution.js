function addDestination() {
    const html = {
        city: document.getElementsByClassName('inputData')[0],
        country: document.getElementsByClassName('inputData')[1],
        seasons: document.getElementById('seasons'),
        destinationList: document.getElementById('destinationsList')
    }
    const summaryBox = document.getElementById(html.seasons.value.toLocaleLowerCase());

    // check for correct input
    if (html.city.value === '' || html.country.value === '') {
        return;
    }

    // create element
    let trElement =
        e('tr', {},
            e('td', {}, `${html.city.value}, ${html.country.value}`),
            e('td', {}, `${html.seasons.value[0].toLocaleUpperCase()}${html.seasons.value.slice(1)}`));

    //append element to list
    html.destinationList.appendChild(trElement);

    //update summaryBox
    summaryBox.value = Number(summaryBox.value) + 1;

    // clear input
    html.city.value = '';
    html.country.value = '';
    html.seasons.selected = 'Summer';

    //function for creating of elements
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