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
