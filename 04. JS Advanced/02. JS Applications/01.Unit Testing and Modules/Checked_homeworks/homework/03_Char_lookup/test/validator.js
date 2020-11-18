const chai = require('chai').assert;
const { assert } = require('chai');
const charLooker = require('../src/charLookup');

describe('Testing char look up functionality', ()=>{
    it('should return undefined if the first passed parameter is not a string', ()=>{
        assert.equal(charLooker(123, 0), undefined);
    })
    it('should return undefined if the second passed parameter is not an integer', ()=>{
        assert.equal(charLooker('123', 0.5), undefined);
    })
    it('should return "Incorrect index" if the passed string parameter is smaller than the index parameter', ()=>{
        assert.equal(charLooker('string', 14), "Incorrect index");
    })
    it('should return "Incorrect index" if the passed index parameter is smaller than zero', ()=>{
        assert.equal(charLooker('string', -14), "Incorrect index");
    })
    it('should return undefined if index parameter is not a number', ()=>{
        assert.equal(charLooker('string', '4'), undefined);
    })
    it('should return correct output if both passed parameters are correct', ()=>{
        assert.equal(charLooker('string', 4), 'n');
    })
    it('should return "Incorrect index" if index is out of string bounds', ()=>{
        assert.equal(charLooker('string', 44), "Incorrect index");
    })
})