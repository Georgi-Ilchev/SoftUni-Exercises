const express = require('express');
const config = require('./config/config.js');
const app = express();
const expressConfig = require('./config/express.js');

expressConfig(app);

console.log(process.env.NODE_ENV);

app.get('/', (req, res) => {
    res.render('home', { layout: false });
});
app.listen(config.PORT, () => console.log(`Server is running on port ${config.PORT}...`));