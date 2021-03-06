function solve(matrix) {
    let maxNumber = Number.MIN_SAFE_INTEGER;

    matrix.forEach(row => {
        let currentMax = Number.MIN_SAFE_INTEGER;

        row.forEach(num => {
            if (currentMax < num) {
                currentMax = num;
            }
        });

        if (maxNumber < currentMax) {
            maxNumber = currentMax;
        }
    });

    console.log(maxNumber);
};

solve([[20, 50, 10],
[8, 33, 145]]
);

solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);



function solve1(matrix) {
    let maxNumber = Number.MIN_SAFE_INTEGER;

    matrix.forEach(row => {
        let currentMax = Math.max(...row);

        if (maxNumber < currentMax) {
            maxNumber = currentMax;
        }
    });

    console.log(maxNumber);
};

solve1([[20, 50, 10],
[8, 33, 145]]
);

solve1([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);


function solve2(matrix) {
    let maxNumbers = matrix
        .map(row => Math.max(...row));

    console.log(Math.max(...maxNumbers));
};

solve2([[20, 50, 10],
[8, 33, 145]]
);

solve2([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);


function solve3(matrix) {
    let maxNumbers = matrix
        .map(row => Math.max(...row))
        .reduce((a, x) => Math.max(a, x), Number.MIN_SAFE_INTEGER);

    console.log(Math.max(maxNumbers));
};

solve3([[20, 50, 10],
[8, 33, 145]]
);

solve3([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);