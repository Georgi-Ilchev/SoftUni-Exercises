function solve(input) {

    input.sort((current, next) => {
        if (current.length > next.length) {
            return 1;
        } else if (current.length === next.length) {
            return current.localeCompare(next);
        } else {
            return -1;
        }
    }).forEach(e => console.log(e));
};

solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve(['test', 'Deny', 'omen', 'Default']);


function solve1(input) {
    let output = (current, next) => current.length - next.length || current.localeCompare(next);
    input.sort(output);

    console.log(input.join('\n'));
};

solve1(['alpha', 'beta', 'gamma']);
solve1(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve1(['test', 'Deny', 'omen', 'Default']);