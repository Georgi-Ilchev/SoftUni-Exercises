const { expect } = require('chai');
const rgbToHexColor = require('./rgb-to-hex');

describe('input checker', () => {
    it('should return undefined with first string input', () => {
        expect(rgbToHexColor('red', 0, 0)).to.equal(undefined);
    })

    it('should return undefined with second string input', () => {
        expect(rgbToHexColor(0, 'green', 0)).to.equal(undefined);
    })

    it('should return undefined with third string input', () => {
        expect(rgbToHexColor(0, 0, 'blue')).to.equal(undefined);
    })

    it('should return undefined with negative first input', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.equal(undefined);
    })

    it('should return undefined with negative second input', () => {
        expect(rgbToHexColor(10, -10, 20)).to.equal(undefined);
    })

    it('should return undefined with negative third input', () => {
        expect(rgbToHexColor(5, 2, -10)).to.equal(undefined);
    })

    it('should return undefined with first input over 255', () => {
        expect(rgbToHexColor(256, 0, 0)).to.equal(undefined);
    })

    it('should return undefined with second input over 255', () => {
        expect(rgbToHexColor(100, 256, 10)).to.equal(undefined);
    })

    it('should return undefined with third input over 255', () => {
        expect(rgbToHexColor(100, 255, 256)).to.equal(undefined);
    })

    it('should return undefined with string first input', () => {
        expect(rgbToHexColor('100', 255, 200)).to.equal(undefined);
    })

    it('should return undefined with string second input', () => {
        expect(rgbToHexColor(100, '255', 200)).to.equal(undefined);
    })

    it('should return undefined with string third input', () => {
        expect(rgbToHexColor(100, 255, '200')).to.equal(undefined);
    })

    it('should be black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    })

    it('should be white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    })
})