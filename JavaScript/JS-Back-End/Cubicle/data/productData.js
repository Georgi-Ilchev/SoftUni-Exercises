const fs = require('fs');
const path = require('path');
const productsData = require('../config/products.json');

module.exports = {
    getAll() {
        return productsData;
    },

    getOne(id) {
        return productsData.find(x => x.id == id);
    },

    create(product) {
        //1
        // productsData.push(product);
        // fs.writeFile(__dirname + '/../config/products.json', JSON.stringify(productsData), (err) => {
        //     if (err) {
        //         console.log(err);
        //         return;
        //     }
        // });

        //2
        productsData.push(product);
        fs.writeFile(path.join(__dirname, '../config/products.json'), JSON.stringify(productsData), (err) => {
            if (err) {
                console.log(err);
                return;
            }
        });

        //3
        // productsData.push(product);
        // fs.writeFile(
        //     path.join(__dirname, '../config/products.json'),
        //     JSON.stringify(productsData),
        //     () => { }
        // );

        //4
        // productsData.push(product);
        // return fs.writeFile(
        //     path.join(__dirname, '../config/products.json'),
        //     JSON.stringify(productsData),
        //     () => { }
        // );
    }
}