const mongoose = require('mongoose');

const accessorySchema = new mongoose.Schema({
    id: {
        type: mongoose.Types.ObjectId
    },
    name: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
        maxlength: 50,
    },
    imageUrl: {
        type: String,
        required: true,
        validate: /^https?/,
    },
    cubes: [{
        type: mongoose.Types.ObjectId,
        ref: 'Cube',
    }]
});

module.exports = mongoose.model('Accessory', accessorySchema);