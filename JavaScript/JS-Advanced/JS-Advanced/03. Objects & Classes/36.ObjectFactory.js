function factory(libraryObject, ordersArray) {
    return ordersArray.map(compose);

    //Create empty object and copy properties from template
    function compose(order) {
        const result = Object.assign({}, order.template);

        //Compose methods from library for every item in parts
        for (let part of order.parts) {
            result[part] = libraryObject[part];
        }

        //return result
        return result;
    }
}

function factory1(libraryObject, ordersArray) {
    const result = [];

    //Create empty object and copy properties from template
    for (let order of ordersArray) {
        const device = Object.assign({}, order.template);

        //Compose methods from library for every item in parts
        for (let part of order.parts) {
            device[part] = libraryObject[part];
        }

        //save result
        result.push(device);
    }

    return result;
}

const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};
const orders = [
    {
        template: { name: 'ACME Printer' },
        parts: ['print']
    },
    {
        template: { name: 'Initech Scanner' },
        parts: ['scan']
    },
    {
        template: { name: 'ComTron Copier' },
        parts: ['scan', 'print']
    },
    {
        template: { name: 'BoomBox Stereo' },
        parts: ['play']
    }
];
const products = factory(library, orders);
console.log(products);
