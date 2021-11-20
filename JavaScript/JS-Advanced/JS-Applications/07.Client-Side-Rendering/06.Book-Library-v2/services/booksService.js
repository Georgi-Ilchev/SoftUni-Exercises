import { jsonRequest } from "../helpers/jsonRequest.js";

const baseUrl = 'http://localhost:3030';

async function getAllBooks() {
    const url = baseUrl + '/jsonstore/collections/books';
    const books = await jsonRequest(url);

    return books;
}

async function getBook(id) {
    const url = baseUrl + `/jsonstore/collections/books/${id}`;
    const book = await jsonRequest(url);

    return book;
}

async function createBook(book) {
    const url = baseUrl + '/jsonstore/collections/books';
    const createdBook = await jsonRequest(url, 'POST', book);

    return createdBook;
}

async function editBook(id, book) {
    const url = baseUrl + `/jsonstore/collections/books/${id}`;
    const editedBook = await jsonRequest(url, 'PUT', book);

    return editedBook;
}

async function deleteBook(id) {
    const url = baseUrl + `/jsonstore/collections/books/${id}`;
    const deleteBook = await jsonRequest(url, 'DELETE');

    return deleteBook;
}

const booksService = {
    getAllBooks,
    getBook,
    createBook,
    editBook,
    deleteBook
}

export default booksService;