function solve(input) {
    let uniques = new Map();

    for (let array of input) {
        array = JSON.parse(array).sort((a, b) => b - a);

        let output = `[${array.join(', ')}]`;

        if (!uniques.has(array)) {
            uniques.set(output, array.length)
        }
    }
    console.log([...uniques.keys()].sort((arr1, arr2) => uniques.get(arr1) - uniques.get(arr2)).join('\n'));
}

solve([
    "[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
)

solve([
    "[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
)

