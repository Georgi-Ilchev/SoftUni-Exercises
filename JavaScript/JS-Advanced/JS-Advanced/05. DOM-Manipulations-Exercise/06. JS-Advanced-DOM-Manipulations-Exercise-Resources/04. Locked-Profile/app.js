function lockedProfile() {
    //array.from -> for judge
    Array.from(document.getElementsByClassName('profile')).forEach(parent => {
 // [...document.getElementsByClassName('profile')].forEach(parent => {
        let button = parent.querySelectorAll('button')[0];

        button.addEventListener('click', () => {
            let unlock = parent.querySelectorAll('input')[1].checked;
            let hiddenDiv = parent.querySelectorAll('div')[0];

            if (unlock) {
                if (button.textContent == 'Show more') {
                    hiddenDiv.style.display = 'block';
                    button.textContent = 'Hide it';
                } else if (button.textContent == 'Hide it') {
                    hiddenDiv.style.display = 'none';
                    button.textContent = 'Show more';
                }
            }
        })
    });
}