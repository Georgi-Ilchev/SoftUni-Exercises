function solve() {
    let inputs = document.querySelectorAll('#container input');

    let onScreenBtn = document.querySelector('#container button');
    let clearBtn = document.querySelector('#archive button');

    let moviesSection = document.querySelector('#movies ul');
    let archiveSection = document.querySelector('#archive ul');

    let name = inputs[0];
    let hall = inputs[1];
    let ticketPrice = inputs[2];

    onScreenBtn.addEventListener('click', presentMovie);
    clearBtn.addEventListener('click', clearMovies);

    function presentMovie(ev) {
        ev.preventDefault();

        if (name.value.trim() == '' ||
            hall.value.trim() == '' ||
            ticketPrice.value.trim() == '' ||
            !Number(ticketPrice.value)) {
            return;
        }

        let archiveBtn = e('button', {}, 'Archive');
        archiveBtn.addEventListener('click', archiveMovie);

        let liElement =
            e('li', {},
                e('span', {}, `${name.value}`));

        let strong1 = e('strong', {}, `Hall: ${hall.value}`);
        let strong2 = e('strong', {}, `${ticketPrice.value}`);

        let divElement = e('div', {},
            strong2,
            e('input', { placeholder: 'Tickets Sold' }),
            archiveBtn);

        liElement.appendChild(strong1);
        liElement.appendChild(divElement);
        moviesSection.appendChild(liElement);

        name.value = '';
        hall.value = '';
        ticketPrice.value = '';

        function archiveMovie(ev) {
            const input = ev.target.parentElement.querySelector('input');

            if (input.value === '' || Number.isNaN(Number(input.value))) {
                return;
            }

            liElement.removeChild(divElement);

            let deleteBtn = e('button', {}, 'Delete');

            strong1.textContent = `Total amount: ` +
                (Number(input.value) * Number(strong2.textContent)).toFixed(2);

            liElement.appendChild(deleteBtn);

            archiveSection.appendChild(liElement);

            deleteBtn.addEventListener('click', (e) => {
                let parent = e.target.parentNode.parentNode;
                parent.removeChild(liElement);
            })
        }
    }

    function clearMovies() {
        archiveSection.innerHTML = ''; // clear childrens
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