import auth from "../helpers/auth.js";
import { jsonRequest } from "../helpers/request.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView(id) {
    let movieDetail = await jsonRequest(`http://localhost:3030/data/movies/${id}`);

    let movieContainer = section.querySelector('#movie-details-container');
    [...movieContainer.children].forEach(x => x.remove());
    let movieDetails = createMovieDetails(movieDetail);
    movieContainer.innerHTML = movieDetails;

    return section;
}

function createMovieDetails(movie) {
    let deleteBtn = `<a class="btn btn-danger link" data-route="delete" data-id="${movie._id}" href="#">Delete</a>`;
    let editBtn = `<a class="btn btn-warning link" data-route="edit" data-id="${movie._id}" href="#">Edit</a>`;
    let likeBtn = `<a class="btn btn-primary link" data-route="like" data-id="${movie._id}" href="#">Like</a>`;

    let buttons = [];
    if (auth.getUserId() === movie._ownerId) {
        buttons.push(deleteBtn, editBtn);
    } else {
        buttons.push(likeBtn);
    }

    let buttonsSection = buttons.join('\n');

    let elem = `<div class="row bg-light text-dark">
    <h1>Movie title: ${movie.title}</h1>

    <div class="col-md-8">
        <img class="img-thumbnail"
            src="${movie.img}" alt="Movie">
    </div>
    <div class="col-md-4 text-center">
        <h3 class="my-3 ">Movie Description</h3>
        <p>${movie.description}</p>
        ${buttonsSection}
        <span class="enrolled-span">Liked 1</span>
    </div>
</div>`;

    return elem;
}

let movieDetailsPage = {
    initialize,
    getView
};

export default movieDetailsPage;