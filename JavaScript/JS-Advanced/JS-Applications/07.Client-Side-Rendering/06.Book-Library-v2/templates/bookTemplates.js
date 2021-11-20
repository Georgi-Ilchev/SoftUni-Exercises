import { html } from '../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../node_modules/lit-html/directives/if-defined.js';

export let allFormsTemplate = (forms) => html`${forms.map(f => formTemplate(f))}`;

export let formTemplate = (form) => html`
<form @submit=${form.submitHandler} class="${ifDefined(form.class)}" id="${form.id}">
    ${form.type === 'edit' ? html`<input type="hidden" name="id" .value=${form.idValue}>` : ''}
    <h3>${form.title}</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." .value=${form.titleValue}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." .value=${form.authorValue}>
    <input type="submit" value=${form.submitText}>
</form>`;

export let bookTemplate = (book, editHandler) => html`
<tr class="book" data-id=${book._id}>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button class="edit" @click=${editHandler}>Edit</button>
        <button class="delete">Delete</button>
    </td>
</tr>`;

export const allBooksTemplate = (books, editHandler) => html`${books.map(b => bookTemplate(b, editHandler))}`

export const tableTemplate = (books, editHandler) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody id="books-container">
        ${allBooksTemplate(books, editHandler)}
    </tbody>
</table>`;

export const bookLibraryTemplate = (books, forms, loadBooksHandler, editHandler) => html`
<button id="loadBooks" @click=${loadBooksHandler}>LOAD ALL BOOKS</button>
${tableTemplate(books, editHandler)}
${allFormsTemplate(forms)}`;

