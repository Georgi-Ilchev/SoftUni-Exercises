//not tested in judge
function solve() {
    const availableProducts = document.querySelector('#products > ul');
    const myProducts = document.querySelector('#myProducts > ul');

    const form = document.querySelector('#add-new').children;
    const nameInput = form[1];
    const quantityInput = form[2];
    const priceInput = form[3];

    const filterInput = document.querySelector('#filter');

    // add button
    form[4].addEventListener('click', addProduct);

    // filter button
    document.querySelector('.filter > button').addEventListener('click', filterProduct);

    //price
    const priceTag = document.querySelectorAll('h1').item(1);
    let currentPrice = 0;

    //buy button
    document.querySelector('#myProducts button').addEventListener('click', buyProduct);

    function addProduct(ev) {
        ev.preventDefault();

        const name = nameInput.value.trim();
        let quantity = Number(quantityInput.value.trim());
        const price = Number(priceInput.value.trim());

        if (name.length == 0 || quantity <= 0 || price <= 0) {
            return;
        }

        let quantityStrong = e('strong', {}, `Available: ${quantity}`);
        let addToListBtn = e('button', {}, `Add to Client's List`);
        let product =
            e('li', {},
                e('span', {}, `${name}`),
                quantityStrong,
                e('div', {},
                    e('strong', {}, `${price.toFixed(2)}`),
                    addToListBtn));

        addToListBtn.addEventListener('click', (e) => {
            addToMyProducts(name, price);

            quantity--;
            if (quantity === 0) {
                product.remove();
            } else {
                quantityStrong.textContent = `Available: ${quantity}`;
            }
        })

        availableProducts.appendChild(product);

        nameInput.value = '';
        quantityInput.value = '';
        priceInput.value = '';
    }

    function addToMyProducts(name, price) {
        currentPrice += price;
        priceTag.textContent = `Total Price: ${currentPrice.toFixed(2)}`;

        const element =
            e('li', {}, `${name}`,
                e('strong', {}, `${price.toFixed(2)}`));

        myProducts.appendChild(element);
    }

    function filterProduct(ev) {
        const query = filterInput.value.trim().toLowerCase();

        Array.from(myProducts.querySelectorAll('li')).forEach(p => {
            if (p.children[0].textContent.toLowerCase().includes(query)) {
                p.style.display = '';
            } else {
                p.style.display = 'none';
            }
        });
    }

    function buyProduct(ev) {
        currentPrice = 0;
        priceTag.textContent = `Total Price: 0.00`;

        myProducts.innerHTML = '';
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