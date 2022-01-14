const bcrypt = require('bcrypt');
const { SALT_ROUNDS, SECRET } = require('../config');
const jwt = require('jsonwebtoken');
const User = require('../models/User.js');

const login = async ({ username, password }) => {
    let user = await User.findOne({ username });

    if (!user) {
        throw { message: 'Unsuccessful login atempt!' }
    }

    let isMatch = await bcrypt.compare(password, user.password);

    if (!isMatch) {
        console.log('here');
        throw { message: 'Password does\`t match!' }
    }

    let token = jwt.sign({ _id: user._id }, SECRET);

    return token;
};

const register = async ({ username, password }) => {
    // check if username exists 
    if (await User.findOne({ username })) {
        throw { message: 'Username already exist!' }
    }

    //1
    // let salt = await bcrypt.genSalt(SALT_ROUNDS);
    // let hash = await bcrypt.hash(password, salt);

    const user = new User({ username, password /*: hash */ });
    return await user.save();
};

module.exports = {
    login,
    register,
}