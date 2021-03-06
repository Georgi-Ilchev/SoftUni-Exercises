function solve(input) {
    let result = {};

    while (input.length != 0) {
        let town = input.shift();
        let income = Number(input.shift());

        //1
        // if (result.hasOwnProperty(town)) {
        //     result[town] += income;
        // } else {
        //     result[town] = income;
        // }

        //2
        if (!result[town]) {
            result[town] = 0;
        }
        result[town] += income;
    }

    console.log(JSON.stringify(result));
};

solve(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
solve(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);