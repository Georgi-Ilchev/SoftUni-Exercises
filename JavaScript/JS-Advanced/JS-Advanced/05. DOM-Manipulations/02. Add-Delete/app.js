function addItem() {
    let inputElement = document.getElementById('newText');
    let content = inputElement.value;
    if (content.length === 0) {
        return;
    }

    inputElement.value = '';

    let item = document.createElement('li');
    item.textContent = content + ' ';

    let deleteLink = document.createElement('a');
    deleteLink.href = '#';
    deleteLink.textContent = '[Delete]';
    deleteLink.addEventListener('click', deleteItem);

    item.appendChild(deleteLink);
    let unorderedList = document.getElementById('items');
    unorderedList.appendChild(item);

    function deleteItem() {
        let itemToDelete = this.parentElement;
        itemToDelete.parentElement.removeChild(itemToDelete);
    }
}