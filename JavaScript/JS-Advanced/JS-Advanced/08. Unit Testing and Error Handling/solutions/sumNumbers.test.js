const { expect } = require('chai');
const sum = require('./sumNumbers');

describe('sumNumbers checker', () => {
    it('should return sum of all numbers of array', () => {
        expect(sum([2, 3, 5])).to.be.equal(10);
    })

    it('should return sum of all numbers of array with one number', () => {
        expect(sum([2])).to.be.equal(2);
    })

    it('should return sum of all numbers of array with negative number', () => {
        expect(sum([2, -2, 3])).to.be.equal(3);
    })
});