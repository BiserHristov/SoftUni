const chai = require('chai').assert;

const {
    assert
} = require('chai');
const func = require('../src/mathEnforcer');
let addFive = func.addFive;
let subtractTen = func.subtractTen;
let sum = func.sum;


describe('Testing THE Math enforcer', () => {

    // describe('test addFive', () => {
    //     it('Should add five to the passed parameter number', ()=>{
    //         assert.equal(addFive(5), 10)
    //     })
    //     it('Should return undefined if the passed parameter is not a number', ()=>{
    //         assert.equal(addFive('a'), undefined)
    //     })
    //     it('Should add 5 to the negative parameter number', ()=>{
    //         assert.equal(addFive(-15), -10)
    //     })
    //     it('Should correctly add a floating point number', ()=>{
    //         assert.equal(addFive(0.54654654654654), 5.54654654654654)
    //     })
    // })

    // describe('test subtractTen', () => {
    //     it('Should subtract ten from the parameter number', ()=>{
    //         assert.equal(subtractTen(5), -5)
    //     })

    //     it('Should work with a negative number as a passed parameter', ()=>{
    //         assert.equal(subtractTen(-5), -15)
    //     })
    //     it('Should return undefined if the passed parameter is not a number', ()=>{
    //         assert.equal(subtractTen('a'), undefined)
    //     })
    //     it('Should return undefined if the passed parameter is not a number', ()=>{
    //         assert.equal(subtractTen({}), undefined)
    //     })
    // })

    describe('test sum', () => {
        it('should sum correctly the two passed positive numbers as parameters', () => {
            assert.equal(sum(5, 550), 555)
        })
        it('should sum correctly with negative number as parameter ONE', () => {
            assert.equal(sum(-5, 550), 545)
        })
        it('should sum correctly with negative number as parameter TWO', () => {
            assert.equal(sum(5, -550), -545)
        })
        it('should sum correctly negative numbers as both parameters', () => {
            assert.equal(sum(-5, -550), -555)
        })
        it('should sum correctly with floating point number as parameter ONE', () => {
            assert.equal(sum(5.5, 550), 555.5)
        })
        it('should sum correctly with floating point number as parameter TWO', () => {
            assert.equal(sum(5, 5.5), 10.5)
        })
        it('should sum correctly with floating point numbers as both parameters', () => {
            assert.equal(sum(5.5, 4.5), 10)
        })
        it('should not sum correctly with a parameter ONE that is not a number', () => {
            assert.equal(sum('a', 5), undefined)
        })
        it('should not sum correctly with a parameter TWO that is not a number', () => {
            assert.equal(sum(5, 'c'), undefined)
        })
        it('should not sum correctly with both parameters that are not a number', () => {
            assert.equal(sum('c', 'c'), undefined)
        })
    })

})