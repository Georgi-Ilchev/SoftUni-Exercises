function attachEvents() {
    const loadPostBtn = document.getElementById('btnLoadPosts');
    const viewPostBtn = document.getElementById('btnViewPost');

    loadPostBtn.addEventListener('click', getAllPosts);
    viewPostBtn.addEventListener('click', displayPost);
}

attachEvents();

async function displayPost() {
    const selectedId = document.getElementById('posts').value;
    const title = document.getElementById('post-title');
    const body = document.getElementById('post-body');
    const ulElement = document.getElementById('post-comments');

    title.textContent = 'Loading...';
    body.textContent = '';
    ulElement.replaceChildren();

    const [post, comments] = await Promise.all([
        getPostById(selectedId),
        getCommentsByPostId(selectedId)
    ]);

    title.textContent = post.title;
    body.textContent = post.body;

    comments.forEach(c => {
        const liElement = document.createElement('li');
        liElement.textContent = c.text;
        ulElement.appendChild(liElement);
    })
}

async function getAllPosts() {
    const url = `http://localhost:3030/jsonstore/blog/posts`;

    const res = await fetch(url);
    const data = await res.json();

    const select = document.getElementById('posts');
    select.replaceChildren();

    Object.values(data).forEach(p => {
        const optionEl = document.createElement('option');
        optionEl.textContent = p.title;
        optionEl.value = p.id;

        select.appendChild(optionEl);
    })
}

async function getPostById(postId) {
    const url = `http://localhost:3030/jsonstore/blog/posts/` + postId;

    const res = await fetch(url);
    const data = await res.json();

    return data;
}

async function getCommentsByPostId(postId) {
    const url = `http://localhost:3030/jsonstore/blog/comments`;

    const res = await fetch(url);
    const data = await res.json();

    const comments = Object.values(data).filter(c => c.postId == postId);

    return comments;
}


////////////////////////////////////////////////////


function attachEvents() {
    document.querySelector('#btnLoadPosts').addEventListener('click', loadPosts);
    const viewBtn = document.querySelector('#btnViewPost');
    viewBtn.addEventListener('click', viewPosts);
    viewBtn.disabled = true;
}

async function loadPosts(e) {
    e.target.textContent = 'loading...';
    e.target.disabled = true;
    const options = document.querySelector('#posts');
    const res = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const posts = await res.json();

    for (let p in posts) {
        const opt = document.createElement('option');
        opt.value = posts[p].id;
        opt.textContent = posts[p].title;
        options.appendChild(opt);
    }
    e.target.textContent = 'Posts:';
    e.target.nextElementSibling.nextElementSibling.disabled = false;
}

async function viewPosts(e) {
    e.target.textContent = 'Loading...';
    e.target.disabled = true;
    const postId = document.querySelector('#posts').value;
    const [post, comments] = await Promise.all([
        fetch('http://localhost:3030/jsonstore/blog/posts/' + postId).then((resP) => resP.json()),
        fetch('http://localhost:3030/jsonstore/blog/comments').then((resC) => resC.json())
    ]);

    document.querySelector('#post-title').textContent = post.title;
    document.querySelector('#post-body').textContent = post.body;
    const postComments = document.querySelector('#post-comments');
    postComments.replaceChildren();
    Object.values(comments).filter(c => c.postId == postId).forEach(c => {
        const li = document.createElement('li');
        li.textContent = c.text;
        postComments.appendChild(li);
    });

    e.target.textContent = 'View';
    e.target.disabled = false;
}

attachEvents();