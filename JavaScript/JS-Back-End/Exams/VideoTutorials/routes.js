const router = require('express').Router();

const isAuth = require('./middlewares/isAuth.js');

const homeController = require('./controllers/homeController.js');
const authController = require('./controllers/authController.js');
const courseController = require('./controllers/courseController.js');

router.use('/', homeController);
router.use('/auth', authController);
router.use('/course', isAuth, courseController);


module.exports = router;