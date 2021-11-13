import { e } from './helper.js';

// index.html -> 38 row - 61 row
function formTemplate() {
    // index.html => 38 row
    const innerHTML = `<div class="header-background">
<span>New Topic</span>
</div>
<form id="postForm">
    <div class="new-topic-title">
        <label for="topicName">Title <span class="red">*</span></label>
        <input type="text" name="topicName" id="topicName">
    </div>
    <div class="new-topic-title">
        <label for="username">Username <span class="red">*</span></label>
        <input type="text" name="username" id="username">
    </div>
    <div class="new-topic-content">
        <label for="postText">Post <span class="red">*</span></label>
        <textarea type="text" name="postText" id="postText" rows="8" class="height"></textarea>
    </div>
    <div class="new-topic-buttons">
        <button class="cancel">Cancel</button>
        <button class="public">Post</button>
    </div>
</form>`

    return e('div', 'new-topic-border', innerHTML);
}

function singlePost({ topicName, creationDate, username, _id }) {
    // example.html -> 3 row - 21 row
    const date = new Date(creationDate);
    const innerHTML = `<div class="topic-name-wrapper">
<div class="topic-name">
<a href="#" class="normal">
<h2>${topicName}</h2>
</a>
<div class="columns">
<div>
<p>Date:
<time>${date.toLocaleString()}</time>
</p>
<div class="nick-name">
<p>Username: <span>${username}</span></p>
</div>
</div>
</div>
</div>
</div>`;

    const post = e('div', 'topic-container', innerHTML);
    post.id = _id;

    return post;
}

function singleComment({ username, postText, creationDate }) {
    //example.html => 26 - 35 row
    const date = new Date(creationDate);
    const innerHTML = `<div class="header">
<img src="./static/profile.png" alt="avatar">
<p><span>${username}</span> posted on <time>${date.toLocaleString()}</time></p>
<p class="post-content">${postText}</p>
</div>`;

    return e('div', 'comment', innerHTML);
}

function commentPost({ topicName, creationDate }) {
    const date = new Date(creationDate);
    const innerHTML = `<div class="topic-title">
<div class="topic-name-wrapper">
    <div class="topic-name">
        <h2>${topicName}</h2>
        <p>Date: <time>${date.toLocaleString()}</time></p>
    </div>
    <div class="subscribers">
        <p>Subscribers: <span></span></p>
    </div>
</div>`;

    return e('div', 'topic-content', innerHTML);
}

function addCommentForm() {
    // theme-content.html -> 51 - 63 row
    const innerHTML = `<p><span>currentUser</span> comment:</p>
<div class="answer">
    <form id="commentForm">
        <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
        <div>
            <label for="username">Username <span class="red">*</span></label>
            <input type="text" name="username" id="username">
        </div>
        <button>Post</button>
    </form>
</div>`;

    return e('div', 'answer-comment', innerHTML);
}

function createPostsEl(parent, postsData) {
    const wrapper = e('div', 'topic-title');

    postsData.forEach(p => wrapper.appendChild(singlePost(p)));
    parent.innerHTML = `${formTemplate().outerHTML}\n${wrapper.outerHTML}`;
}

function createCommentsEl(parent, postData, commentsData) {
    const commentPostEl = commentPost(postData);

    commentsData.forEach(c => commentPostEl.appendChild(singleComment(c)));
    parent.innerHTML = `${commentPostEl.outerHTML}\n${addCommentForm().outerHTML}`;
}

// function e(tag, className = '', content = '') {
//     const e = document.createElement(tag)
//     e.classList.add(className)
//     e.innerHTML = content

//     return e
// }

export { createPostsEl, createCommentsEl };