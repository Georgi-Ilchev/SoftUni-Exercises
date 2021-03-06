function solve(input) {
    let delimiter = input.pop();

    console.log(input.join(delimiter));
};

solve(['One', 'Two', 'Three', 'Four', 'Five', '-']);
solve(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);