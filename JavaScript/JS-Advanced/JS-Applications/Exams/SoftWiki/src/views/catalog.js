import { getCatalog } from '../api/data.js';
import { html } from '../lib.js';

const catalogTemplate = (resources) => html`
<section id="catalog-page" class="content catalogue">
    <h1>All Articles</h1>
    ${resources.length == 0 
        ? html`<h3 class="no-articles">No articles yet</h3>` 
        : html`${resources.map(resourceTemplate)}`}
</section>`;

const resourceTemplate = (resource) => html`
<a class="article-preview" href="/details/${resource._id}">
    <article>
        <h3>Topic: <span>${resource.title}</span></h3>
        <p>Category: <span>${resource.category}</span></p>
    </article>
</a>`;

export async function catalogPage(ctx) {
    const resources = await getCatalog();
    ctx.render(catalogTemplate(resources));
}