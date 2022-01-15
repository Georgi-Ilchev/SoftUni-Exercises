const express = require('express');
// const cors = require('./middlewares/cors.js');
const cors = require('cors');
const app = express();

// app.use(cors);
app.use(cors());

app.get('/', (req, res) => {
    res.json({ message: 'It\'s working!' });
});

app.listen(5000, console.log.bind(console, 'Server is listening on port 5000...'));