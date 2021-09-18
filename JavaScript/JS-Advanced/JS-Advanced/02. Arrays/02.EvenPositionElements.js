function solve(input) {
    let result = [];

    for (let index = 0; index < input.length; index += 2) {
        result.push(input[index])

    }

    console.log(result.join(' '));
};
solve(['20', '30', '40']);
solve(['5', '10']);

function evenPosition(input){
    let result = [];

    for (let i = 0; i < input.length; i+= 2) {
        result.push(input[i]);
    }

    console.log(result.join(' '))
}

evenPosition(['20', '30', '40', '50', '60'])