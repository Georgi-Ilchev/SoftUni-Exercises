const express = require('express');

const config = require('./config/config.js');
const routes = require('./routes.js');
const app = express();

const expressConfig = require('./config/express.js');
const mongooseConfig = require('./config/mongoose.js');

expressConfig(app);
mongooseConfig(app);

console.log(process.env.NODE_ENV);

app.use(routes);
app.listen(config.PORT, () => console.log(`Server is running on port ${config.PORT}...`));