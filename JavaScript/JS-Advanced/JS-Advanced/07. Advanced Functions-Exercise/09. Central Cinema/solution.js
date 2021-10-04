// 20 points at judge
function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    const movieSection = document.querySelector('#movies ul');
    const archiveSection = document.querySelector('#archive ul');
    const clearButton = archiveSection.parentElement.querySelector('button');
    clearButton.addEventListener('click', clearMovies);
    const addMovieButton = document.querySelector('#container button');
    addMovieButton.addEventListener('click', addMovie);

    function addMovie(ev) {
        ev.preventDefault();
        if (name.value !== '' &&
            hall.value !== '' &&
            ticketPrice.value != '' &&
            !isNan(Number(ticketPrice.value))) {

            const movie = document.createElement('li');
            movie.innerHTML =
                `<span>${name.value}</span>
                <strong>${hall.value}</strong>
                <div>
                    <strong>${Number(ticketPrice.value).toFixed(2)}</strong>
                    <input placeholder="Tickets Sold">
                    <button>Archive</button>
                </div>`;

            movieSection.appendChild(movie);

            const button = movie.querySelector('div button');
            button.addEventListener('click', addToArchive);

            name.value = '';
            hall.value = '';
            ticketPrice.value = '';
        }
    }

    function addToArchive(ev) {
        const inputValue = ev.target.parentElement.querySelector('input');
        const ticketPrice = ev.target.parentElement.querySelector('strong');
        const movieName = ev.target.parentElement.parentElement.querySelector('span');

        if (inputValue.value != '' && !IsNan(Number(inputValue.value))) {
            const income = Number(inputValue.value) * Number(ticketPrice.textContent);

            const listElement = document.createElement('li');
            listElement.innerHTML = `<span>${movieName.textContent}</span>
                                     <strong>Total amount:${income.toFixed(2)}<strong>
                                     <button>Delete</button>`;

            const button = listElement.querySelector('button');
            button.addEventListener('click', archiveMovie);
            archiveSection.appendChild(listElement);
        }

        ev.target.parentElement.parentElement.remove();
    }

    function archiveMovie(ev) {
        ev.target.parentElement.remove();
    }

    function clearMovies(ev) {
        archiveSection.innerHTML = ''; // clear childrens
    }
}

//100 points
function solve() {
    let input = document.querySelectorAll("input");
    let sections = document.querySelectorAll("section");
    let onScreenBtn = document.querySelector("button");

    let movieSection = sections[0].children[1];
    let archiveSection = sections[1].children[1];
    let clearBtn = sections[1].children[2];

    let name = input[0];
    let hall = input[1];
    let price = input[2];

    onScreenBtn.addEventListener("click", addMove);
    clearBtn.addEventListener("click", clearMovies);

    function addMove(ev) {
        ev.preventDefault();
        if (
            name.value === "" ||
            hall.value === "" ||
            price.value === "" ||
            Number(isNaN(Number(price.value)))
        ) {
            return;
        } else {
            let li = document.createElement("li");
            let div = document.createElement("div");
            let span1 = ce("span", name.value);
            let strong1 = ce("strong", `Hall: ${hall.value}`);
            let strong2 = ce("strong", price.value);
            let input = document.createElement("input");
            input.placeholder = "Tickets Sold";
            let archiveBtn = ce("button", "Archive");
            div.appendChild(strong2);
            div.appendChild(input);
            div.appendChild(archiveBtn);
            li.appendChild(span1);
            li.appendChild(strong1);
            li.appendChild(div);
            movieSection.appendChild(li);

            name.value = "";
            hall.value = "";
            price.value = "";

            archiveBtn.addEventListener("click", function (e) {
                if (Number.isNaN(Number(input.value)) || input.value === "") {
                    return;
                } else {
                    li.removeChild(div);
                    let deleteBtn = ce("button", "Delete");
                    strong1.textContent =
                        "Total amount: " +
                        (Number(input.value) * Number(strong2.textContent)).toFixed(2);
                    li.appendChild(deleteBtn);
                    archiveSection.appendChild(li);

                    deleteBtn.addEventListener("click", function (e) {
                        let parent = e.target.parentNode.parentNode;
                        parent.removeChild(li);
                    });
                }
            });
        }
    }

    function ce(el, text, className, id) {
        let e = document.createElement(el);
        if (text) {
            e.textContent = text;
        }
        if (className) {
            e.classList = className;
        }
        if (id) {
            e.id = id;
        }
        return e;
    }

    function clearMovies(ev) {
        archiveSection.innerHTML = ''; // clear childrens
    }
}