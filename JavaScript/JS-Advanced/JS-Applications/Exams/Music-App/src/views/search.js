import { html } from '../lib.js';
import { searchAlbum } from '../api/data.js';
import { getUserData } from '../util.js';

const searchTemplate = (albums, search, params = '', showDetailsBtn) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name" .value=${params}>
        <button @click=${search} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>

    <!--Show after click Search button-->
    <div class="search-result">
        ${albums.length == 0
            ? html`<p class="no-result">No result.</p>`
            : html`${albums.map(a => albumTemplate(a, showDetailsBtn))}`}
    </div>
</section>`;

const albumTemplate = (album, showDetailsBtn) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: ${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${showDetailsBtn 
            ? html`
                <div class="btn-group">
                    <a href="/details/${album._id}" id="details">Details</a>
                </div>` 
            : null}
    </div>
</div>`;

export async function searchPage(ctx) {
    const params = ctx.querystring.split('=')[1];
    const userData = await getUserData();
    let showDetailsBtn = userData ? true : false;
    let albums = [];

    if (params) {
        albums = await searchAlbum(decodeURIComponent(params));
    }

    ctx.render(searchTemplate(albums, search, params, showDetailsBtn));

    function search(ev) {
        ev.preventDefault();
        const name = document.getElementById('search-input').value;

        if (name) {
            ctx.page.redirect('/search?query=' + encodeURIComponent(name));
        }
    }

}