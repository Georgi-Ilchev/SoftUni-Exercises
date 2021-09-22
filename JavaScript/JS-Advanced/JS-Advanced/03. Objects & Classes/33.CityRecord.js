function cityRecord(citysName, population, treasury) {
    const town = {};

    town.name = citysName;
    town.population = population;
    town.treasury = treasury;

    return town;
}

function cityRecord2(citysName, population, treasury) {
    let town = {
        name: citysName,
        population: population,
        treasury: treasury,
    };

    return town;
}

cityRecord('Tortuga',
    7000,
    15000)