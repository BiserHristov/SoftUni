let { assert, expect } = require('chai');
let StringBuilder = require('./stringBuilder.js')

const testString = 'test';
const stringToAppend = ', there'
const nonString = 5;
const position = 2;

const expectedInsert = `te${testString}st, there, there`;

describe('StringBuilder', () => {
    let sb;
    beforeEach(() => {
        sb = new StringBuilder();
        sb1 = new StringBuilder(testString);
    })

    describe('_vrfyParam', () => {
        it(`Should throw TypeError exception when parameter is not of type string.`, () => {
            assert.throw(() => { sb = new StringBuilder(nonString) }, 'Argument must be string', `Doesn't throw error when argument is of type ${typeof nonString}!`);
            expect(() => sb = new StringBuilder(nonString)).to.throw(TypeError);
            assert.throw(() => { sb = new StringBuilder({}) }, 'Argument must be string', `Doesn't throw error when argument is of type ${typeof {}}}!`);
            expect(() => sb = new StringBuilder({})).to.throw(TypeError);
        })
    })

    describe('constructor', () => {
        it(`Should get instantiated correctly with or without ${typeof testString} argument.`, () => {
            // without argument
            assert.notEqual(undefined, sb, "Object doesn't get instantied properly without an argument");

            // with argument
            assert.notEqual(undefined, sb1, "Object doesn't get instantied properly with an argument");
            assert.equal(testString, sb1, "Object doesn't get instantied properly with an argument");
        })
    })

    describe('append', () => {
        it(`Should append string "${stringToAppend}" at the end of string "${testString}".`, () => {
            sb1.append(stringToAppend);
            assert.equal(testString + stringToAppend, sb1);
        })
    })

    describe('prepend', () => {
        it(`Should prepend string "${stringToAppend}" before string "${testString}".`, () => {
            sb1.prepend(stringToAppend);
            assert.equal(stringToAppend + testString, sb1);
        })
    })

    describe('insertAt', () => {
        it(`Should insert string "${testString}" at given position(${position}).`, () => {
            sb1.append(stringToAppend);
            sb1.append(stringToAppend);
            sb1.insertAt(testString, position)
            assert.equal(expectedInsert, sb1.toString());
            // (there is no need to check if the index is in range)
        })
    })

    describe('remove', () => {
        it(`Should remove 2(length) characters starting from position 0(index).`, () => {
            sb1.append(stringToAppend);
            sb1.remove(0, 4)
            assert.equal(stringToAppend, sb1.toString());
            // (there is no need to check if the index is in range)
        })
    })

    
    describe('toString', () => {
        it(`Should join all strings from the _stringArray into one.`, () => {
            sb1.append(stringToAppend);
            assert.equal(testString + stringToAppend, sb1.toString());
        })
    })
})