function generateReport() {
    let checkBox = document.querySelectorAll('table>thead>tr>th>input');
    let rows = document.querySelectorAll('tbody>tr');
    let result = [];

    for (let i = 0; i < rows.length; i++) {
        let obj = {};
        let values = Array.from(rows[i].getElementsByTagName('td')).map(el => el.textContent);

        for (let j = 0; j < checkBox.length; j++) {
            if (checkBox[j].checked) {
                obj[checkBox[j].name] = values[j];
            }
        }

        result.push(obj);
    }

    document.querySelector('#output').value = JSON.stringify(result, null, 2);
}