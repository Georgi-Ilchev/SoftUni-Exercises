const Cube = require('../models/Cube.js');
const productData = require('../data/productData.js');


function getAll(query) {
    let products = productData.getAll(); //with data layer
    //let products = Cube.getAll();

    if (query.search) {
        products = products.filter(x => x.name.toLowerCase().includes(query.search));
    }

    if (query.from) {
        products = products.filter(x => Number(x.level) >= query.from);
    }

    if (query.to) {
        products = products.filter(x => Number(x.level) <= query.to);
    }

    return products;
}

function getOne(id) {
    return productData.getOne(id); //with data layer
    // return Cube.getOne(id);
}

function create(data) {
    let cube = new Cube(data);

    // return productData.create(cube); with data layer
    return cube.save();
}

module.exports = {
    getAll,
    getOne,
    create,
}