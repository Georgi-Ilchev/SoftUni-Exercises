const router = require('express').Router();
const isAuth = require('../middlewares/isAuth.js');
const courseService = require('../services/courseService.js');
const moment = require('moment'); //library for date

router.get('/', (req, res, next) => {
    if (req.user) {
        courseService.getAll(req.query.search)
            .then(courses => {
                courses = courses.map(x => ({ ...x, createdAt: moment(x.createdAt).format('MMM Do YY, h:mm:ss a') }))
                res.render('home', { courses });
            })
            .catch(next);
    } else {
        courseService.getPopular(3)
            .then(courses => {
                res.render('home', { courses });
            })
            .catch(next);
    }
});

module.exports = router;