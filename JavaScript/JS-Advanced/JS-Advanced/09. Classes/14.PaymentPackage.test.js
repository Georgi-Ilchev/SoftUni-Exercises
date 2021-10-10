const { expect, assert } = require('chai');
const { PaymentPackage } = require('./14.PaymentPackage');

describe('PaymentPackage testing', () => {
    it('constructor test', () => {
        let instance = new PaymentPackage('name', 100);

        assert.equal(instance._name, 'name');
        assert.equal(instance._value, 100);
        assert.equal(instance._VAT, 20);
        assert.equal(instance._active, true);
    })

    it('Should throw error when name is incorrect', () => {
        expect(() => new PaymentPackage(123, 123)).to.throw('Name must be a non-empty string');
        expect(() => new PaymentPackage(['name'], 123)).to.throw('Name must be a non-empty string');
        expect(() => new PaymentPackage('', 123)).to.throw('Name must be a non-empty string');
    })

    it('Should throw error when value is incorrect', () => {
        expect(() => new PaymentPackage('name', 'name')).to.throw('Value must be a non-negative number');
        expect(() => new PaymentPackage('name', [123])).to.throw('Value must be a non-negative number');
        expect(() => new PaymentPackage('name', -123)).to.throw('Value must be a non-negative number');
    })

    it('Should throw error when VAT is incorrect', () => {
        let instance = new PaymentPackage('name', 123);
        expect(() => instance.VAT = 'name').to.throw('VAT must be a non-negative number');
        expect(() => instance.VAT = [123]).to.throw('VAT must be a non-negative number');
        expect(() => instance.VAT = -123).to.throw('VAT must be a non-negative number');
    })

    it('Should throw error when Active is incorrect', () => {
        let instance = new PaymentPackage('name', 123);
        expect(() => instance.active = 'name').to.throw('Active status must be a boolean');
        expect(() => instance.active = [123]).to.throw('Active status must be a boolean');
        expect(() => instance.active = -123).to.throw('Active status must be a boolean');
    })

    it('Name should work correct', () => {
        expect(() => new PaymentPackage('name', 123)).not.to.throw('Name must be a non-empty string');
    })

    it('Value should work correct', () => {
        expect(() => new PaymentPackage('name', 123)).not.to.throw('Value must be a non-negative number');
    })

    it('Should set Value to 0', () => {
        let instance = new PaymentPackage('name', 100);
        assert.doesNotThrow(() => { instance.value = 0 })
    })

    it('VAT should work correct', () => {
        let instance = new PaymentPackage('name', 10);
        expect(() => instance._VAT = 123).not.to.throw('VAT must be a non-negative number');
    })

    it('Active should work correct', () => {
        let instance = new PaymentPackage('name', 10);
        expect(() => instance.active = true).not.to.throw('Active status must be a boolean');
    })

    it('Should return a string as all the input is correct - 1', () => {
        let instance = new PaymentPackage('name', 10);
        let output = [
            `Package: name`,
            `- Value (excl. VAT): 10`,
            `- Value (VAT 20%): 12`
        ]

        expect(instance.toString()).to.equal(output.join('\n'));
    })

    it('Should return a string as all the input is correct - 2', () => {
        let instance = new PaymentPackage('name', 10);
        instance.VAT = 30;
        let output = [
            `Package: name`,
            `- Value (excl. VAT): 10`,
            `- Value (VAT 30%): 13`
        ]
        expect(instance.toString()).to.equal(output.join('\n'));
    });

    it('Should return a string as all the input is correct - 3', () => {
        let instance = new PaymentPackage('name', 123);
        instance.active = false;
        let output = [
            `Package: name (inactive)`,
            `- Value (excl. VAT): 123`,
            `- Value (VAT 20%): 147.6`
        ]
        expect(instance.toString()).to.equal(output.join('\n'));
    });

    it('Should return a string as all the input is correct - 4', () => {
        let instance = new PaymentPackage('name', 123);
        instance.VAT = 30;
        instance.active = false;
        let output = [
            `Package: name (inactive)`,
            `- Value (excl. VAT): 123`,
            `- Value (VAT 30%): 159.9`
        ]
        expect(instance.toString()).to.equal(output.join('\n'));
    });
})