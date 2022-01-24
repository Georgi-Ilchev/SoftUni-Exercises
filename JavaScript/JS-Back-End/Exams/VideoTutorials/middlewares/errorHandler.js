const errorHandler = (err, req, res, next) => {
    err.message = err.message || 'Something went wrong';
    err.status = err.status || 500;

    console.log(err);

    res.status(err.status).render('home', { error: err });
};

module.exports = errorHandler;