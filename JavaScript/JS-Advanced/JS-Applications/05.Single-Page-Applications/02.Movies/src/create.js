import { showDetails } from "./details.js";
import { showView } from "./dom.js";

const section = document.getElementById('add-movie'); // -> 72 row

const form = section.querySelector('form');
form.addEventListener('submit', onCreate);

section.remove();

async function onCreate(ev) {
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

    const userData = JSON.parse(sessionStorage.getItem('userData'));
    try {
        console.log('here');
        const response = await fetch('http://localhost:3030/data/movies', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.token
            },
            body: JSON.stringify(movieData)
        })

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const movie = await response.json();
        form.reset();
        showDetails(movie._id);
    } catch (err) {
        alert(err.message);
    }
}

export function showCreate() {
    showView(section);
}