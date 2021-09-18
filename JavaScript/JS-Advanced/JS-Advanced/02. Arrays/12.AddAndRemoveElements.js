function solve(input) {
    let output = [];
    let count = 1;

    input.forEach((command) => {
        if (command === 'add') {
            output.push(count);
        } else {
            output.pop();
        }
        count++;
    });

    output.length == 0 ? console.log('Empty') : console.log(output.join('\n').trim());
};

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);

function solve1(input) {
    let output = [];
    let count = 1;

    input.map(command => {
        command === 'remove' ? output.pop() : output.push(count);
        count++;
    })

    output.length == 0 ? console.log('Empty') : console.log(output.join('\n').trim());
};

solve1(['add', 'add', 'add', 'add']);
solve1(['add', 'add', 'remove', 'add', 'add']);
solve1(['remove', 'remove', 'remove']);

function addOrRemoveElements(commands) {
    let result = [];
    let initialNumber = 1;

    for (const command of commands) {
        if (command == 'add') {
            result.push(initialNumber);
        } else {
            result.pop(initialNumber);
        }
        initialNumber++;
    }

    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n').trim());
    }
}