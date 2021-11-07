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


//////////////////////////////////



async function lockedProfile() {
    let mainId = document.getElementById('main');

    let url = `http://localhost:3030/jsonstore/advanced/profiles`;
    let res = await fetch(url);
    let data = await res.json();

    let profiles = Object.values(data);

    mainId.replaceChildren();
    profiles.forEach(p => {
        let div = document.createElement('div');
        div.classList.add('profile');
        div.innerHTML = `
        <img src="./iconProfile2.png" class="userIcon" />
				<label>Lock</label>
				<input type="radio" name="user1Locked" value="lock" checked>
				<label>Unlock</label>
				<input type="radio" name="user1Locked" value="unlock"><br>
				<hr>
				<label>Username</label>
				<input type="text" name="user1Username" value="${p.username}" disabled readonly />
				<div class="hiddenInfo">
					<hr>
					<label>Email:</label>
					<input type="email" name="user1Email" value="${p.email}" disabled readonly />
					<label>Age:</label>
					<input type="email" name="user1Age" value="${p.age}" disabled readonly />
				</div>
				
				<button>Show more</button>`;

        mainId.appendChild(div);

    })

    Array.from(document.querySelectorAll('.profile button'))
        .forEach(b => b.addEventListener('click', onClick));

    function onClick(ev) {
        let hidden = ev.target.parentElement.querySelector('.profile div');
        let button = ev.target.parentElement.querySelector('button');

        var isCheck = ev.target.parentElement.querySelector('input[type="radio"][value="unlock"]').checked;
        if (isCheck) {
            if (button.textContent == 'Show more') {
                hidden.classList.remove("hiddenInfo");
                button.textContent = 'Show less'
            } else if (button.textContent == 'Show less') {
                hidden.classList.add("hiddenInfo");
                button.textContent = 'Show more'
            }
        }

    }
}