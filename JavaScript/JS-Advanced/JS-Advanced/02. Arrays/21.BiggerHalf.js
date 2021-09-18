function biggerHalf(array) {
    array.sort(function (a, b) {
        return a - b;
    })

    array.splice(0, array.length / 2);

   return array;
}

biggerHalf([4, 7, 2, 5]);
biggerHalf([3, 19, 14, 7, 2, 19, 6]);