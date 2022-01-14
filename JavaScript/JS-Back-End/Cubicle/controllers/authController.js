const { Router } = require('express');
const authService = require('../services/authService');
const { COOKIE_NAME } = require('../config');
const validator = require('validator');
const { check, validationResult, body } = require('express-validator');
const router = Router();

const isAuthenticated = require('../middlewares/isAuthenticated.js');
const isGuest = require('../middlewares/isGuest.js');

const isStrongPasswordMiddleware = (req, res, next) => {
    let password = req.body.password;

    let isStrongPassword = validator.isStrongPassword(password, {
        minLength: 8,
        minLowercase: 1,
        minUppercase: 1,
        minNumbers: 1,
        minSymbols: 1,
    });

    if (!isStrongPassword) {
        return res.render('register', { error: { message: 'You should have strong password!' }, username: req.body.username });
    }

    next();
}

router.get('/login', isGuest, (req, res) => {
    res.render('login');
});

router.post('/login', isGuest, async (req, res) => {
    const { username, password } = req.body;

    try {
        let token = await authService.login({ username, password });

        res.cookie(COOKIE_NAME, token);
        res.redirect('/products');
    } catch (error) {
        res.render('login', { error });
    }

    // res.redirect('/products')
});

router.get('/register', isGuest, (req, res) => {
    res.render('register');
});

router.post('/register',
    isGuest,
    /*isStrongPasswordMiddleware,*/
    // body('email', 'Your email is invalid!').isEmail().normalizeEmail(),
    // check('username', 'Username is required!').notEmpty(),
    // body('password', 'Password too short').isLength({ min: 5 }),
    async (req, res) => {
        const { username, password, repeatPassword } = req.body;

        if (password !== repeatPassword) {
            res.render('register', { error: { message: 'Passwords doesn\`t match!' } });
            return;
        }

        // let errors = validationResult(req);

        // if (errors.errors.length > 0) {
        //     res.render('register', errors);
        //     return;
        // }

        try {
            let user = await authService.register({ username, password });

            res.redirect('/auth/login');
        } catch (err) {
            let error = Object.keys(err?.errors).map(x => ({ message: err.errors[x].properties.message }))[0];
            res.render('register', { error });
        }
    });

router.get('/logout', isAuthenticated, (req, res) => {
    res.clearCookie(COOKIE_NAME);
    res.redirect('/products');
});



module.exports = router;