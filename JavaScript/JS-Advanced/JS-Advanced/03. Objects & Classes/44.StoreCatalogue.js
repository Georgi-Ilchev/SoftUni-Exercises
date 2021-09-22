function storeCatalogue(array) {
    let productCatalogue = {};

    array.forEach((el) => {
        let [product, price] = el.split(" : ");
        price = Number(price);
        const index = product[0];
        if (!productCatalogue[index]) {
            productCatalogue[index] = {};
        }

        productCatalogue[index][product] = price;
    });

    let sortedProducts = Object.keys(productCatalogue).sort((a, b) => a.localeCompare(b));

    for (const key of sortedProducts) {
        let products = Object.entries(productCatalogue[key]).sort((a, b) => a[0].localeCompare(b[0]));

        console.log(key);

        products.forEach((el) => {
            console.log(`  ${el[0]}: ${el[1]}`);
        });
    }
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
)