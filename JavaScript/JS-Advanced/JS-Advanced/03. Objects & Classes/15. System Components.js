function solve(input) {
    let result = {};

    input.forEach(line => {
        let [systemName, component, subComponent] = line.split(' | ');

        if (!result[systemName]) {
            result[systemName] = {};
        }

        if (!result[systemName][component]) {
            result[systemName][component] = [];
        }

        result[systemName][component].push(subComponent);
    })

    Object.entries(result).sort((curr, next) => {
        return Object.entries(next[1]).length - Object.entries(curr[1]).length || curr[0].localeCompare(next[0]);
    }).forEach(([system, components]) => {
        console.log(system);
        Object.entries(components).sort((curr, next) => {
            return next[1].length - curr[1].length;
        }).forEach(([component, subComponents]) => {
            console.log(`|||${component}`);
            subComponents.forEach(sub => {
                console.log(`||||||${sub}`);
            })
        })
    })
}

solve([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);




function solve1(input) {
    let result = input.reduce((acc, line) => {
        let [systemName, component, subComponent] = line.split(' | ');

        if (!acc[systemName]) {
            acc[systemName] = {};
        }

        if (!acc[systemName][component]) {
            acc[systemName][component] = [];
        }

        acc[systemName][component].push(subComponent);
        return acc;
    }, {})

    Object.entries(result).sort((curr, next) => {
        return Object.entries(next[1]).length - Object.entries(curr[1]).length || curr[0].localeCompare(next[0]);
    }).forEach(([system, components]) => {
        console.log(system);
        Object.entries(components).sort((curr, next) => {
            return next[1].length - curr[1].length;
        }).forEach(([component, subComponents]) => {
            console.log(`|||${component}`);
            subComponents.forEach(sub => {
                console.log(`||||||${sub}`);
            })
        })
    })
}
solve1([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);



function solve2(input) {
    let result = {};

    input.forEach(line => {
        let [systemName, component, subComponent] = line.split(' | ');

        if (!result[systemName]) {
            result[systemName] = {};
        }

        if (!result[systemName][component]) {
            result[systemName][component] = [];
        }

        result[systemName][component].push(subComponent);
    })

    let sortedSystem = Object.keys(result).sort((a, b) =>
        Object.keys(result[b]).length - Object.keys(result[a]).length ||
        a.localeCompare(b));

    for (const system of sortedSystem) {
        console.log(system);

        const sortedComponents = Object.keys(result[system]).sort((a, b) =>
            result[system][b].length - result[system][a].length);

        for (const component of sortedComponents) {
            console.log(`|||${component}`);
            result[system][component].forEach(x => console.log(`||||||${x}`));
        }
    }
}
solve2([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);