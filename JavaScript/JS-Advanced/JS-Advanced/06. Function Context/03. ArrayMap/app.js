function arrayMap(array, func) {
    //let mappedArray = array.map(x => func(x));
    let mappedArray = array.reduce((acc, x) => {
        acc.push(func(x))

        return acc;
    }, []);

    return mappedArray;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2)); // [ 2, 4, 6, 8, 10 ]



function arrayMap(array, func) {
    return array.reduce(function (acc, x) {
        acc.push(func(x))

        return acc;
    }, []);
}