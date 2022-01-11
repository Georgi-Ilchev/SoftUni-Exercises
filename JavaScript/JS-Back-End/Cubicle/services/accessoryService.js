const Accessory = require('../models/Accessory.js');

function create(data) {
    let accessory = new Accessory(data);

    return accessory.save();
}

function getAll() {
    return Accessory.find().lean();
}

function getAllUnattached(ids) {
    return Accessory.find({ _id: { $nin: ids } }).lean();
}

module.exports = {
    create,
    getAll,
    getAllUnattached,
};