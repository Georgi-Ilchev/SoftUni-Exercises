const { Router } = require('express');

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

module.exports = router;