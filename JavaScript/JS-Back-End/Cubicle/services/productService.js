const Cube = require('../models/Cube.js');
const Accessory = require('../models/Accessory');
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

function getOneWithAccessories(id) {
    return Cube.findById(id)
        .populate('accessories')
        .lean();
}

function create(data, userId) {
    let cube = new Cube({ ...data, creator: userId });

    return cube.save();
}

async function attachAccessory(productId, accessoryId) {
    let product = await Cube.findById(productId)
    let accessry = await Accessory.findById(accessoryId);

    product.accessories.push(accessry);
    return product.save();
}

function updateOne(productId, productData) {
    return Cube.updateOne({ _id: productId }, productData);
}

function deleteOne(productId) {
    return Cube.deleteOne({ _id: productId });
}

module.exports = {
    getAll,
    getOne,
    getOneWithAccessories,
    create,
    attachAccessory,
    updateOne,
    deleteOne,
}