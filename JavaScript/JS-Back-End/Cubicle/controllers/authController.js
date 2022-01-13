const { Router } = require('express');
const authService = require('../services/authService');
const { COOKIE_NAME } = require('../config');
const router = Router();

router.get('/login', (req, res) => {
    res.render('login');
});

router.post('/login', async (req, res) => {
    const { username, password } = req.body;

    try {
        let token = await authService.login({ username, password });

        res.cookie(COOKIE_NAME, token);
        res.redirect('/products');
    } catch (error) {
        res.render('login', { error });
    }

    res.redirect('/products')
});

router.get('/register', (req, res) => {
    res.render('register');
});

router.post('/register', async (req, res) => {
    const { username, password, repeatPassword } = req.body;

    if (password !== repeatPassword) {
        res.render('register', { message: 'Passwords doesn\`t match!' });
        return;
    }

    try {
        let user = await authService.register({ username, password })

        res.redirect('/auth/login');
    } catch (error) {
        res.render('register', { error });
    }
});

module.exports = router;