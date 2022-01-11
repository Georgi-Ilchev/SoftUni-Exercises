const { Router } = require('express');
const productService = require('../services/productService.js');
const accessoryService = require('../services/accessoryService.js');
// const isAuthenticated = require('../middlewares/isAuthenticated');
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
    let product = await productService.getOneWithAccessories(req.params.productId);

    res.render('details', { title: 'Details', product });
});

router.get('/:productId/attach', async (req, res) => {
    let product = await productService.getOne(req.params.productId);
    let accessories = await accessoryService.getAllUnattached(product.accessories);

    res.render('attachAccessory', { product, accessories });
})

router.post('/:productId/attach', (req, res) => {
    productService.attachAccessory(req.params.productId, req.body.accessory)
        .then(() => res.redirect(`/products/details/${req.params.productId}`))
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
        .then(() => res.redirect('/products'))
        .catch(() => res.status(500).end())
        // .catch(next)
});

module.exports = router;