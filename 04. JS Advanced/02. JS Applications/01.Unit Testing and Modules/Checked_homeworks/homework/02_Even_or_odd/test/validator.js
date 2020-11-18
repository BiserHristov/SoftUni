const chai = require('chai').assert;

const { assert } = require('chai');
const toTest = require('../src/funcEvenOrOdd');

describe('Testing if function returns proper result', ()=>{
    it('should return undefined if passed parameter is not a string', ()=>{
        assert.equal(toTest(999), undefined)
    })
    it('should return undefined if passed parameter is not a string', ()=>{
        assert.equal(toTest({zymzazym: '1323123'}), undefined)
    })
    it('should return ODD if passed parameter is correct but its length is not EVEN', ()=>{
        assert.equal(toTest('test string'), 'odd')
    })
    it('should return EVEN if passed parameter is correct and its length is EVEN', ()=>{
        assert.equal(toTest('four'), 'even')
    })
    it('should return ODD if passed parameter is correct and its length is an ODD number', ()=>{
        assert.equal(toTest('six foxes'), 'odd')
    })
    it('should return EVEN if passed parameter is correct and its length is EVEN', ()=>{
        assert.equal(toTest('validators'), 'even')
    })
    it('should return EVEN if passed parameter is correct and its length is an ODD number', ()=>{
        assert.equal(toTest('orang'), 'odd')
    })
})