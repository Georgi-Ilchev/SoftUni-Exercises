function solve(matrix) {
    let primarySum = 0;
    let secondarySum = 0;

    let elementIndex = 0;

    matrix.forEach((row) => {
        primarySum += row[elementIndex]
        secondarySum += row[row.length - 1 - elementIndex];

        elementIndex++;
    });

    console.log(primarySum + ' ' + secondarySum);
};
solve([[20, 40],
[10, 60]]);

solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]);