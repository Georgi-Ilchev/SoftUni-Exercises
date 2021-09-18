function solve(input) {
    let delimiter = input.pop();

    console.log(input.join(delimiter));
};

// solve(['One', 'Two', 'Three', 'Four', 'Five', '-']);
// solve(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);

function arrayWithDelimiter(array, delimiter) {
    console.log(array.join(delimiter));
}

arrayWithDelimiter(['One', 'Two', 'Three', 'Four', 'Five'], '-');