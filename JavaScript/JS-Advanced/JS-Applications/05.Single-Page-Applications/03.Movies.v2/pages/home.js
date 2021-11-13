import { jsonRequest } from "../helpers/request.js";
import viewFinder from "../src/viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView() {
    const url = `http://localhost:3030/data/movies`;
    const movies = await jsonRequest(url);
    console.log(movies);

    let moviesHTML = movies.map(m => createHtmlMovie(m)).join('\n');
    let movieContainer = section.querySelector('#movie-container');
    movieContainer.querySelectorAll('.movie').forEach(el => el.remove());
    movieContainer.innerHTML = moviesHTML;
    movieContainer.querySelectorAll('.link').forEach(l => l.addEventListener('click', viewFinder.changeViewHandler));
    
    return section;
}

let homePage = {
    initialize,
    getView
};

function createHtmlMovie(movie) {
    let element = `<div class="card mb-4 movie">
    <img class="card-img-top" src="${movie.img}"
        alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a class="link" data-route="movie-details" data-id="${movie._id}" href="#/details/6lOxMFSMkML09wux6sAF">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>
</div>`;

    return element;
}

export default homePage;