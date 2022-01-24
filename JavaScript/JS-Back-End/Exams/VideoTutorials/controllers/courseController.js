const router = require('express').Router();
const courseService = require('../services/courseService.js');

router.get('/create', (req, res) => {
    res.render('createCourse');
});

router.post('/create', (req, res, next) => {
    let courseData = extractCourseData(req);

    courseService.create(courseData, req.user._id)
        .then(createdCourse => {
            res.redirect('/');
        })
        .catch(next);
});

router.get('/:courseId/details', (req, res, next) => {
    courseService.getOne(req.params.courseId, req.user._id)
        .then(course => {
            res.render('courseDetails', course);
        })
        .catch(next);
});

router.get('/:courseId/enroll', (req, res, next) => {
    courseService.enrollUser(req.params.courseId, req.user._id)
        .then(() => {
            res.redirect(`/course/${req.params.courseId}/details`);
        })
        .catch(next);
});

router.get('/:courseId/delete', (req, res, next) => {
    //delete only if current user is owner

    courseService.del(req.params.courseId)
        .then(() => {
            res.redirect('/');
        })
        .catch(next);
});

router.get('/:courseId/edit', (req, res, next) => {
    courseService.getOne(req.params.courseId, req.user._id)
        .then(course => {
            course.checked = course.isPublic ? 'checked' : '';

            res.render('editCourse', course);
        })
        .catch(next);
});

router.post('/:courseId/edit', (req, res, next) => {
    let courseData = extractCourseData(req);

    courseService.update(req.params.courseId, courseData)
        .then(() => {
            res.redirect(`/course/${req.params.courseId}/details`);
        })
        .catch(next);
});

function extractCourseData(req) {
    let { title, description, imageUrl, isPublic } = req.body;

    let courseData = {
        title,
        description,
        imageUrl,
        isPublic: Boolean(isPublic),
    };

    return courseData;
}

module.exports = router;