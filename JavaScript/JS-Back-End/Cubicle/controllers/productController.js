const { Router } = require('express');
const productService = require('../services/productService.js');
const { validateProduct } = require('./helpers/productHelpers.js');

const router = Router();

//GET
router.get('/', (req, res) => {
    let products = productService.getAll();
    res.render('home', { title: 'Browse', products });
});

router.get('/create', (req, res) => {
    res.render('create', { title: 'Create' });
});

router.get('/details/:productId', (req, res) => {
    let product = productService.getOne(req.params.productId);

    res.render('details', { title: 'Details', product });
});

//POST
router.post('/create', validateProduct, (req, res) => {
    let data = req.body;
    productService.create(data);

    res.redirect('/');
});

module.exports = router;