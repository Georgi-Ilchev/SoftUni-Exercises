class Kitchen {
    constructor(budget) {
        this.budget = +budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        let message = [];

        products.forEach(line => {
            let [product, productQuantityAsStr, productPriceAsStr] = line.split(' ');
            let quantity = Number(productQuantityAsStr);
            let price = Number(productPriceAsStr);

            if (this.budget >= price) {
                if (this.productsInStock[product]) {
                    this.productsInStock[product] += quantity;
                } else {
                    this.productsInStock[product] = quantity;
                }
                this.budget -= price;
                message.push(`Successfully loaded ${quantity} ${product}`);
            } else {
                message.push(`There was not enough money to load ${quantity} ${product}`);
            }
        });

        this.actionsHistory = [...this.actionsHistory, ...message];
        //this.actionsHistory.push(message.join('\n'));
        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = {
                products: neededProducts,
                price: +price,
            }
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        } else {
            return `The ${meal} is already in our menu, try something different.`;
        }
    }

    showTheMenu() {
        let print = [];

        for (let key of Object.keys(this.menu)) {
            print.push(`${key} - $ ${this.menu[key].price}`)
        }

        if (!print.length) {
            return `Our menu is not ready yet, please come later...`;
        } else {
            return print.join('\n') + '\n';
        }
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let productsNeeded = this.menu[meal].products;

        for (let item of productsNeeded) {
            let [product, quantityAsStr] = item.split(' ');
            let quantity = Number(quantityAsStr);

            if (this.productsInStock[product] < quantity || !this.productsInStock[product]) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        for (let item of productsNeeded) {
            let [product, quantityAsStr] = item.split(' ');
            let quantity = Number(quantityAsStr);

            this.productsInStock[product] -= quantity;
        }

        this.budget += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(`------------------------------------------`)
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(`------------------------------------------`)
console.log(kitchen.showTheMenu());