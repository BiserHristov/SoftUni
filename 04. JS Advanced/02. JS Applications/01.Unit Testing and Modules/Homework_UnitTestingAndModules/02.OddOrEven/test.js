let { assert } = require('chai');
let { isOddOrEven } = require('./isOddOrEven.js')
describe('Task02: isOddOrEven', () => {

    it('when input is not type string it should return undefined', () => {
        assert.equal(undefined, isOddOrEven(5))
    })

    it('should return even when input is with even length', () => {
        assert.equal('even', isOddOrEven('cafe'))
    })

    it('should return odd when input is not with even length', () => {
        assert.equal('odd', isOddOrEven('cafee'))
    })
})