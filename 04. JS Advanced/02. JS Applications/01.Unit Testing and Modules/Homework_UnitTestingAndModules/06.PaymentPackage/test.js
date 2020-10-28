let { assert } = require('chai');
let PaymentPackage = require('./paymentPackage')


describe('06. Payment Package:', () => {

    let pp;

    beforeEach(() => {
        pp = new PaymentPackage('Pesho', 22);

    })

    describe('constructor tests:', () => {
        it('When first parameter is not string, should throw', () => {
            assert.throw(() => new PaymentPackage(66, 20), 'Name must be a non-empty string')
        })

        it('When first parameter is empty string, should throw', () => {
            assert.throw(() => new PaymentPackage('', 20), 'Name must be a non-empty string')
        })

        it('When second parameter is not number, should throw', () => {
            assert.throw(() => new PaymentPackage('Pesho', 'Ivanov'), 'Value must be a non-negative number')
        })

        it('When second parameter is less than 0, should throw', () => {
            assert.throw(() => new PaymentPackage('Pesho', -5), 'Value must be a non-negative number')
        })

        it('When all parameters are valid, data should be set correctly', () => {

            assert.equal('Pesho', pp.name)
            assert.equal(22, pp.value)
        })

        it('When all parameters are valid, VAT should be 20', () => {

            assert.equal(20, pp.VAT)
        })

        it('When all parameters are valid, active should be true', () => {

            assert.equal(true, pp.active)
        })

    })

    describe('VAT getter/setter:', () => {
        it('setting VAT with type different from number, should throw', () => {

            assert.throw(() => pp.VAT = 'word', 'VAT must be a non-negative number')
        })

        it('setting VAT with number less than 0, should throw', () => {

            assert.throw(() => pp.VAT = -5, 'VAT must be a non-negative number')
        })

        it('setting VAT with positive number, should work as expected', () => {
            pp.VAT = 30;
            assert.equal(30, pp.VAT)
        })
    })

    describe('active getter/setter:', () => {
        it('setting active with parameter different from boolean, should throw ', () => {


            assert.throw(() => pp.active = 'hello', 'Active status must be a boolean')
        })

        it('setting active with boolean, should work as expected ', () => {

            pp.active = false;
            assert.equal(false, pp.active);
        })
    })

    describe('toString():', () => {
        it('If active is false, (inactive) string should be added next to package name', () => {
            pp.active = false;

            let result = 'Package: Pesho (inactive)\n' +
                '- Value (excl. VAT): 22\n' +
                '- Value (VAT 20%): 26.4'

            assert.equal(result, pp.toString());
        })

        it('If active is true, (inactive) string should not be added next to package name', () => {

            let result = 'Package: Pesho\n' +
                '- Value (excl. VAT): 22\n' +
                '- Value (VAT 20%): 26.4'

            assert.equal(result, pp.toString());
        })
    })
})