const { Router } = require('express');
const accessoryService = require('../services/accessoryService.js');
const { validateAccessory } = require('./helpers/accessoryHelper.js');

const router = Router();

router.get('/create', (req, res) => {
    res.render('createAccessory');
});

router.post('/create', validateAccessory, (req, res) => {
    accessoryService.create(req.body)
        .then(() => res.redirect('/'))
        .catch(() => res.status(404).end())
})

module.exports = router;