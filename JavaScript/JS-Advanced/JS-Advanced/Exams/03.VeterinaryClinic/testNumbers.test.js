const testNumbers = require('./testNumbers');
const { expect } = require('chai');

describe('testNumber test', () => {
    describe('test sumNumber', () => {
        it('should work with number input', () => {
            expect(testNumbers.sumNumbers(1, 2)).to.equal('3.00');
            expect(testNumbers.sumNumbers(1, -2)).to.equal('-1.00');
            expect(testNumbers.sumNumbers(1.1, 2.2)).to.equal('3.30');
        });

        it('should return undefined with string input', () => {
            expect(testNumbers.sumNumbers('1', 2)).to.equal(undefined);
            expect(testNumbers.sumNumbers(1, '2')).to.equal(undefined);
            expect(testNumbers.sumNumbers('1', '2')).to.equal(undefined);
        });

        it('should return undefined with incorrect input', () => {
            expect(testNumbers.sumNumbers([], 2)).to.equal(undefined);
            expect(testNumbers.sumNumbers(1, [])).to.equal(undefined);

        });
    });

    describe('test numberChecker', () => {
        it('should works with odd', () => {
            expect(testNumbers.numberChecker(1)).to.contain('odd');
        });

        it('should works with even', () => {
            expect(testNumbers.numberChecker(2)).to.contain('even');
        });

        it('should works with odd as string', () => {
            expect(testNumbers.numberChecker('1')).to.contain('odd');
        });

        it('should works with even as string', () => {
            expect(testNumbers.numberChecker('2')).to.contain('even');
        });

        it('should works with empty input', () => {
            expect(testNumbers.numberChecker('2')).to.contain('even');
        });

        it('should return error when input is Nan', () => {
            expect(() => testNumbers.numberChecker('a')).to.throw();
        });
    });

    describe('test averageSumArray', () => {
        it('should return average sum', () => {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.equal(2);
        });

        it('should return average sum with floats number', () => {
            expect(testNumbers.averageSumArray([1.5, 2.5, 3.5])).to.equal(2.5);
        });
    });
})