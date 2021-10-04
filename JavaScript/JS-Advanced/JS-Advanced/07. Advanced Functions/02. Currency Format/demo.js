function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function result(currencyFormatter) {
    let separator = ',';
    let symbol = '$';
    let symbolFirst = true;

    //1
    let currentResult = currencyFormatter.bind(null, separator, symbol, symbolFirst);
    return currentResult;

    //2
    // return value => currencyFormatter(separator, symbol, symbolFirst, value)
}

let dollarFormatter = result(currencyFormatter);
console.log(dollarFormatter(5345)); // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709)); // $ 2,71