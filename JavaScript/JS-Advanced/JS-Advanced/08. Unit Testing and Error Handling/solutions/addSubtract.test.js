const { expect } = require('chai');
const createCalculator = require('./addSubtract');

describe('testing createCalculator', () => {
    let calculator = null;

    beforeEach(() => {
        calculator = createCalculator();
    })

    it('has all methods', () => {
        expect(calculator).to.has.ownProperty('add');
        expect(calculator).to.has.ownProperty('subtract');
        expect(calculator).to.has.ownProperty('get');
    })

    it('check add with single number', () => {
        calculator.add(1);

        expect(calculator.get()).to.equal(1);
    });

    it('check add with multiple numbers', () => {
        calculator.add(1);
        calculator.add(2);

        expect(calculator.get()).to.equal(3);
    });

    it('check subtract with single number', () => {
        calculator.subtract(1);

        expect(calculator.get()).to.equal(-1);
    });

    it('check subtract with multiple numbers', () => {
        calculator.subtract(1);
        calculator.subtract(1);

        expect(calculator.get()).to.equal(-2);
    });

    it('check add and subtract with negative numbers', () => {
        calculator.add(-125);
        calculator.subtract(-25);

        expect(calculator.get()).to.equal(-100);
    });

    it('check add and subtract with zero numbers', () => {
        calculator.add(0);
        calculator.subtract(0);

        expect(calculator.get()).to.equal(0);
    });

    it('should cast string add input to Number', () => {
        calculator.add('-10');
        calculator.subtract(-1);

        expect(calculator.get()).to.equal(-9);
    });

    it('should cast string subtract input to Number', () => {
        calculator.add(10);
        calculator.subtract('5');

        expect(calculator.get()).to.equal(5);
    });

    it('should return Nan with other add input', () => {
        calculator.add('asd');
        calculator.subtract(0);

        expect(calculator.get()).to.be.NaN;
    });

    it('should return Nan with other subtract input', () => {
        calculator.subtract('asd');

        expect(calculator.get()).to.be.NaN;
    });
});