class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error(`The budget cannot be a negative number`);
        }
        this._budget = value;
    }

    shopping([productName, price]) {
        if (price > this.budget) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(productName);
        this.budget -= price;
        return `You have successfully bought ${productName}!`;
    }

    recipes({ recipeName, productsList }) {
        if (productsList.some(p => this.products.includes(p) == false)) {
            throw new Error(`We do not have this product`);
        }

        this.dishes.push({ recipeName, productsList });

        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        let wantedDish = this.dishes.find(d => d.recipeName == dish);
        let guest = this.guests.hasOwnProperty(name);

        if (wantedDish == false) {
            throw new Error('We do not have this dish');
        }

        if (guest == true) {
            throw new Error('This guest has already been invited');
        }

        // this.guests[name] = this.dishes[dish];
        // this.guests[name] = wantedDish;
        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        //1
        // let result = [];

        // Object.entries(this.guests).forEach(([guestName, dish]) => {
        //     result.push(`${guestName} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(', ')}`);
        // });

        // return result.join('\n');

        //2 with reduce
        // return Object
        //     .entries(this.guests)
        //     .reduce((acc, [guestName, dish]) => [...acc, `${guestName} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(', ')}`], [])
        //     .join('\n');

        //3
        let result = [];

        for (const guest in this.guests) {
            const dish = this.guests[guest];
            const products = this.dishes.find(x => x.recipeName === dish).productsList;

            result.push(`${guest} will eat ${dish}, which consists of ${products.join(', ')}`);
        }

        return result.join('\n');
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
