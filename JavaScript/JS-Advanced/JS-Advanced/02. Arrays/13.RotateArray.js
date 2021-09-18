function solve(input) {
    let rotationsCount = input.pop();

    for (let index = 0; index < rotationsCount % input.length; index++) {
        let lastElement = input.pop();
        input.unshift(lastElement);
    }

    console.log(input.join(' '));
};
solve(['1', '2', '3', '4', '2']);
solve1(['Banana', 'Orange', 'Coconut', 'Apple', '15']);

function rotateArray(array, rotations) {
    for (let i = 0; i < rotations % array.length; i++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}