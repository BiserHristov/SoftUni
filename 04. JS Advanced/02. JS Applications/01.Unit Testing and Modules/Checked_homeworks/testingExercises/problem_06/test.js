let { assert } = require('chai');
let PaymentPackage = require('./paymentPackage.js')

describe('PaymentPackage', () => {
    let paymentPackage;
    describe('constructor', () => {
        it(`Should instantiate the object with two parameters properly`, () => {
            paymentPackage = new PaymentPackage("Test", 10);

            assert.isDefined(paymentPackage);
            assert.equal('Test', paymentPackage.name);
            assert.equal(10, paymentPackage.value);
        })
    })

    describe('name getter/setter', () => {
        it(`Should throw exception when "name" is not of type string.`, () => {
            assert.throws(() => { new PaymentPackage(10, 10) }, 'Name must be a non-empty string')
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.name = 5; }, 'Name must be a non-empty string')
        })
        it(`Should throw exception when "name" is a string with zero length (empty string).`, () => {
            assert.throws(() => { new PaymentPackage('', 10) }, 'Name must be a non-empty string')
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.name = ''; }, 'Name must be a non-empty string')
        })
        it(`Should get/set "name" properly if all requirements are met.`, () => {
            paymentPackage = new PaymentPackage("Test", 10);
            assert.equal('Test', paymentPackage.name);
            paymentPackage.name = 'newName';
            assert.equal('newName', paymentPackage.name);
        })
    })

    describe('value getter/setter', () => {
        it(`Should throw exception when "value" is not of type number.`, () => {
            assert.throws(() => { new PaymentPackage('Test', 'Test') }, 'Value must be a non-negative number')
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.value = 'Test'; }, 'Value must be a non-negative number')
        })
        it(`Should throw exception when the number "value" is less than zero.`, () => {
            assert.throws(() => { new PaymentPackage('Test', -10) }, 'Value must be a non-negative number')
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.value = -10; }, 'Value must be a non-negative number')
        })
        it(`Should get/set "value" properly if all requirements are met.`, () => {
            paymentPackage = new PaymentPackage("Test", 10);
            assert.equal(10, paymentPackage.value);
            paymentPackage.value = 15;
            assert.equal(15, paymentPackage.value);
        })
    })

    describe('VAT getter/setter', () => {
        it(`Should throw exception when "VAT" is not of type number.`, () => {
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.VAT = 'Test'; }, 'VAT must be a non-negative number')
        })
        it(`Should throw exception when the number "VAT" is less than zero.`, () => {
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.VAT = -10; }, 'VAT must be a non-negative number')
        })
        it(`Should get/set "VAT" properly if all requirements are met.`, () => {
            paymentPackage = new PaymentPackage("Test", 10);
            assert.equal(20, paymentPackage.VAT);
            paymentPackage.VAT = 25;
            assert.equal(25, paymentPackage.VAT);
        })
    })

    describe('active getter/setter', () => {
        it(`Should throw exception when "active" is not of type boolean.`, () => {
            assert.throws(() => { let pp = new PaymentPackage('Test', 10); pp.active = 4; }, 'Active status must be a boolean')
        })
        it(`Should get/set "active" properly if all requirements are met.`, () => {
            paymentPackage = new PaymentPackage("Test", 10);
            assert.equal(true, paymentPackage.active);
            paymentPackage.active = false;
            assert.equal(false, paymentPackage.active);
        })
    })

    describe('toString', () => {
        it(`Should return the correct information as a single string`, () => {
            paymentPackage = new PaymentPackage("Test", 10);
            const expectedOutput = [
                'Package: Test',
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): 12`
            ];
            assert.equal(expectedOutput.join('\n'), paymentPackage.toString());
        })
    })
})