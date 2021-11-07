function attachEvents() {
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', loadContacts);
    createBtn.addEventListener('click', onCreate);
    list.addEventListener('click', deleteContact);

    loadContacts();
}

const list = document.getElementById('phonebook');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

attachEvents();

async function loadContacts() {
    const url = `http://localhost:3030/jsonstore/phonebook`;

    const response = await fetch(url);
    const data = await response.json();

    list.replaceChildren(...Object.values(data).map(createLi));
}

async function createContact(contact) {
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const options = {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(contact)
    };

    const response = await fetch(url, options);
    const result = await response.json();

    return result;
}

async function deleteContact(id) {
    const url = `http://localhost:3030/jsonstore/phonebook/${id}`;
    const response = await fetch(url, { method: 'DELETE' });

    const result = await response.json();

    return result;
}

async function onCreate() {
    const person = personInput.value;
    const phone = phoneInput.value;
    const contact = { person, phone };

    const result = await createContact(contact);

    list.appendChild(createLi(result));

}

async function onDelete(ev) {
    const id = ev.target.dataset.id;

    if (id != undefined) {
        await deleteContact(id);
        ev.target.parentElement.remove();
    }
}

function createLi(contact) {
    const liElement = document.createElement('li');
    liElement.innerHTML = `${contact.person}: ${contact.phone} <button data-id="${contact._id}">Delete</button>`;

    return liElement;
}