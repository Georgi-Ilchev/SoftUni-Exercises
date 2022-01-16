const { Router } = require('express');
const authController = require('./controllers/authController.js');
const movieController = require('./controllers/movieController.js');

const router = Router();

router.use('/auth', authController);
router.use('/movies', movieController);

module.exports = router;