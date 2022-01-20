const router = require('express').Router();
const authService = require('../services/authService.js');
const { COOKIE_NAME } = require('../config/config.js');

router.get('/', (req, res) => {
    res.send('Auth controller');
});

router.get('/login', (req, res) => {
    res.render('auth/login');
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
    res.render('auth/register');
});

router.post('/register', (req, res, next) => {
    const { username, password, repeatPassword } = req.body;
    
    if (password != repeatPassword) {
        res.render('auth/register', { error: { message: 'Passwords should match!' } });
        return;
    }

    authService.register(username, password)
        .then(createdUser => {
            console.log('createdUser');
            console.log(createdUser);
            res.redirect('/auth/login');
        })
        .catch(err => next(err));
});

router.get('/logout', (req, res) => {
    res.clearCookie(COOKIE_NAME);
    res.redirect('/');
});

module.exports = router;