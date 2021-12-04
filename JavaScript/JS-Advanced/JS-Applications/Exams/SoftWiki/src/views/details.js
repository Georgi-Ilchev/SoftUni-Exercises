import { deleteResource, getResourceById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (resource, isOwner, onDelete) => html`
<section id="details-page" class="content details">
    <h1>${resource.title}</h1>
    <div class="details-content">
        <strong>Published in category ${resource.category}</strong>
        <p>${resource.content}</p>
        <div class="buttons">
            ${isOwner ? html`
            <a @click=${onDelete} href="javascript:void(0)" class="btn delete">Delete</a>
            <a href="/edit/${resource._id}" class="btn edit">Edit</a>` : null}
            <a href="/" class="btn edit">Back</a>
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const resource = await getResourceById(ctx.params.id);
    const userData = getUserData();
    const isOwner = userData && resource._ownerId == userData.id;

    ctx.render(detailsTemplate(resource, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete ${resource.title}?`);

        if (choice) {
            await deleteResource(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}