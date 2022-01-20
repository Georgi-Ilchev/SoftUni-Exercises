const express = require('express');
const app = express();

const { PORT } = require('./config/config.js');
const routes = require('./routes.js');
const errorHandler = require('./middlewares/errorHandler.js'); // should be after routes!

require('./config/mongoose.js'); // db
require('./config/express.js')(app);

app.use(routes);
app.use(errorHandler);

app.listen(PORT, () => console.log(`Server is running on port ${PORT}...`));
