import { createBook, html } from './api.js';

const createTemplate = (onSuccess) => html`
<form @submit=${ev => onSubmit(ev, onSuccess)} id="add-form">
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit">
</form>`;

async function onSubmit(ev, onSuccess) {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    if (title == '' || author == '') {
        return alert('The fields must not be empty!');
    }

    await createBook({ title, author });
    ev.target.reset();
    onSuccess();
}

export function showCreate(ctx) {
    if (ctx.book === undefined) {
        return createTemplate(ctx.update);
    } else {
        return null;
    }
}