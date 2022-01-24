const Course = require('../models/Course.js');

const create = (courseData, userId) => {
    let course = new Course({ ...courseData, createdAt: new Date(), creator: userId });

    return course.save();
};

const getAll = (search) => {
    if (search) {
        return Course
            .find({ title: { $regex: search, $options: 'i' } })
            .sort({ createdAt: -1 })
            .lean();
    } else {
        return Course
            .find({})
            .sort({ createdAt: -1 })
            .lean();
    }
}

const getOne = (id, userId) =>
    Course
        .findById(id)
        .then(course => {
            course.isEnrolled = course.usersEnrolled.includes(userId);
            course.isOwn = course.creator == userId;

            return course;
        });

const enrollUser = (courseId, userId) => {
    return Course.findById(courseId)
        .then(course => {
            course.usersEnrolled.push(userId);
            return course.save();
        })
};

const del = (courseId) => {
    return Course.deleteOne({ _id: courseId });
};

const update = (courseId, courseData) => {
    return Course.updateOne({ _id: courseId }, courseData);
};

const getPopular = (size) => {
    return Course
        .find()
        .sort({ usersEnrolled: -1 })
        .limit(size)
        .lean();
}

module.exports = {
    create,
    getAll,
    getOne,
    enrollUser,
    del,
    update,
    getPopular,
};