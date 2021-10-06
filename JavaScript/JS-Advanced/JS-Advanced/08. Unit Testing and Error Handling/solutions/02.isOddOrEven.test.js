const { expect } = require('chai');
const isOddOrEven = require('./02.isOddOrEven');

describe('isOddOrEven checker', () => {
    it('should return undefined when not pass string', () => {
        expect(isOddOrEven(1)).to.be.undefined;
        expect(isOddOrEven()).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
    });

    it('should return even when pass even length string', () => {
        expect(isOddOrEven('even')).to.be.string('even');
        expect(isOddOrEven('')).to.be.string('even');
    });

    it('should return even when pass odd length string', () => {
        expect(isOddOrEven('odd')).to.be.string('odd');
    });
})