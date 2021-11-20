import { html, render } from './node_modules/lit-html/lit-html.js';

const selectTemplate = (items) => html`
<select id="menu">
    ${items.map(i => html`<option value=${i._id}>${i.text}</option>`)}
</select>`;

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.querySelector('div');
document.querySelector('form').addEventListener('submit', addItem);
getData();

async function getData() {
    const response = await fetch(url);
    const data = await response.json();
    update(Object.values(data));
}

function update(items) {
    render(selectTemplate(items), root);
}

async function addItem(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const text = formData.get('text').trim(); // Added property name='text' at index.html -> 21 row

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text })
    });

    if (response.ok) {
        getData();
        ev.target.reset();
    }
}