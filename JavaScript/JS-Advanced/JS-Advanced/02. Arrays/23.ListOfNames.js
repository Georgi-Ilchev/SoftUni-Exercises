function listOfNames(array) {
    let index = 1;
    array.sort((a, b) => a.localeCompare(b));

    for (const name of array) {
        console.log(`${index}.${name}`);
        index++;
    }
}