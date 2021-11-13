import { createTopic, getTopics, createComment, getComments } from './requests.js';
import { createPostsEl, createCommentsEl } from './display.js';
import { isValidData } from './helper.js';

const main = document.querySelector('main'); // index.html -> 37
const displayPosts = createPostsEl.bind(undefined, main);
const displayComments = createCommentsEl.bind(undefined, main);
let post = '';

displayPosts(await getTopics());

document.addEventListener('submit', async e => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const deserializedData = Object.fromEntries([...formData.entries()]);

    const forms = {
        'postForm': async e => {
            if (e.submitter.className === 'public') {
                // if all fields are not empty:
                if (isValidData(deserializedData)) {
                    // sending fetch with method POST to create post in DataBase:
                    await createTopic(deserializedData, Date.now());
                    // re-rendering of all posts with new data:
                    displayPosts(await getTopics());
                } else {
                    alert('Missing fields!');
                    return;
                }
            }

            // clearing input fields
            console.log('here');
            e.target.querySelectorAll('input, textarea').forEach(f => f.value = '');
            // clearFormFields(e.target)
        },
        'commentForm': async () => {
            // creating new comment in DataBase with extra fields: creationDate and the post
            // the comment is about. It is by post name so if 2 posts have the same name
            // the comments will be shared. Can implement by ID but not worth extra work:
            await createComment({ ...deserializedData, creationDate: Date.now() }, post.topicName)
            // re-rendering of comments
            displayComments(post, await getComments(post.topicName));
        }
    };

    // execute form action by submit form ID
    console.log(e.target);
    forms[e.target.id](e);
})

document.addEventListener('click', async e => {
    if (e.target.tagName === 'H2' && e.path[1].className === 'normal') {
        // on clicking post field in main page we need to display all comments about it.
        // we take the post name, send GET http request to DB, get all the data about the post
        // we need and pass it as argument to displayComments, while storing the post itself in
        // global module variable for use in the .addEventListener
        const postName = e.target.textContent;
        const posts = await getTopics();
        post = posts.find(x => x.topicName === postName);
        const comments = await getComments(postName);

        displayComments(post, comments)
    }
    if (e.target.tagName === 'A' && e.target.textContent === 'Home') {
        displayPosts(await getTopics());
    }
})