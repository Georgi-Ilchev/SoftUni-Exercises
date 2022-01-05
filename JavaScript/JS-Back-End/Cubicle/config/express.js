const { engine } = require('express-handlebars');
const express = require('express');

function setupExpress(app) {
    app.engine('hbs', engine({
        extname: 'hbs'
    }));
    app.set('view engine', 'hbs');
    app.use(express.static('public'));
    app.use(express.urlencoded({
        extended: true,
    }));
}

module.exports = setupExpress;