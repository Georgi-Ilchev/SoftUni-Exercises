function solve() {
    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    const stocks = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    const commands = {
        restock: (microelement, quantity) => {
            stocks[microelement] += quantity;
            return 'Success';
        },
        prepare: (product, quantity) => {
            let recipe = Object.entries(recipes[product]);
            for (let [item, countNeeded] of recipe) {
                if (stocks[item] < countNeeded * quantity) {
                    return `Error: not enough ${item} in stock`;
                }
            }
            recipe.forEach(([item, countNeeded]) => {
                stocks[item] -= countNeeded * quantity;
            });

            return 'Success';
        },
        report: () => {
            Object.entries(stocks).map(([microElement, count]) => `${microElement}=${count}`).join(' ');
        }
    }
    return (input) => {
        let [command, item, count] = input.split(' ');
        return commands[command](item, +count);
    }
}

let manager = solve();
manager("restock flavour 50");
manager("prepare lemonade 4");
manager("report");




function robot() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    };

    const storage = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0,
    };

    function restock(microelement, quantity) {
        storage[microelement] += Number(quantity);
        return `Success`;
    }

    function prepare(recipe, quantity) {
        const remainingStorage = [];

        for (const element in recipes[recipe]) {
            const remaining = storage[element] - recipes[recipe][element] * quantity;

            if (remaining < 0) {
                return `Error: not enough ${element} in stock`;
            } else {
                remainingStorage[element] = remaining;
            }
        }

        Object.assign(storage, remainingStorage);

        return `Success`;
    }

    function report() {
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
    }

    function control(str) {
        const [command, ingridient, quantity] = str.split(' ');

        switch (command) {
            case 'restock':
                return restock(ingridient, Number(quantity));
            case 'prepare':
                return prepare(ingridient, Number(quantity));
            case 'report':
                return report();
            default:
                break;
        }
    }

    return control;
}