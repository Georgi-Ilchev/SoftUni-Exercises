function lowestPrice(array) {
    let catalogue = {};
    array.forEach((el) => {
        let [town, product, price] = el.split(" | ");
        price = Number(price);

        if (catalogue[product] == undefined) {
            catalogue[product] = {};
        }
        catalogue[product][town] = price;
    });

    for (const prod in catalogue) {
        const sorted = Object.entries(catalogue[prod]).sort((a, b) => a[1] - b[1]);

        console.log(`${prod} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }
}

lowestPrice(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
)