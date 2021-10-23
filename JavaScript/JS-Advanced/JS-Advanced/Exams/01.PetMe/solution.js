function solve() {
    const fields = document.querySelectorAll('#container input');
    const addBtn = document.querySelector('#container button');
    const petList = document.querySelector('#adoption ul');
    const adoptedList = document.querySelector('#adopted ul');

    const input = {
        name: fields[0],
        age: fields[1],
        kind: fields[2],
        owner: fields[3],
    };

    addBtn.addEventListener('click', addPet);

    function addPet(ev) {
        ev.preventDefault();

        const name = input.name.value.trim();
        const age = Number(input.age.value.trim());
        const kind = input.kind.value.trim();
        const owner = input.owner.value.trim();

        if (name == '' || kind == '' || owner == '' || Number.isNaN(age) || input.age.value.trim() == '') {
            return;
        }

        const contactBtn = e('button', {}, 'Contact with owner');

        const pet = e('li', {},
            e('p', {},
                e('strong', {}, name), ' is a ',
                e('strong', {}, age), ' year old ',
                e('strong', {}, kind),
            ),
            e('span', {}, `Owner: ${owner}`),
            contactBtn
        );

        contactBtn.addEventListener('click', contact);
        petList.appendChild(pet);

        input.name.value = '';
        input.age.value = '';
        input.kind.value = '';
        input.owner.value = '';

        function contact() {
            const confirmInput = e('input', { placeholder: 'Enter your names' });
            const confirmBtn = e('button', {}, 'Yes! I take it!');
            const confirmDiv = e('div', {},
                confirmInput,
                confirmBtn
            );

            confirmBtn.addEventListener('click', adopt.bind(null, confirmInput, pet));

            contactBtn.remove();
            pet.appendChild(confirmDiv);
        }
    }

    function adopt(input, pet) {
        const newOwner = input.value.trim();

        if (newOwner == '') {
            return;
        }

        const checkBtn = e('button', {}, 'Checked');
        checkBtn.addEventListener('click', check.bind(null, pet));

        pet.querySelector('div').remove();
        pet.appendChild(checkBtn);

        pet.querySelector('span').textContent = `New Owner: ${newOwner}`;

        adoptedList.appendChild(pet);
    }

    function check(pet) {
        pet.remove();
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

//----------------------------------------------------------------------------------------------------------------------------

function solve() {
    let addBtn = document.querySelector('#container button');
    let inputElements = Array.from(document.querySelectorAll('#container input'));
    let [nameInput, ageInput, kindInput, ownerInput] = inputElements;

    let adoption = document.querySelector('#adoption ul');
    let adopted = document.querySelector('#adopted ul');

    addBtn.addEventListener('click', e => {
        e.preventDefault();

        if (!inputElements.every(x => x.value) || !Number(ageInput.value)) {
            return;
        }

        let liElement = document.createElement('li');

        let pElement = document.createElement('p');
        pElement.innerHTML = `<strong>${nameInput.value}</strong> is a <strong>${ageInput.value}</strong> year old <strong>${kindInput.value}</strong>`;

        let spanElement = document.createElement('span');
        spanElement.textContent = `Owner: ${ownerInput.value}`;

        let contactBtn = document.createElement('button');
        contactBtn.textContent = `Contact with owner`;

        liElement.appendChild(pElement);
        liElement.appendChild(spanElement);
        liElement.appendChild(contactBtn);

        adoption.appendChild(liElement);

        nameInput.value = '';
        ageInput.value = '';
        kindInput.value = '';
        ownerInput.value = '';

        contactBtn.addEventListener('click', contact);
    });

    function contact(e) {
        let parent = e.currentTarget.parentElement;

        e.currentTarget.remove();

        let divElement = document.createElement('div');

        let inputElement = document.createElement('input');
        inputElement.setAttribute('placeholder', 'Enter your names');

        let takeItBtn = document.createElement('button');
        takeItBtn.textContent = `Yes! I take it!`;

        divElement.appendChild(inputElement);
        divElement.appendChild(takeItBtn);

        parent.appendChild(divElement);

        takeItBtn.addEventListener('click', adopt);
    }

    function adopt(e) {
        let parentButtonElement = e.currentTarget.parentElement;
        let liElement = parentButtonElement.parentElement;

        let newOwnerInputElement = liElement.querySelector('input');

        if (!newOwnerInputElement.value) {
            return;
        }

        let ownerNameSpanElement = liElement.querySelector('span');

        ownerNameSpanElement.textContent = `New Owner: ${newOwnerInputElement.value}`;

        parentButtonElement.remove();

        let checkedBtn = document.createElement('button');
        checkedBtn.textContent = 'Checked';
        checkedBtn.addEventListener('click', (e) => {
            liElement.remove();
        })

        liElement.appendChild(checkedBtn);

        adopted.appendChild(liElement);
    }
}