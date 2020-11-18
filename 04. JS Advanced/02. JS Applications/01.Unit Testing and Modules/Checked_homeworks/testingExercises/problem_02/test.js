let assert = require('chai').assert;
let { isOddOrEven } = require('./isOddOrEven.js');

const stringEvenLength = 'testString';
const stringOddLength = 'testString1';
const testString = 'test';
const nonString = 5;
const func = () => testString;

const expectedEven = 'even';
const expectedOdd = 'odd';

describe('isOddOrEven', () => {
    it(`Should return undefined when given parameter is not of type string.`, () => {
        assert.equal(undefined, isOddOrEven(nonString));
        assert.equal(undefined, isOddOrEven({}));
        assert.equal(undefined, isOddOrEven({ prop: testString }));
        assert.equal(undefined, isOddOrEven([testString]));
        assert.equal(undefined, isOddOrEven(func));
    })

    it(`Should return "even" when a string with even(${stringEvenLength.length}) length is given.`, () => {
        let result = isOddOrEven(stringEvenLength);
        assert.equal(expectedEven, result);
    })

    it(`Should return "odd" when a string with odd(${stringOddLength.length}) length is given.`, () => {
        let result = isOddOrEven(stringOddLength);
        assert.equal(expectedOdd, result);
    })
})