function solve(input) {
    let result = {};

    input.forEach(line => {
        let [name, price] = line.split(' : ');
        price = Number(price);

        let initialLetter = name[0];

        if (!result[initialLetter]) {
            result[initialLetter] = [];
        }

        let product = { name, price };

        result[initialLetter].push(product);
    });

    let sortedByLetter = Object.entries(result).sort((curr, next) => {
        return curr[0].localeCompare(next[0]);
    })

    for (let i = 0; i < sortedByLetter.length; i++) {
        console.log(sortedByLetter[i][0])

        let sortedByName = sortedByLetter[i][1].sort((curr, next) => curr.name.localeCompare(next.name));
        sortedByName.forEach(n => console.log(`  ${n.name}: ${n.price}`));
    }
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
solve([
    'Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
)


function solve1(input) {
    let products = {};
    let letter = '';

    input.forEach(element => {
        let [name, price] = element.split(' : ');
        products[name] = Number(price);
    });

    let sortedProducts = Object.keys(products).sort((a, b) => a.localeCompare(b));

    for (const product of sortedProducts) {
        if (letter !== product[0]) {
            letter = product[0];
            console.log(letter);
        }
        console.log(`${product}: ${products[product]}`);
    }
}

solve1([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
solve1([
    'Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
)