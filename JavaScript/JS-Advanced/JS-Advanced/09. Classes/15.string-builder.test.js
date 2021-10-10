const { expect, assert } = require('chai');
const { StringBuilder } = require('./15.string-builder');

describe('string-builder tests', () => {
    let instance;
    beforeEach(function () {
        instance = new StringBuilder('string');
    })

    describe('check properties', () => {
        it('append', () => {
            expect(Object.getPrototypeOf(instance)
                .hasOwnProperty('append')).to.equal(true)
        });

        it('prepend', () => {
            expect(Object.getPrototypeOf(instance)
                .hasOwnProperty('prepend')).to.equal(true)
        });

        it('insertAt', () => {
            expect(Object.getPrototypeOf(instance)
                .hasOwnProperty('insertAt')).to.equal(true)
        });

        it('remove', () => {
            expect(Object.getPrototypeOf(instance)
                .hasOwnProperty('remove')).to.equal(true)
        });

        it('toString', () => {
            expect(Object.getPrototypeOf(instance)
                .hasOwnProperty('toString')).to.equal(true)
        });

        it('toString should return string', () => {
            expect(instance.toString()).to.equal('string');
        });
    })

    describe('test functions', () => {
        it('vrfyParam should throw TypeError != string', () => {
            expect(() => { instance = instance.append(1) }).to.throw('Argument must be a string');
        });

        it('append', () => {
            instance.append(', hello');
            expect(instance.toString()).to.equal('string, hello')
        });

        it('prepend', () => {
            instance.prepend('nice, ');
            expect(instance.toString()).to.equal('nice, string')
        });

        it('insertAt', () => {
            instance.insertAt(',insert', 6);
            expect(instance.toString()).to.equal('string,insert')
        });

        it('remove', () => {
            instance.remove(3, 3);
            expect(instance.toString()).to.equal('str')
        });

        it('toString', () => {
            expect(instance.toString()).to.equal('string')
        });
    })

    describe('another tests', () => {
        it('initialize instance with empty string', () => {
            let newInstance = new StringBuilder();
            expect(newInstance.toString()).to.equal('');
        });

        it('test toString', () => {
            instance.append('javascript');
            instance.append('c#');

            expect(instance.toString()).to.be.equal('stringjavascriptc#')
        });

        it('Should throw TypeError when input is not string - append', () => {
            expect(() => { instance = instance.append(1) }).to.throw('Argument must be a string');
        });

        it('Should throw TypeError when input is not string - prepend', () => {
            expect(() => { instance = instance.prepend(1) }).to.throw('Argument must be a string');
        });

        it('Should throw TypeError when input is not string - insertAt', () => {
            expect(() => { instance = instance.insertAt(1, 1) }).to.throw('Argument must be a string');
        });

        it('toString works correctly - 2', () => {
            const expected = '\n A \n\r B\t123   ';
            const obj = new StringBuilder();

            expected.split('').forEach(s => { obj.append(s); obj.prepend(s); });

            obj.insertAt('test', 4);

            obj.remove(2, 4);

            expect(obj.toString()).to.equal('  st21\tB \r\n A \n\n A \n\r B\t123   ');
        });
    })
})