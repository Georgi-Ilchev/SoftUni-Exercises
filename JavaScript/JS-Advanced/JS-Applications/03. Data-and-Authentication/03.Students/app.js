const url = `http://localhost:3030/jsonstore/collections/students`;
const results = document.querySelector('#results tbody');
const form = document.getElementById('form');

form.addEventListener('submit', onSubmit);

function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = formData.get('grade');

    if (firstName.trim() === '' ||
        lastName.trim() === '' ||
        facultyNumber.trim() === '' ||
        grade.trim() === '') {
        return;
    }

    const obj = JSON.stringify({
        firstName,
        lastName,
        facultyNumber,
        grade
    });

    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: obj
    };

    fetch(url, options)
        .then(() => createTableRow(firstName, lastName, facultyNumber, grade))
        .catch(err => {
            alert(err.message);
        });

    form.reset();
}

async function loadStudents() {
    try {
        let response = await fetch(url);
        let data = response.json();

        Object.values(data).forEach(s => {
            createTableRow(s.firstName, s.lastName, s.facultyNumber, s.grade);
        });
    } catch (error) {
        alert(error.message);
    }
}

function createTableRow(firstName, lastName, facultyNumber, grade) {
    let trElement =
        e('tr', {},
            e('td', {}, firstName),
            e('td', {}, lastName),
            e('td', {}, facultyNumber),
            e('td', {}, grade));

    results.appendChild(trElement);
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