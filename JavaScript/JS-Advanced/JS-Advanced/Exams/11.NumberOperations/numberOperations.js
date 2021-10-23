const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};

const { assert, expect } = require('chai');

describe("numberOperations", function () {
    describe("powNumber tests", function () {
        it("Should return number to the second power", function () {
            assert.strictEqual(numberOperations.powNumber(5), 25);
            assert.strictEqual(numberOperations.powNumber(1.5), 1.5 * 1.5);
            assert.strictEqual(numberOperations.powNumber(-4), 16);
            assert.strictEqual(numberOperations.powNumber(0), 0);
            assert.isNaN(numberOperations.powNumber(NaN));
        });
    });

    describe("numberChecker tests", function () {
        it("Should correctly coerce input argument", function () {
            assert.strictEqual(numberOperations.numberChecker('3'), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(3), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(''), 'The number is lower than 100!');
        });

        it("Should throw error when input is Nan", function () {
            assert.throw(() => numberOperations.numberChecker('abv'), Error, 'The input is not a number!');
            assert.throw(() => numberOperations.numberChecker('1a'), Error, 'The input is not a number!');
            assert.throw(() => numberOperations.numberChecker(undefined), Error, 'The input is not a number!');
        });

        it("Should return correct string when argument is a valid number", function () {
            assert.strictEqual(numberOperations.numberChecker(50), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker('50'), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(99), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(99.99), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(-1), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(-100), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(150), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker('150'), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker('100'), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker(123.12), 'The number is greater or equal to 100!');
        });
    });

    describe("sumArrays tests", function () {
        it("Should return empty array when called with empty arrays", function () {
            assert.deepEqual(numberOperations.sumArrays([], []), []);
        });

        it("Should return empty array when one parameter is an empty array", function () {
            assert.deepEqual(numberOperations.sumArrays([1, 2, 3], []), [1, 2, 3]);
            assert.deepEqual(numberOperations.sumArrays([], [1, 2, 3]), [1, 2, 3]);
        });

        it("Should return correct result when both parameters are non empty equal length arrays", function () {
            assert.deepEqual(numberOperations.sumArrays([1, 2, 3], [2, 4, 7]), [3, 6, 10]);
            assert.deepEqual(numberOperations.sumArrays([-1, 2, 3], [-2, 4, 7]), [-3, 6, 10]);
            assert.deepEqual(numberOperations.sumArrays([1.1, 2, 3], [2.2, 4, 7]), [1.1 + 2.2, 6, 10]);
            assert.deepEqual(numberOperations.sumArrays(['1', '2', '3'], ['2', '4', '7']), ['12', '24', '37']);
        });

        it("Should return correct result when both parameters are non arrays of different length", function () {
            assert.deepEqual(numberOperations.sumArrays([1, 2], [2, 4, 7]), [3, 6, 7]);
            assert.deepEqual(numberOperations.sumArrays([-1, 2], [-2, 4, 7]), [-3, 6, 7]);
            assert.deepEqual(numberOperations.sumArrays([1.1, 2], [2.2, 4, 7]), [1.1 + 2.2, 6, 7]);
            assert.deepEqual(numberOperations.sumArrays(['1', '2', '3'], ['2', '4']), ['12', '24', '3']);
        });
    });
});
