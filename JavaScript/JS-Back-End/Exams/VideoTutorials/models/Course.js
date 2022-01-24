const mongoose = require('mongoose');


const courseSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true,
        minlength: 4,
    },
    description: {
        type: String,
        required: true,
        minlength: 20,
        maxlength: 50,
    },
    imageUrl: {
        type: String,
        required: true,
        validate: /^https?/,
    },
    isPublic: {
        type: Boolean,
        default: false,
    },
    createdAt: {
        type: Date,
        required: true,
    },
    usersEnrolled: [{
        type: mongoose.Types.ObjectId,
        ref: 'User',
    }],
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
    }
});

// courseSchema.pre('save', function (next) {
//     this.createdAt = new Date();

//     next();
// });

module.exports = mongoose.model('Course', courseSchema);
