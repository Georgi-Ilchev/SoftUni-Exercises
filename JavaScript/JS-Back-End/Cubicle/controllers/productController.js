const { Router } = require('express');
const productService = require('../services/productService.js');

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
    res.render('details', { title: 'Details' });
});

//POST
router.post('/create', (req, res) => {
    // VALIDATE INPUTS !!!
    let data = req.body;

    productService.create(data);
    res.redirect('/');
});

module.exports = router;