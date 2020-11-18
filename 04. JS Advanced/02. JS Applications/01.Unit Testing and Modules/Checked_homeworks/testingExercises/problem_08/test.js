let { assert, expect } = require('chai');
let Console = require('./console.js')

describe('Console', () => {
    let console;
    describe('constructor', () => {
        it(`Should instantiate the class object properly`, () => {
            console = new Console();
            assert.isDefined(console);
        })
    })

    describe('writeLine', () => {
        it('Should return the string representation of a single string argument.', () => {
            assert.equal('Test', Console.writeLine('Test'));
        })
        it('Should return the JSON representation if the single argument is an object.', () => {
            let obj = { A: 5, B: "Test" };
            assert.equal(JSON.stringify(obj), Console.writeLine(obj));
        })
        it('Should throw TypeError if the first argument of many is not a string.', () => {
            assert.throws(() => { Console.writeLine('Test', 5, 'tt', 'ee', 'ss', 'tt') });
            expect(() => Console.writeLine('Test', 5, 'tt', 'ee', 'ss', 'tt')).to.throw(TypeError);
        })
        it('Should throw RangeError if the number of arguments is not equal to the number of placeholders.', () => {
            expect(() => Console.writeLine('Test {0}, {1}', 'tt', 'ee', 'ss', 'tt')).to.throw(RangeError);
            expect(() => Console.writeLine('Test {0}-{1}-{2}-{3}-{4}', 'tt', 'ee', 'ss', 'tt')).to.throw(RangeError);
        })
        it('Should throw RangeError if the placeholder index does not match any argument index.', () => {
            expect(() => Console.writeLine('Test {0}, {1}, {2}, {13}', 'tt', 'ee', 'ss', 'tt')).to.throw(RangeError);
        })
        it('Should replace all placeholders with the appropriate argument if all requirements are met.', () => {
            assert.equal('Test tt-ee-ss-tt', Console.writeLine('Test {0}-{1}-{2}-{3}', 'tt', 'ee', 'ss', 'tt'));
        })
    })
})