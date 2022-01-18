module.exports = (err, req, res, next) => {
    err.status = err.status || 500;
    err.message = err.message || 'Something went wrong!';

    if (process.env(NODE_ENV == 'development')) {
        console.log(err);
    }

    res.status(err.status).json({ message: err.message });
}