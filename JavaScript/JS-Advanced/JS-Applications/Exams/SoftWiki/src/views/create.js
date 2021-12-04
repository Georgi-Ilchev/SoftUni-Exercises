import { createResource } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const createTemplate = (onSubmit) => html`
<section id="create-page" class="content">
    <h1>Create Article</h1>
    <form @submit=${onSubmit} id="create" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="create-title">Title:</label>
                <input type="text" id="create-title" name="title" placeholder="Enter article title">
            </p>
            <p class="field category">
                <label for="create-category">Category:</label>
                <input type="text" id="create-category" name="category" placeholder="Enter article category">
            </p>
            <p class="field">
                <label for="create-content">Content:</label>
                <textarea name="content" id="create-content"></textarea>
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Create">
            </p>
        </fieldset>
    </form>
</section>`;

export async function createPage(ctx) {
    const userData = getUserData();
    if (!userData) {
        ctx.page.redirect('/login');
    }

    ctx.render(createTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const categories = [
            'JavaScript',
            'C#',
            'Java',
            'Python',
        ];

        const formData = new FormData(ev.target);
        const title = formData.get('title').trim();
        const category = formData.get('category').trim();
        const content = formData.get('content').trim();

        if (title == '' || category == '' || content == '') {
            return alert('All fields are required!');
        }

        if (!categories.includes(category)) {
            return alert('This category doesn\'t exist!')
        }

        await createResource({
            title, category, content
        });

        ctx.page.redirect('/');
    }
}