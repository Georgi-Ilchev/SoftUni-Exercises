function attachEvents() {
    const url = `https://phonebook-nakov.firebaseio.com/phonebook.json`;

    const btnLoad = document.getElementById('btnLoad');
    const btnCreate = document.getElementById('btnCreate');
    const phonebookUl = document.getElementById('phonebook');

    btnLoad.addEventListener('click', () => {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                Object.keys(data).forEach((key) => {
                    let li = document.createElement('li');
                    li.textContent = `${data[key].person}: ${data[key].phone}`;

                    let deleteUrl = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = `Delete`;
                    deleteBtn.addEventListener('click', () => {
                        fetch(deleteUrl, { method: "DELETE" })
                    });

                    li.appendChild(deleteBtn);
                    phonebookUl.appendChild(li);
                })
            });
    });

    btnCreate.addEventListener('click', () => {
        let person = document.getElementById('person');
        let phone = document.getElementById('phone');
        let obj = {
            person: person.value,
            phone: phone.value,
        };

        fetch(url, { method: "POST", body: JSON.stringify(obj) });
    });
}

attachEvents();