const { Router } = require('express');
const jwt = require('jsonwebtoken');
const router = Router();

const User = require('../models/User.js');

router.post('/register', (req, res) => {

    // check if user exist

    let user = new User(req.body);

    user.save()
        .then(createdUser => {
            console.log(createdUser);
            res.status(201).json({ _id: createdUser._id });
        });
});

router.post('/login', (req, res, next) => {
    const { login: username, password } = req.body;

    User.findOne({ username, password })
        .then(user => {
            console.log(user);

            let token = jwt.sign({
                _id: user._id,
                username: user.username,
            }, 'SECRET', { expiresIn: '1h' });

            res.status(200).json({
                _id: user._id,
                username: user.username,
                token
            });
        })
        .catch(err => {
            next({ status: 404, message: 'No such user or password!' });
        });
});

module.exports = router;