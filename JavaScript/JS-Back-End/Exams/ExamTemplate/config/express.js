const express = require('express');
const cookieParser = require('cookie-parser');
const hbs = require('express-handlebars');
const auth = require('../middlewares/auth.js');

module.exports = function (app) {
    app.engine('hbs', hbs.engine({
        extname: 'hbs',
    }));

    app.set('view engine', 'hbs');

    app.use('/static', express.static('public'));

    app.use(express.urlencoded({ extended: true }));

    app.use(cookieParser());

    app.use(auth);
};