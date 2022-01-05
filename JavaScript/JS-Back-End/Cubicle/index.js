const express = require('express');
const config = require('./config/config.js');

const app = express();

console.log(process.env.NODE_ENV);

app.listen(config.PORT, () => console.log(`Server is running on port ${config.PORT}...`));