function addItem() {
    const itemText = document.getElementById('newItemText');
    const itemValue = document.getElementById('newItemValue');
    const options = document.getElementById('menu');
    let option = document.createElement('option');

    option.textContent = itemText.value;
    option.value = itemValue.value;

    options.appendChild(option);

    itemText.value = '';
    itemValue.value = '';
}