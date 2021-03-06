function addItem() {
    let listElements = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');

    let liElement = document.createElement('li');

    liElement.innerHTML = inputElement.value;
    listElements.appendChild(liElement);

    inputElement.value = '';
}