const router = require('express').Router();
const isAuth = require('../middlewares/isAuth.js');

router.get('/', (req, res) => {
    res.render('home/index');
});

router.get('/secret-action', isAuth, (req, res) => {
    res.send('very secret');
});

module.exports = router;