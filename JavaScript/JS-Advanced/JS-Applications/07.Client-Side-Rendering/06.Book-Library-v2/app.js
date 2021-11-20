import { render } from './node_modules/lit-html/lit-html.js';
import booksService from './services/booksService.js';
import { bookLibraryTemplate, allBooksTemplate } from './templates/bookTemplates.js';

const addForm = {
    id: 'add-form',
    type: 'add',
    title: 'Add Book',
    submitText: 'Submit',
    submitHandler: createBook
};

const editForm = {
    id: 'edit-form',
    type: 'edit',
    title: 'Edit Book',
    submitText: 'Save',
    class: 'hidden',
    submitHandler: editBook,
    idValue: '',
    authorValue: '',
    titleValue: ''
};

const root = document.body;
const forms = [addForm, editForm];
let books = [];

render(bookLibraryTemplate([], forms, loadBooks, prepareEdit), root);
const booksContainer = document.getElementById('books-container');

async function loadBooks() {
    const booksObj = await booksService.getAllBooks();
    books = Object.entries(booksObj).map(([key, val]) => {
        val._id = key;
        return val;
    });

    update();
}

async function createBook(ev) {
    ev.preventDefault();
    const form = ev.target;
    const formData = new FormData(form);
    const newBook = {
        author: formData.get('author').trim(),
        title: formData.get('title').trim()
    };

    const createResult = await booksService.createBook(newBook);
    books.push(createResult);
    form.reset();
    update();
}

async function prepareEdit(ev) {
    const book = ev.target.closest('.book');
    const id = book.dataset.id;

    const bookSource = await booksService.getBook(id);

    editForm.class = undefined;
    editForm.idValue = id;
    editForm.authorValue = bookSource.author;
    editForm.titleValue = bookSource.title;

    render(bookLibraryTemplate(books, forms, loadBooks, prepareEdit), root);
}

async function editBook(ev) {
    ev.preventDefault();
    const form = ev.target;
    const formData = new FormData(form);
    const id = formData.get('id');
    const newBook = {
        author: formData.get('author').trim(),
        title: formData.get('title').trim()
    };

    const createResult = await booksService.editBook(id, newBook);
    books = books.filter(x => x._id !== id)
    books.push(createResult);
    form.reset();
    update();
}

function update() {
    render(allBooksTemplate(books, prepareEdit), booksContainer);
}
