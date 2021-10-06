const { expect } = require('chai');
const lookupChar = require('./03.charLookUp');

describe('Test charLookUp', () => {
    it('should return undefined if the first param is not string', () => {
        expect(lookupChar(1, 2)).to.equal(undefined);
    });

    it('should return undefined if the second param is floating-point number', () => {
        expect(lookupChar('string', 1.1)).to.equal(undefined);
    });

    it('should return undefined if the second param is not number', () => {
        expect(lookupChar('string', '1')).to.equal(undefined);
    });

    it('should return Incorrect index if the second param value is incorrect', () => {
        expect(lookupChar('string', 5)).to.equal('Incorrect index');
    });

    it('should return Incorrect index if the second param value is incorrect', () => {
        expect(lookupChar('string', 6)).to.equal('Incorrect index');
    });

    it('should return Incorrect index if the second param value is incorrect', () => {
        expect(lookupChar('string', -1)).to.equal('Incorrect index');
    });

    it('should return character at the specified index', () => {
        expect(lookupChar('string', 1)).to.equal('t');
    });
})

