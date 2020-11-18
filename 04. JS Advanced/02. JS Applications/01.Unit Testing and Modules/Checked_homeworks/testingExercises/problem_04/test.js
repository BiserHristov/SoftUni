let {mathEnforcer} = require('./mathEnforcer.js');
// let { addFive, subtractTen, sum } = require('./mathEnforcer.js');
let { assert } = require('chai');

const positiveNumber = 5;
const floatNumber = 3.12;
const negativeNumber = -3;
const testString = 'test';

const expectedUndefined = undefined;

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it(`Should return undefined when given parameter is not of type ${typeof positiveNumber}`, () => {
            assert.equal(expectedUndefined, mathEnforcer.addFive(testString));
        })
        it(`Should return correct result of the operation ${positiveNumber}+5`, () => {
            assert.equal(positiveNumber + 5, mathEnforcer.addFive(positiveNumber));
        })
        it(`Should return correct result of the operation ${floatNumber}+5`, () => {
            assert.equal(floatNumber + 5, mathEnforcer.addFive(floatNumber));
        })
        it(`Should return correct result of the operation ${negativeNumber}+5`, () => {
            assert.equal(negativeNumber + 5, mathEnforcer.addFive(negativeNumber));
        })
    })

    describe('substractTen', () => {
        it(`Should return undefined when given parameter is not of type ${typeof positiveNumber}`, () => {
            assert.equal(expectedUndefined, mathEnforcer.subtractTen(testString));
        })
        it(`Should return correct result of the operation ${positiveNumber}-10`, () => {
            assert.equal(positiveNumber - 10, mathEnforcer.subtractTen(positiveNumber));
        })
        it(`Should return correct result of the operation ${floatNumber}-10`, () => {
            assert.equal(floatNumber - 10, mathEnforcer.subtractTen(floatNumber));
        })
        it(`Should return correct result of the operation (${negativeNumber})-10`, () => {
            assert.equal(negativeNumber - 10, mathEnforcer.subtractTen(negativeNumber));
        })
    })

    describe('sum', () => {
        it(`Should return undefined when first parameter is not of type ${typeof positiveNumber}`, () => {
            assert.equal(expectedUndefined, mathEnforcer.sum(testString, positiveNumber));
        })
        it(`Should return undefined when second parameter is not of type ${typeof positiveNumber}`, () => {
            assert.equal(expectedUndefined, mathEnforcer.sum(positiveNumber, testString));
        })
        it(`Should return correct result of the operation ${positiveNumber}+${positiveNumber}`, () => {
            assert.equal(positiveNumber + positiveNumber, mathEnforcer.sum(positiveNumber, positiveNumber));
        })
        it(`Should return correct result of the operation ${floatNumber}+${floatNumber}`, () => {
            //In case of floating-point numbers the result should be considered correct if it is within 0.01 of the correct value. 
            assert.equal((2.99).toFixed(2), mathEnforcer.sum(1.49, 1.495).toFixed(2));
            assert.equal((floatNumber + floatNumber).toFixed(2), mathEnforcer.sum(floatNumber, floatNumber).toFixed(2));
        })
        it(`Should return correct result of the operation (${negativeNumber})+(${negativeNumber})`, () => {
            assert.equal(negativeNumber + negativeNumber, mathEnforcer.sum(negativeNumber, negativeNumber));
        })
    })
})
