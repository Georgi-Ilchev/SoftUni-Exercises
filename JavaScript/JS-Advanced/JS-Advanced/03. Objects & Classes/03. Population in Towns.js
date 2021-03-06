function solve(input) {
    let result = input.map(x => x.split(' <-> '))   /*   cast to number =>    .map(x => [x[0], Number(x[1])]);    */
        .reduce(
            (a, x) => {
                let currentTown = x[0];
                let currentPopulation = Number(x[1]);

                if (!a.hasOwnProperty(currentTown)) {                     /*    or        if (a[x[0]])   */
                    a[currentTown] = 0;
                }

                a[currentTown] += currentPopulation;

                return a;
            },
            {}
        );

    //1
    // for (const town in result) {
    //     console.log(town + ' : ' + result[town]);
    // }

    //2
    Object.keys(result).forEach(town => console.log(`${town} : ${result[town]}`));
};

solve(
    ['Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000']
);
solve(
    ['Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000']
);


//with for
function solve1(input) {
    let result = input.map(x => x.split(' <-> '));
    let final = {};

    for (let i = 0; i < result.length; i++) {
        let currentTown = result[i][0];
        let currentPopulation = Number(result[i][1]);
        if (!final[currentTown]) {
            final[currentTown] = 0;
        }
        final[currentTown] += currentPopulation;
    }

    for (const town in final) {
        console.log(town + ' : ' + final[town]);
    }
};
solve1(
    ['Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000']
);
solve1(
    ['Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000']
);