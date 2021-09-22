function townsToJson(array) {
    const result = [];
    const splitted = array[0].split("|");

    const town = splitted[1].trim();
    const latitude = splitted[2].trim();
    const longitude = splitted[3].trim();

    for (let i = 1; i < array.length; i++) {
        const obj = {};
        const splittedEntry = array[i].split("|");

        obj[town] = splittedEntry[1].trim();
        obj[latitude] = Number(Number(splittedEntry[2].trim()).toFixed(2));
        obj[longitude] = Number(Number(splittedEntry[3].trim()).toFixed(2));

        result.push(obj);
    }

    console.log(JSON.stringify(result));
}

townsToJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])