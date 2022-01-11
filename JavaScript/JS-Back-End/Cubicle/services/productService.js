const Cube = require('../models/Cube.js');
const productData = require('../data/productData.js');

async function getAll(query) {
    //let products = productData.getAll(); //with data layer
    //let products = Cube.getAll();
    let products = await Cube.find({}).lean();

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
    //return productData.getOne(id); //with data layer
    // return Cube.getOne(id);
    return Cube.findById(id).lean();
}

function create(data) {
    // Validate incoming data
    let cube = new Cube(data);

    return cube.save();
}

module.exports = {
    getAll,
    getOne,
    create,
}