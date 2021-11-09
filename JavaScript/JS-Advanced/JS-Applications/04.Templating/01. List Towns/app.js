const elements = {
    input: () => document.querySelector('input#towns'),
    button: () => document.querySelector('button#btnLoadTowns'),
    root: () => document.querySelector('div#root')
};

elements.button().addEventListener('click', getInputInformation);

function getInputInformation(e) {
    e.preventDefault();
    const { value } = elements.input();
    const towns = value.split(/[, ]+/g).map((t) => {
        return {
            name: t
        }
    });

    appendTowns(towns);
}

function appendTowns(towns) {
    console.log('append');
    getTemplate()
        .then((templateSource) => {
            const template = Handlebars.compile(templateSource);
            const htmlResult = template({ towns });
            elements.root().innerHTML = htmlResult;
        })
        .catch((e) => console.error(e));
}

async function getTemplate() {
    return await fetch('./template.hbs').then((r) => r.text()); // because template is text - not html
}

//////////////////////////////////////////////////////////////////////

// elements.button().addEventListener('click', fetchCountries);
const baseUrl = 'https://restcountries.com/v2/all';

async function fetchCountries(e) {
    const response = await fetch(baseUrl);
    const result = await response.json();

    appendTowns(result);

    // fetch(baseUrl)
    //     .then(r => r.json())
    //     .then(appendTowns);
}