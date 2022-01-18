const { Router } = require('express');
const Movie = require('../models/Movie.js');
const { isAuth } = require('../middlewares/auth.js');

const router = Router();

router.get('/', (req, res) => {
    Movie.find()
        .then(movies => {
            res.json(movies);
        });
});

router.post('/', isAuth, (req, res) => {
    // console.log(req.body);
    // console.log(req.user);

    // res.json(req.body);

    let movie = new Movie(req.body);

    movie.save()
        .then(createdMovie => {
            res.status(201).json({ _id: createdMovie._id });
        });
});


module.exports = router;