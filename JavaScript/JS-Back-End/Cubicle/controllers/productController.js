const { Router } = require('express');
const productService = require('../services/productService.js');
const { validateProduct } = require('./helpers/productHelpers.js');

const router = Router();

//GET
router.get('/', (req, res) => {
    //req.query => search
    let products = productService.getAll(req.query);
    
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

//1 and 2 -> productService
// router.post('/create', validateProduct, (req, res) => {
//     let data = req.body;
//     productService.create(data);

//     res.redirect('/');
// });

//3
router.post('/create', validateProduct, (req, res) => {
    productService.create(req.body, (err) => {
        if (err) {
            return res.status(500).end();
        }
        res.redirect('/');
    });
});

//4 - not working
// router.post('/create', validateProduct, (req, res) => {
//     productService.create(req.body)
//         .then(() => res.redirect('/'))
//         .catch(() => res.status(500).end())
// });

module.exports = router;