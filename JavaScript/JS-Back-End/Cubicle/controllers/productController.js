const { Router } = require('express');
const productService = require('../services/productService.js');
const { validateProduct } = require('./helpers/productHelpers.js');

const router = Router();

router.get('/', (req, res) => {
    //req.query => search
    productService.getAll(req.query)
        .then(products => {
            res.render('home', { title: 'Browse', products });
        })
        .catch(() => res.status(404).end())
});

router.get('/create', (req, res) => {
    res.render('create', { title: 'Create' });
});

router.get('/details/:productId', async (req, res) => {
    let product = await productService.getOne(req.params.productId);

    res.render('details', { title: 'Details', product });
});

//1 and 2 -> models - Cube || data - productData
// router.post('/create', validateProduct, (req, res) => {
//     let data = req.body;
//     productService.create(data);

//     res.redirect('/');
// });

//3
// router.post('/create', validateProduct, (req, res) => {
//     productService.create(req.body, (err) => {
//         if (err) {
//             return res.status(500).end();
//         }
//         res.redirect('/');
//     });
// });

//4
router.post('/create', validateProduct, (req, res) => {
    productService.create(req.body)
        .then(() => res.redirect('/'))
        .catch(() => res.status(500).end())
});

module.exports = router;