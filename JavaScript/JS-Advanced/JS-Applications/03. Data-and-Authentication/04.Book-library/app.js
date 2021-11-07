const booksList = document.querySelector('tbody');
const createForm = document.getElementById('createForm');
const editForm = document.getElementById('editForm');
const loadBook = document.getElementById('loadBooks');

booksList.addEventListener('click', onTableClick);

createForm.addEventListener('submit', onCreate);
editForm.addEventListener('submit', onEditSubmit);

loadBook.addEventListener('click', loadBooks);

loadBooks();

async function loadBooks() {
    const url = `http://localhost:3030/jsonstore/collections/books`;
    const books = await request(url);

    const result = Object.entries(books).map(([id, book]) => createRow(id, book));

    booksList.replaceChildren(...result);

    console.log('here');
}

async function loadBookById(id) {
    const url = `http://localhost:3030/jsonstore/collections/books/${id}`;
    const book = await request(url);

    return book;
}

async function createBook(book) {
    const url = `http://localhost:3030/jsonstore/collections/books`;
    const options = {
        method: 'POST',
        body: JSON.stringify(book)
    };

    const result = await request(url, options);

    return result;
}

async function updateBook(id, book) {
    const url = `http://localhost:3030/jsonstore/collections/books/${id}`;
    const options = {
        method: 'PUT',
        body: JSON.stringify(book)
    };

    const result = await request(url, options);

    return result;
}

async function deleteBook(id) {
    const url = `http://localhost:3030/jsonstore/collections/books/${id}`;
    const result = await request(url, { method: 'DELETE' });

    return result;
}

async function onCreate(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);

    const author = formData.get('author');
    const title = formData.get('title');

    const result = await createBook({ author, title });

    booksList.appendChild(createRow(result._id, result));

    ev.target.reset();
}

async function onTableClick(ev) {
    if (ev.target.className == 'delete') {
        onDelete(ev.target);
    } else if (ev.target.className == 'edit') {
        onEdit(ev.target);
    }
}

async function onDelete(button) {
    const id = button.parentElement.dataset.id;

    await deleteBook(id);

    button.parentElement.parentElement.remove();
}

async function onEdit(button) {
    const id = button.parentElement.dataset.id;
    const book = await loadBookById(id);

    createForm.style.display = 'none';
    editForm.style.display = 'block';

    editForm.querySelector('[name="id"]').value = id;
    editForm.querySelector('[name="author"]').value = book.author;
    editForm.querySelector('[name="title"]').value = book.title;
}

async function onEditSubmit(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);

    const id = formData.get('id');
    const author = formData.get('author');
    const title = formData.get('title');

    await updateBook(id, { author, title });

    createForm.style.display = 'block';
    editForm.style.display = 'none';

    ev.target.reset();
    loadBooks();
}

function createRow(id, book) {
    const deleteBtn = e('button', { className: 'delete' }, 'Delete');
    const editBtn = e('button', { className: 'edit' }, 'Edit');

    const tdElement = e('td', {});
    tdElement.setAttribute('data-id', id);
    tdElement.appendChild(editBtn);
    tdElement.appendChild(deleteBtn);

    const row =
        e('tr', {},
            e('td', {}, book.title),
            e('td', {}, book.author),
            tdElement);

    return row;
}

async function request(url, options) {

    if (options && options.body != undefined) {
        Object.assign(options, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
    }

    const response = await fetch(url, options);

    if (response.ok != true) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = await response.json();

    return data;
}

function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (let prop in attr) {
        element[prop] = attr[prop];
    }

    for (let item of content) {
        if (typeof item == 'string' || typeof item == 'number') {
            item = document.createTextNode(item);
        }
        element.appendChild(item);
    }

    return element;
}