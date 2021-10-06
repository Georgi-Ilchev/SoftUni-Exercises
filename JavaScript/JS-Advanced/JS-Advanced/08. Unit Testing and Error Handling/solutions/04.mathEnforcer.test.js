const { expect } = require('chai');
const mathEnforcer = require('./04.mathEnforcer');

describe('Test mathEnforcer function', () => {

    //addFive(num)
    it('addFive should return undefined on wrong input type/string', () => {
        expect(mathEnforcer.addFive("string")).to.equal(undefined);
    });

    it('addFive should return undefined on wrong input type', () => {
        expect(mathEnforcer.addFive([1])).to.equal(undefined);
    });

    it('addFive should return result with 5 input', () => {
        expect(mathEnforcer.addFive(5)).to.be.equal(10);
    });

    it('addFive should return result with 5.5 input', () => {
        expect(mathEnforcer.addFive(5.5)).to.be.equal(10.5);
    });

    it('addFive should return result with -5.5 input', () => {
        expect(mathEnforcer.addFive(-5.5)).to.be.equal(-0.5);
    });

    //subtractTen(num)
    it('subtract should return undefined on wrong input type/string', () => {
        expect(mathEnforcer.subtractTen("string")).to.equal(undefined);
    });

    it('subtract should return undefined on wrong input type', () => {
        expect(mathEnforcer.subtractTen([1])).to.equal(undefined);
    });

    it('subtract should return result with 5 input', () => {
        expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
    });

    it('subtract should return result with positive input', () => {
        expect(mathEnforcer.subtractTen(5.5)).to.be.equal(-4.5);
    });

    it('subtract should return result with negative input', () => {
        expect(mathEnforcer.subtractTen(-5.5)).to.be.equal(-15.5);
    });

    //sum(num1, num2)
    it('sum num1 string', () => {
        expect(mathEnforcer.sum('string', 1)).to.equal(undefined);
    });

    it('sum num2 string', () => {
        expect(mathEnforcer.sum(1, 'string')).to.equal(undefined);
    });

    it('sum num1 && num2 string', () => {
        expect(mathEnforcer.sum('string', 'string')).to.equal(undefined);
    });

    it('sum num1 [1]]', () => {
        expect(mathEnforcer.sum([1], 1)).to.equal(undefined);
    });

    it('sum num2 [1]]', () => {
        expect(mathEnforcer.sum(1, [1])).to.equal(undefined);
    });

    it('sum num1 && num2 [1]]', () => {
        expect(mathEnforcer.sum([1], [1])).to.equal(undefined);
    });

    it('sum with only 1 number', () => {
        expect(mathEnforcer.sum(5)).to.equal(undefined);
    });

    it('sum positive', () => {
        expect(mathEnforcer.sum(5, 5)).to.equal(10);
    });

    it('sum negative', () => {
        expect(mathEnforcer.sum(-5, -5)).to.equal(-10);
    });

    it('sum decimals', () => {
        expect(mathEnforcer.sum(-5.5, -5.5)).to.equal(-11);
    });
})