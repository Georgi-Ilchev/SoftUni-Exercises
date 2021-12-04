import { getRecentResouce } from '../api/data.js';
import { html } from '../lib.js';

const homeTemplate = (jsResource, javaResource, cSharpResource, pyResource) => html`
<section id="home-page" class="content">
    <h1>Recent Articles</h1>
    <section class="recent js">
        <h2>JavaScript</h2>
        ${jsResource ? html`<article>
            <h3>${jsResource.title}</h3>
            <p>${jsResource.content}</p>
            <a href="/details/${jsResource._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent csharp">
        <h2>C#</h2>
        ${cSharpResource ? html`<article>
            <h3>${cSharpResource.title}</h3>
            <p>${cSharpResource.content}</p>
            <a href="/details/${cSharpResource._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent java">
        <h2>Java</h2>
        ${javaResource ? html`<article>
            <h3>${javaResource.title}</h3>
            <p>${javaResource.content}</p>
            <a href="/details/${javaResource._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent python">
        <h2>Python</h2>
        ${pyResource ? html`<article>
            <h3>${pyResource.title}</h3>
            <p>${pyResource.content}</p>
            <a href="/details/${pyResource._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
</section>`;

export async function homePage(ctx) {
    const result = await getRecentResouce();

    const js = result.find(r => r.category == 'JavaScript');
    const java = result.find(r => r.category == 'Java');
    const cSharp = result.find(r => r.category == 'C#');
    const py = result.find(r => r.category == 'Python');

    ctx.render(homeTemplate(js, java, cSharp, py));
}