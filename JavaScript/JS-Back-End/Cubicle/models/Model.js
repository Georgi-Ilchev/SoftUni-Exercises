const fs = require('fs/promises');
const path = require('path');
const productsData = require('../config/products.json');

class Model {
    save() {
        productsData.push(this);

        return fs.writeFile(
            path.join(__dirname, '../config/products.json'),
            JSON.stringify(productsData),
            () => { }
        );
    }

    static getAll() {
        return productsData;
    }

    static getOne(id) {
        return productsData.find(x => x.id == id);
    }
}

module.exports = Model;

//1
// productsData.push(this);
// fs.writeFile(__dirname + '/../config/products.json', JSON.stringify(productsData), (err) => {
//     if (err) {
//         console.log(err);
//         return;
//     }
// });

//2
// productsData.push(this);
// fs.writeFile(path.join(__dirname, '../config/products.json'), JSON.stringify(productsData), (err) => {
//     if (err) {
//         console.log(err);
//         return;
//     }
// });

//3
// productsData.push(this);
// fs.writeFile(
//     path.join(__dirname, '../config/products.json'),
//     JSON.stringify(productsData),
//     () => { }
// );

//4
// productsData.push(this);
// return fs.writeFile(
//     path.join(__dirname, '../config/products.json'),
//     JSON.stringify(productsData),
//     () => { }
// );