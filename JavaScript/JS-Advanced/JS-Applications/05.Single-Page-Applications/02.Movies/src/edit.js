import { showDetails } from "./details.js";
import { showView } from "./dom.js";

const section = document.getElementById('edit-movie'); // -> 96 row

let movieId = null;
export function showEdit(id) {
    movieId = id;
    onEdit(id);
    showView(section);
}

const userData = JSON.parse(sessionStorage.getItem('userData'));
let form = section.querySelector('form');
form.addEventListener('submit', onEditSubmit);
section.remove();


async function onEdit(movieId) {
    const movie = await loadMovie(movieId);

    form.querySelector('[name="title"').value = movie.title;
    form.querySelector('[name="description"').value = movie.description;
    form.querySelector('[name="imageUrl"').value = movie.img;
}

async function onEditSubmit(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);

    const movieData = {
        title: formData.get('title').trim(),
        description: formData.get('description').trim(),
        img: formData.get('imageUrl').trim()
    };

    if (movieData.title == '' || movieData.description == '' || movieData.img == '') {
        return alert('All fields are required!');
    }

    await updateMovie(movieData, movieId);
    showDetails(movieId);
}

async function loadMovie(movieId) {
    const url = `http://localhost:3030/data/movies/` + movieId;
    const response = await fetch(url);
    const data = response.json();
    return data;
}

async function updateMovie(data, id) {
    console.log('updating movie');
    const response = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userData.token
        },
        body: JSON.stringify(data)
    })

    return await response.json()
}