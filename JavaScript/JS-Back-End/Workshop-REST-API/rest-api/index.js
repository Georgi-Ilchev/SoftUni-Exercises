const express = require('express');
const mongoose = require('mongoose');
// const cors = require('./middlewares/cors.js');
const cors = require('cors');
const routes = require('./routes.js');
const { auth } = require('./middlewares/auth.js');
const errorHandler = require('./middlewares/errorHandler.js'); /* after routes / before app.listen */

const app = express();

mongoose.connect('mongodb://localhost/softuni-movies');
const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
    console.log.bind(console, 'DB connected');
});

// app.use(cors);
app.use(cors());
app.use(express.json());

app.use(auth);

app.get('/', (req, res) => {
    res.json({ message: 'It\'s working!' });
});

app.use('/api', routes);

app.use(errorHandler);

app.listen(5000, console.log.bind(console, 'Server is listening on port 5000...'));