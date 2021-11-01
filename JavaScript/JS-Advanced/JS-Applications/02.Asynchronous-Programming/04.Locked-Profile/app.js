function lockedProfile() {
    const main = document.getElementById('main');
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;

    fetch(url)
        .then(res => res.json())
        .then(data => {
            Object.entries(data).forEach(([element, value]) => {
                let divElement = document.createElement('div');
                divElement.classList.add('profile');
                divElement.innerHTML = createProfile(value.username, value.email, value.age);

                main.appendChild(divElement);
            });
        });

    main.addEventListener('click', (ev) => {
        if (ev.target.textContent === 'Show more' ||
            ev.target.textContent === 'Hide it') {
            let lock = ev.target.parentElement.querySelector('input[value="lock"]');
            let hiddenDiv = ev.target.previousElementSibling;

            if (hiddenDiv.style.display == '' && lock.checked === false) {
                hiddenDiv.style.display = 'block';
                ev.target.textContent = 'Hide it';
            } else if (hiddenDiv.style.display == 'block' && lock.checked === false) {
                hiddenDiv.style.display = '';
                ev.target.textContent = 'Show more';
            }
        }
    });


    function createProfile(username, email, age) {
        let template =
            `
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user1Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user1Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user1Username" value="${username}" disabled readonly />
            <div id="user1HiddenFields">
                <hr>
                <label>Email:</label>
                <input type="email" name="user1Email" value="${email}" disabled readonly />
                <label>Age:</label>
                <input type="email" name="user1Age" value="${age}" disabled readonly />
            </div>
            <button>Show more</button>
        `;

        return template;
    }
}