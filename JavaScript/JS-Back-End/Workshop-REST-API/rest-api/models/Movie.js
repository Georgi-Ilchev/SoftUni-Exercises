const mongoose = require('mongoose');

const movieSchema = new mongoose.Schema({
    title: {
        type: String,
    },
    image: {
        type: String,
    },
    description: {
        type: String,
    },
    genres: {
        type: String,
    },
    tickets: {
        type: Number,
    },
});

module.exports = mongoose.model('Movie', movieSchema);