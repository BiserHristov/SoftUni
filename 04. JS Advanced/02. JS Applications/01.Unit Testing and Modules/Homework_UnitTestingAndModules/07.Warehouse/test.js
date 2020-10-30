let { assert } = require('chai');
let Warehouse = require('./warehouse')


describe('WareHouse', () => {
    let wareH;
    beforeEach(function () {
        wareH = new Warehouse(12);
    })
    describe('constructor', () => {
        it('Should throw error if capacity is not of type number', () => {
            assert.throws(() => { wareH = new Warehouse('Ivan') }, `Invalid given warehouse space`);
        })
        it('Should throw error if capacity is a negative number', () => {
            assert.throws(() => { wareH = new Warehouse(-2) }, `Invalid given warehouse space`);
        })
        it('Should work properly', () => {
            const expectedCapacity = 12;
            const expectedProducts = { "Food": {}, "Drink": {} };
            assert.equal(wareH.capacity, expectedCapacity);
            assert.deepEqual(wareH.availableProducts, expectedProducts);

        })

    })
    describe('addProduct', () => {
        it('Should throw error if capacity is not enough', () => {
            assert.throws(() => { wareH.addProduct('Food', 'Banana', 2000) }, `There is not enough space or the warehouse is already full`);
        })
        it('Should add product correctly', () => {
            let expectedOutput = { Banana: 12 };
            assert.deepEqual(wareH.addProduct('Food', 'Banana', 12), expectedOutput);
        })
    })
    describe('orderProducts', function(){
        it('Should order products properly',()=>{
            wareH = new Warehouse(70);
            let expectedOutput = { Carrot: 15, Banana: 12, Apple: 7 };
            wareH.addProduct('Food', 'Banana', 12);
            wareH.addProduct('Food', 'Apple', 7);
            wareH.addProduct('Food', 'Carrot', 15);
            assert.deepEqual(wareH.orderProducts('Food'), expectedOutput);
        })
        
    })
    describe('revision',function(){
        it('Should return all products properly in string',()=>{
            let expectedOutput=`Product type - [Food]\n- Banana 1\nProduct type - [Drink]\n- Water 2`;
            wareH.addProduct('Food','Banana',1);
            wareH.addProduct('Drink','Water',2);
            assert.equal(wareH.revision(),expectedOutput);

        })
        it('Should throw error if capacity is empty',()=>{
            
           let expectedOutput='The warehouse is empty';
           assert.equal(wareH.revision(),expectedOutput);
        })
    })
    describe('scrapeAProduct',function(){
        it('Should throw error if product does not exist',()=>{
           
            assert.throws(()=>{wareH.scrapeAProduct('Cola',12)},`Cola do not exists`);
        })
        it('Should reduce quantity properly',()=>{
            let expectedOutput={'Banana':7};
            wareH.addProduct('Food','Banana',12);
            assert.deepEqual(wareH.scrapeAProduct('Banana',5),expectedOutput);
        })
    })
    describe('occupiedCapacity',function(){
        it('Should work properly',()=>{
            let expectedCapacity=12;
            wareH.addProduct('Food','Banana',12);
            assert.equal(wareH.occupiedCapacity(),expectedCapacity);
        })
    })
})