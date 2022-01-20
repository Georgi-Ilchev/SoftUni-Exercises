const mongoose = require('mongoose');
const { DB_URI } = require('./config.js');

mongoose.connect(DB_URI, { useNewUrlParser: true, useUnifiedTopology: true });

const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
    console.log('DB is connected!');
});

module.exports = db;