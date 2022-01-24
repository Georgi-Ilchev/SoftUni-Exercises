const User = require('../models/User.js');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SECRET } = require('../config/config.js');

const register = /*async*/ (username, password) => {
    // const isDuplicate = await User.findOne({ username });

    // if (isDuplicate) {
    //     return Promise.reject({ message: 'User already exist!', status: 404 });
    // }

    let user = new User({ username, password });

    return user.save();
};

const login = async (username, password) => {
    let user = await User.findOne({ username });

    if (!user) {
        return Promise.reject({ message: 'No such user', status: 404 });
    }

    let areEqual = await bcrypt.compare(password, user.password);

    if (!areEqual) {
        return Promise.reject({ message: 'Invalid password', status: 404 });
    }

    let token = jwt.sign({ _id: user._id, username: user.username }, SECRET);

    return token;
};

// const login = (username, password) => {
//     return User.findOne({ username })
//         .then(user => {
//             if (!user) {
//                 // return Promise.reject({ message: 'No such user', status: 404 });
//                 throw { message: 'No such user', status: 404 };
//             }

//             return Promise.all([bcrypt.compare(password, user.password), user]);
//         })
//         .then(areEqual => {
//             if (!areEqual) {
//                 return Promise.reject({ message: 'Invalid password', status: 404 });
//             }

//             return user;
//         })
// };

module.exports = {
    login,
    register,
}