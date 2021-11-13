import { showCreate } from "./create.js";
import { showDetails } from "./details.js";
import { e, showView } from "./dom.js";

const section = document.getElementById('home-page'); // -> 46 row
const catalog = section.querySelector('.card-deck.d-flex.justify-content-center'); // -> 64 row
section.querySelector('#createLink').addEventListener('click', (ev) => {
    ev.preventDefault();
    showCreate();
});
catalog.addEventListener('click', (ev) => {
    ev.preventDefault();
    let target = ev.target;

    if (target.tagName == 'BUTTON') {
        target = target.parentElement;
    }

    if (target.tagName == 'A') {
        const id = target.dataset.id;
        showDetails(id);
        // console.log(id);
    }
});

section.remove();

export function showHome() {
    showView(section);
    getMovies();
}

async function getMovies() {
    catalog.replaceChildren(e('p', {}, 'Loading...'));

    const response = await fetch('http://localhost:3030/data/movies');
    const data = await response.json();

    catalog.replaceChildren(...data.map(createMovieCard));
}

function createMovieCard(movie) {
    const element = e('div', { className: 'card mb-4' });
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
        alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a data-id=${movie._id} href="#">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>`;

    return element;

    // /details/6lOxMFSMkML09wux6sAF
}