class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        products.forEach((el) => {
            let [name, quantity, price] = el.split(' ');
            price = Number(price);
            quantity = Number(quantity);

            if (this.budgetMoney >= price) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += quantity;
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        });

        return this.history.join('\n');
    }

    addToMenu(meal, products, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = {
                products: {},
                price: price,
            }

            products.forEach((el => {
                let [name, quantity] = el.split(' ');
                quantity = Number(quantity);

                this.menu[meal].products[name] = quantity;
            }));

            let mealCount = Object.keys(this.menu).length;

            if (mealCount == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            } else {
                return `Great idea! Now with the ${meal} we have ${mealCount} meals in the menu, other ideas?`;
            }

        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length == 0) {
            return `Our menu is not ready yet, please come later...`;
        }

        let result = [];

        for (const meal in this.menu) {
            result.push(`${meal} - $ ${this.menu[meal].price}`);
        }

        return result.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        const neededProduction = {};

        for (const product in this.menu[meal].products) {
            if (this.menu[meal].products[product] > this.stockProducts[product] || !this.stockProducts[product]) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            } else {
                neededProduction[product] = this.menu[meal].products[product];
            }
        }

        for (const neededProduct in neededProduction) {
            this.stockProducts[neededProduct] -= neededProduction[neededProduct];
        }

        this.budgetMoney += this.menu[meal].price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
