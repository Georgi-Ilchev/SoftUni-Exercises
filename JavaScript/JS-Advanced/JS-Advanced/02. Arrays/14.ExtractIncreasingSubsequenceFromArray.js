function solve(input) {
    let max = Number.MIN_SAFE_INTEGER;

    input.forEach(num => {
        if (max <= num) {
            max = num;
            console.log(max)
        }
    });
};

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve([1, 2, 3, 4]);
solve([20, 3, 2, 15, 6, 1]);


function solve1(input) {
    let max = Number.MIN_SAFE_INTEGER;

    input = input.filter(num => {
        if (max <= num) {
            max = num;
            return true;
        }
        return false;
    }).forEach(out => console.log(out));
};

solve1([1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve1([1, 2, 3, 4]);
solve1([20, 3, 2, 15, 6, 1]);


function solve2(input) {
    let max = Number.MIN_SAFE_INTEGER;

    let output = input.reduce((acc, curr) => {
        if (max <= curr) {
            max = curr;
            acc.push(max);
        }
        return acc;
    }, []);

    console.log(output.join('\n'));
};

solve2([1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve2([1, 2, 3, 4]);
solve2([20, 3, 2, 15, 6, 1]);