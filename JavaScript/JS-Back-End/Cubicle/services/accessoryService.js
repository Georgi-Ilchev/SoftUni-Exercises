const Accessory = require('../models/Accessory.js');

function create(data) {
    let accessory = new Accessory(data);

    return accessory.save();
}

module.exports = {
    create,
};