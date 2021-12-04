import { searchResource } from '../api/data.js';
import { html } from '../lib.js';

const searchTemplate = (resources, search, params = '') => html`
<section id="search-page" class="content">
    <h1>Search</h1>
    <form @sumbmit=${search} id="search-form">
        <p class="field search">
            <input id="search-input" type="text" placeholder="Search by article title" name="search" .value=${params} }>
        </p>
        <p class="field submit">
            <input class="btn submit" type="submit" value="Search">
        </p>
    </form>
    <div class="search-container">
        ${resources.length == 0 
            ? html`<h3 class="no-articles">No matching articles</h3>` 
            : html`${resources.map(resourceTemplate)}`}
    </div>
</section>`;

const resourceTemplate = (resource) => html`
<a class="article-preview" href="/details/${resource._id}">
    <article>
        <h3>Topic: <span>${resource.title}</span></h3>
        <p>Category: <span>${resource.category}</span></p>
    </article>
</a>`;

export async function searchPage(ctx) {
    const params = ctx.querystring.split('=')[1];
    let resources = [];

    if (params) {
        resources = await searchResource(decodeURIComponent(params));
    }

    ctx.render(searchTemplate(resources, search, params));

    function search(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const title = formData.get('search').trim();

        if (title) {
            ctx.page.redirect('/search?query=' + encodeURIComponent(title));
        }
    }
}