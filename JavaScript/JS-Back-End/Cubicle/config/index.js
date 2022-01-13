const config = {
    development: {
        PORT: 5000,
        DB_CONNECTION: 'mongodb://localhost/cubicle',
        SALT_ROUNDS: 10,
        SECRET: 'navuhodonosor',
        COOKIE_NAME: 'USER_SESSION',
    },
    production: {
        PORT: 80,
        // DB_CONNECTION: 'insert mongodb atlas connection here',
        DB_CONNECTION: 'mongodb+srv://admin:password@cubicles.omflo.mongodb.net/cubicle?retryWrites=true&w=majority',
        SALT_ROUNDS: 10,
        SECRET: 'navuhodonosor',
        COOKIE_NAME: 'USER_SESSION',
    }
};

module.exports = config[process.env.NODE_ENV.trim()]