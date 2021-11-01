function attachEvents() {
    //button with class 'add'
    const addBtn = document.querySelector('button.add');
    const loadBtn = document.querySelector('button.load');

    const catchesDiv = document.getElementById('catches');

    const baseUrl = `https://fisher-game.firebaseio.com/catches.json`;
    const deleteBaseUrl = `https://fisher-game.firebaseio.com/catches/`;

    addBtn.addEventListener('click', () => {
        let angler = document.querySelector('fieldset > input.angler').value;
        let weight = document.querySelector('fieldset > input.weight').value;
        let species = document.querySelector('fieldset > input.species').value;
        let location = document.querySelector('fieldset > input.location').value;
        let bait = document.querySelector('fieldset > input.bait').value;
        let captureTime = document.querySelector('fieldset > input.captureTime').value;

        let obj = JSON.stringify({
            angler,
            weight,
            species,
            location,
            bait,
            captureTime
        });

        fetch(baseUrl, {
            method: 'POST',
            body: obj,
        })
            .then(res => res.json())
            .then(data => console.log(data))
    });

    loadBtn.addEventListener('click', () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                Object.keys(data).forEach((key) => appendCatch(key, data));
            });
    });

    function appendCatch(key, data) {
        let { angler, weight, species, location, bait, captureTime } = data[key];
        let catchDiv = e("div", "catch", "");
        catchDiv.setAttribute("data-id", key);

        let anglerLabel = e("label", "", "Angler");
        let anglerInput = e("input", "angler", angler, "text");

        let weightLabel = e("label", "", "Weight");
        let weightInput = e("input", "weight", weight, "number");

        let speciesLabel = e("label", "", "Species");
        let speciesInput = e("input", "species", species, "text");

        let locationLabel = e("label", "", "Location");
        let locationInput = e("input", "location", location, "text");

        let baitLabel = e("label", "", "Bait");
        let baitInput = e("input", "bait", bait, "text");

        let captureTimeLabel = e("label", "", "Capture Time");
        let captureTimeInput = e("input", "captureTime", captureTime, "number");

        let updateBtn = e("button", "update", "Update");
        updateBtn.addEventListener('click', () => {
            let obj = JSON.stringify({
                angler: anglerInput.value,
                weight: weightInput.value,
                species: speciesInput.value,
                location: locationInput.value,
                bait: baitInput.value,
                captureTime: captureTimeInput.value,
            });

            let updateUrl = deleteBaseUrl + key + ".json";
            fetch(updateUrl, { method: "PUT", body: obj });
        });

        let deleteBtn = e("button", "delete", "Delete");
        deleteBtn.addEventListener('click', () => {
            let deleteUrl = deleteBaseUrl + key + ".json";
            fetch(deleteUrl, { method: "DELETE" });
        });

        catchDiv.appendChild(anglerLabel);
        catchDiv.appendChild(anglerInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(weightLabel);
        catchDiv.appendChild(weightInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(speciesLabel);
        catchDiv.appendChild(speciesInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(locationLabel);
        catchDiv.appendChild(locationInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(baitLabel);
        catchDiv.appendChild(baitInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(captureTimeLabel);
        catchDiv.appendChild(captureTimeInput);
        catchDiv.appendChild(document.createElement("hr"));
        catchDiv.appendChild(updateBtn);
        catchDiv.appendChild(deleteBtn);

        catchesDiv.appendChild(catchDiv);
    }

    function e(el, classes, content, type) {
        let element = document.createElement(el);

        if (el === 'input') {
            element.type = type;
            element.value = content;
        } else {
            element.innerHTML = content;
        }

        element.className = classes;

        return element;
    }
}

attachEvents();

