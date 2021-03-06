function solve() {
    let result = [];
    let counter = {};

    [...arguments].forEach(argument => {
        let type = typeof argument;

        result.push({ type, value: argument });

        if (!counter[type]) {
            counter[type] = 0;
        }
        counter[type]++;
    })

    result.forEach(r => console.log(`${r.type}: ${r.value}`));

    let sort = Object.entries(counter).sort((a, b) => b[1] - a[1]);

    sort.forEach(element => {
        console.log(`${element[0]} = ${element[1]}`);
    })
}

solve('cat', 42, function () { console.log('Hello world!'); })




function solve() {
    let counter = {};

    [...arguments].forEach(argument => {
        let result = '';

        typeof argument === 'function' ? result = `${typeof argument}: ${argument.toString()}`
            : result = `${typeof argument}: ${argument}`;

        console.log(result);

        if (!counter[typeof argument]) {
            counter[typeof argument] = {
                count: 0
            };
        }
        counter[typeof argument].count++;
    })

    let sorted = Object.keys(counter).sort((a, b) => counter[b].count - counter[a].count);

    sorted.forEach(element => {
        console.log(`${element} = ${counter[element].count}`)
    });
}

solve('cat', 42, function () { console.log('Hello world!'); })