const { engine } = require('express-handlebars');
const express = require('express');
// const cookieParser = require('cookie-parser');
// const auth = require('../middlewares/auth');

function setupExpress(app) {
    app.engine('hbs', engine({
        extname: 'hbs'
    }));

    app.set('view engine', 'hbs');

    app.use(express.static('public'));

    app.use(express.urlencoded({
        extended: true,
    }));

    // app.use(cookieParser());

    // app.use(auth());
}

module.exports = setupExpress;