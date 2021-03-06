function solve(input) {
    let products = {};

    input.forEach(row => {
        let [town, product, priceAsText] = row.split(' | ');
        let price = Number(priceAsText);

        if (!products[product] || products[product].price > price || products[product].town == town) {
            products[product] = {
                town: town,
                price: price,
            };
        }
    });

    Object.keys(products).forEach(product => console.log(`${product} -> ${products[product].price} (${products[product].town})`));
};
//80 points

solve(
    ['Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10']
);

function printLowestPrices(params) {
    let stat = new Map();

    for (const row of params) {
        let [town, product, price] = row.split('|').map(e => e.trim());

        if (!stat.get(product)) {
            stat.set(product, new Map());
        }

        stat.get(product).set(town, Number(price));
    }

    let result = '';

    for (const kvp of stat) {
        let lowestPrice = [...kvp[1]].sort((a, b) => a[1] - b[1])[0];
        result += `${kvp[0]} -> ${lowestPrice[1]} (${lowestPrice[0]})\n`;
    }

    console.log(result.trim());
}