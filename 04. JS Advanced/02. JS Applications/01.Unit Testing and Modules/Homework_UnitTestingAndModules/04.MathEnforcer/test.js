let { assert } = require('chai');
let { addFive, subtractTen, sum } = require('./mathEnforcer.js')

describe('Task04. MathEnforcer', () => {

    describe('addFive tests:', () => {

        it('should return undefined when input is not a number', () => {
            assert.equal(undefined, addFive('Pesho'))
        })

        it('should add 5 to parameter, when input is valid', () => {
            assert.equal(15, addFive(10))
        })
    })

    describe('subtractTen tests:', () => {

        it('should return undefined when input is not a number', () => {
            assert.equal(undefined, subtractTen('Pesho'))
        })

        it('should substract 10 to parameter, when input is valid', () => {
            assert.equal(15, subtractTen(25))
        })
    })

    describe('sum tests:', () => {

        it('should return undefined when first parameter type is not a number', () => {
            assert.equal(undefined, sum('Pesho', 5))
        })

        it('should return undefined when second parameter type is not a number', () => {
            assert.equal(undefined, sum(5, 'Pesho'))
        })

        it('should return the sum of two numbers, when inpit is valid', () => {
            assert.equal(20, sum(5, 15))
        })
    })
})