// import monkeys from './monkeys.js';

const elements = {
    allMonkeys: () => document.querySelector('div.monkeys')
};

fetch('./monkey.hbs')
    .then(res => res.text())
    .then((monkeysTemplateSrc) => {
        const monkeysTemplate = Handlebars.compile(monkeysTemplateSrc);
        const resultHTML = monkeysTemplate({ monkeys });

        elements.allMonkeys().innerHTML = resultHTML;
        attachEventListener();
    })
    .catch((err) => console.error(err));

function attachEventListener() {
    elements.allMonkeys().addEventListener('click', (ev) => {
        if (ev.target.nodeName !== 'BUTTON' || ev.target.textContent !== 'Info') {
            return;
        }

        const p = ev.target.parentNode.querySelector('p');

        if (p.style.display === 'none' || !p.style.display) {
            p.style.display = 'block';
        } else {
            p.style.display = 'none';
        }
    });
}