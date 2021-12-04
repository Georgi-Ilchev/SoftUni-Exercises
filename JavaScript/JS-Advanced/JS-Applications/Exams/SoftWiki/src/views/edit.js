import { editResource, getResourceById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const editTemplate = (resource, onSubmit) => html`
<section id="edit-page" class="content">
    <h1>Edit Article</h1>
    <form @submit=${onSubmit} id="edit" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="title">Title:</label>
                <input type="text" name="title" id="title" placeholder="Enter article title" .value=${resource.title} />
            </p>
            <p class="field category">
                <label for="category">Category:</label>
                <input type="text" name="category" id="category" placeholder="Enter article category"
                    .value=${resource.category} />
            </p>
            <p class="field">
                <label for="content">Content:</label>
                <textarea name="content" id="content" .value=${resource.content}></textarea>
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Save Changes">
            </p>
        </fieldset>
    </form>
</section>`;

export async function editPage(ctx) {
    const resource = await getResourceById(ctx.params.id);
    const userData = getUserData();

    if (resource._ownerId != userData.id) {
        ctx.page.redirect('/');
        return;
    }

    ctx.render(editTemplate(resource, onSubmit));

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

        await editResource(resource._id, {
            title, category, content
        });

        ctx.page.redirect('/details/' + resource._id);
    }
}