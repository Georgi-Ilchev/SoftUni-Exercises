const uniqid = require('uniqid');
const Cube = require('../models/Cube.js');
const fs = require('fs');
const path = require('path');

let productsData = require('../config/products.json');

function getAll(query) {
    let result = productsData;

    if (query.search) {
        result = result.filter(x => x.name.toLowerCase().includes(query.search));
    }

    if (query.from) {
        result = result.filter(x => Number(x.level) >= query.from);
    }

    if (query.to) {
        result = result.filter(x => Number(x.level) <= query.to);
    }

    return result;
}

function getOne(id) {
    return productsData.find(x => x.id == id);
}

function create(data, callback) {
    let cube = new Cube(uniqid(), data.name, data.description, data.imageUrl, data.difficultyLevel);

    productsData.push(cube);

    //1
    // fs.writeFile(__dirname + '/../config/products.json', JSON.stringify(productsData), (err) => {
    //     if (err) {
    //         console.log(err);
    //         return;
    //     }
    // });

    //2
    // fs.writeFile(path.join(__dirname, '../config/products.json'), JSON.stringify(productsData), (err) => {
    //     if (err) {
    //         console.log(err);
    //         return;
    //     }
    // });

    //3
    fs.writeFile(
        path.join(__dirname, '../config/products.json'),
        JSON.stringify(productsData),
        callback
    );

    //4 - not working
    // return fs.writeFile(
    //     path.join(__dirname, '../config/products.json'),
    //     JSON.stringify(productsData),
    //     () => { }
    // );
}

module.exports = {
    getAll,
    getOne,
    create,
}