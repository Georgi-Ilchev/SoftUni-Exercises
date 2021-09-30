function deleteByEmail() {
    const input = document.querySelector('input[name="email"]');

    const rows = Array.from(document.querySelector('tbody').children);

    let result = document.getElementById('result');

    let removed = false;

    for (const row of rows) {
        if (row.children[1].textContent == input.value) {
            row.remove();
            removed = true;
        }
    }

    if (removed) {
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}


function deleteByEmail() {
    const input = document.querySelector('input[name="email"]');

    const rows = Array.from(document.querySelector('tbody').children)
        .filter(r => r.children[1].textContent == input.value);

    rows.forEach(r => r.remove());

    let result = document.getElementById('result');
    result.textContent = rows.length > 0 ? 'Deleted.' : 'Not found.';
}