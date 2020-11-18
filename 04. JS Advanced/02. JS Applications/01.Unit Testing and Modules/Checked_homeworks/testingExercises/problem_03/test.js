let { assert, expect } = require('chai');
let { lookupChar } = require('./lookupChar.js');

const testString = 'test';
const positiveNumber = 4;
const floatNumber = 3.12;
const negativeNumber = -5;
const validIndex = 2;

const expectedUndefined = undefined;
const indexMessage = 'Incorrect index';
const expectedCharAtPositionThree = 's';

describe('lookupChar', () => {
    it(`Should return undefined when first parameter is not of type string -> (${typeof positiveNumber}).`, () => {
        assert.equal(expectedUndefined, lookupChar(positiveNumber, positiveNumber));
        // expect(lookupChar(positiveNumber, positiveNumber)).to.equal(undefined, 'Incorrect result!');
    })

    it(`Should return undefined when second parameter is not of type number -> (${typeof testString}).`, () => {
        assert.equal(expectedUndefined, lookupChar(testString, testString));
    })

    it(`Should return unfedined when second parameter is a floating point number(${floatNumber})`, () => {
        assert.equal(expectedUndefined, lookupChar(testString, floatNumber));
    })

    it(`Should return "${indexMessage}" string message when index(${positiveNumber}) is out of range of the first(${typeof testString}) parameter's length(${testString.length}).`, () => {
        assert.equal(indexMessage, lookupChar(testString, positiveNumber));
    })

    it(`Should return "${indexMessage}" string message when index(${negativeNumber}) is lower than zero.`, () => {
        assert.equal(indexMessage, lookupChar(testString, negativeNumber));
    })

    it(`Should return correct character assigned at valid index(${validIndex}) in string(${testString})`, () => {
        assert.equal(expectedCharAtPositionThree, lookupChar(testString, validIndex));
    })
})