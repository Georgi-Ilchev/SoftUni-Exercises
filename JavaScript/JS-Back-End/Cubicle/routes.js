const { Router } = require('express');

const productController = require('./controllers/productController.js');
const accessoryController = require('./controllers/accessoryController.js');
const homeController = require('./controllers/homeController.js');
const authController = require('./controllers/authController.js');

const router = Router();

router.use('/', homeController);
router.use('/auth', authController);
router.use('/products', productController);
router.use('/accessories', accessoryController);
router.get('*', (req, res) => {
    res.render('404', { title: 'Not Found' });
});

module.exports = router;