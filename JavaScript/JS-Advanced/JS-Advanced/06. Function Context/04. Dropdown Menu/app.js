function solve() {
    let dropdownElement = document.getElementById('dropdown-ul');
    let dropdownButton = document.getElementById('dropdown');
    let boxElement = document.getElementById('box');

    dropdownButton.addEventListener('click', () => {
        // if (dropdownElement.style.display == 'block') {
        //     dropdownElement.style.display = 'none';
        // } else {
        //     dropdownElement.style.display = 'block';
        // }

        let currentDisplay = dropdownElement.style.display == 'block'
            ? 'none'
            : 'block';

        if (currentDisplay == 'none') {
            boxElement.style.backgroundColor = 'black';
            boxElement.style.color = 'white';
        }

        dropdownElement.style.display = currentDisplay;

    });

    dropdownElement.addEventListener('click', e => {
        let backgroundColor = e.target.textContent;
        boxElement.style.backgroundColor = backgroundColor;
        boxElement.style.color = 'black';
    });
}