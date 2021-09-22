function population(townsAsString) {
    const towns = {};

    for (const data of townsAsString) {
        const tokens = data.split(' <-> ');

        const name = tokens[0];
        let population = Number(tokens[1]);

        //1
        // if (towns[name] == undefined) {
        //     towns[name] = population;
        // } else {
        //     towns[name] += population;
        // }

        //2
        if (towns[name]) {
            population += towns[name];
        }
        towns[name] = population;
    }

    //1
    // for (const town in towns) {
    //     console.log(`${town} : ${towns[town]}`);
    // }

    //2
    for (const [name, population] of Object.entries(towns)) {
        console.log(`${name} : ${population}`);
    }
}

population(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'])