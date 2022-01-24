const router = require('express').Router();
const authService = require('../services/authService.js');
const { COOKIE_NAME } = require('../config/config.js');
const User = require('../models/User.js');

router.get('/', (req, res) => {
    res.send('Auth controller');
});

router.get('/login', (req, res) => {
    res.render('login');
});

router.post('/login', (req, res, next) => {
    const { username, password } = req.body;

    authService.login(username, password)
        .then(token => {
            res.cookie(COOKIE_NAME, token, { httpOnly: true });
            res.redirect('/');
        })
        .catch(err => {
            console.log(err);
            next(err);
        });
});

router.get('/register', (req, res) => {
    res.render('register');
});

router.post('/register', async (req, res, next) => {
    const { username, password, repeatPassword } = req.body;

    const isDuplicate = await User.findOne({ username });

    if (isDuplicate) {
        // return Promise.reject({ message: 'User already exist!', status: 404 });
        return res.render('register', { error: { message: 'User already exist!' } });
    }

    if (password != repeatPassword) {
        res.render('register', { error: { message: 'Passwords should match!' } });
        return;
    }

    authService.register(username, password)
        .then(createdUser => {
            res.redirect('/auth/login');
        })
        .catch(err => {
            let error = Object.keys(err.errors).map(x => ({ message: err.errors[x].message }))[0];
            
            res.render('register', { error });
        });
});

router.get('/logout', (req, res) => {
    res.clearCookie(COOKIE_NAME);
    res.redirect('/');
});

module.exports = router;