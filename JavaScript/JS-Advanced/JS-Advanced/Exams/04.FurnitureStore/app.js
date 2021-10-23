window.addEventListener('load', solve);

function solve() {
    let model = document.getElementById('model');
    let yearInput = document.getElementById('year');
    let description = document.getElementById('description');
    let priceInput = document.getElementById('price');

    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', addFurniture);

    let furnitureList = document.getElementById('furniture-list');
    let totalPrice = document.querySelector('.total-price');

    function addFurniture(ev) {
        ev.preventDefault();

        let year = Number(yearInput.value);
        let price = Number(priceInput.value);

        if (model.value != '' &&
            year > 0 &&
            description.value != '' &&
            price > 0) {

            //1
            let tr = e('tr', { classList: 'info' },
                e('td', {}, `${model.value}`),
                e('td', {}, `${price.toFixed(2)}`),
                e('td', {},
                    e('button', { classList: 'moreBtn' }, 'More Info'),
                    e('button', { classList: 'buyBtn' }, 'Buy it')
                )
            );

            let hideTr = e('tr', { classList: 'hide' },
                e('td', {}, `Year: ${year}`),
                e('td', { colSpan: '3' }, `Description: ${description.value}`)
            );

            //2
            // let tr = document.createElement("tr");
            // tr.classList.add("info");
            // tr.innerHTML = `<td>${model.value}</td>
            //                 <td>${price.toFixed(2)}</td>
            //                 <td><button class="moreBtn">More Info</button>
            //                     <button class="buyBtn">Buy it</button>
            //                 </td>`;

            // let hideTr = document.createElement('tr');
            // hideTr.classList.add('hide');
            // hideTr.innerHTML = `<td>Year: ${year}</td><td colspan="3">Description: ${description.value}</td>`;

            //3

            furnitureList.appendChild(tr);
            furnitureList.appendChild(hideTr);

            let listButtons = tr.querySelectorAll('button');
            listButtons[0].addEventListener('click', showMore);
            listButtons[1].addEventListener('click', buyIt);
        }

        model.value = '';
        yearInput.value = '';
        description.value = '';
        priceInput.value = '';
    }

    function showMore(e) {
        let moreInfoTr = e.target.parentElement.parentElement.nextElementSibling;

        if (e.target.textContent == 'More Info') {
            e.target.textContent = 'Less Info';
            moreInfoTr.style.display = 'contents';
        } else {
            e.target.textContent = 'More Info';
            moreInfoTr.style.display = 'none';
        }

    }

    function buyIt(e) {
        let tr = e.target.parentElement.parentElement;
        let hideTr = tr.nextElementSibling;

        hideTr.parentElement.removeChild(hideTr);

        let price = Number(tr.querySelectorAll('td')[1].textContent);

        totalPrice.textContent = (Number(totalPrice.textContent) + price).toFixed(2);

        tr.parentElement.removeChild(tr);
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
