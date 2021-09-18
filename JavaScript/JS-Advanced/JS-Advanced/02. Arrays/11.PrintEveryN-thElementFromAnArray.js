function solve(input) {
    let step = Number(input.pop());

    input.forEach((el, i) => {
        if (i % step == 0) {
            console.log(el);
        }
    });
};

// solve(['5', '20', '31', '4', '20', '2']);
// solve(['dsa', 'asd', 'test', 'tset', '2']);
// solve(['1', '2', '3', '4', '5', '6']);

function printEveryElement(array, step) {
    let result = [];
    array.forEach((el, i) => {
        if (i % step == 0) {
            result.push(el);
        }
    });

    return(result);
}

printEveryElement(['5', '20', '31', '4', '20'], 2);