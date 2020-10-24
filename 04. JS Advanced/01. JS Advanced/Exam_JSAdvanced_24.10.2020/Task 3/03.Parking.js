class Parking {

    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {

        if (this.vehicles.length == this.capacity) {
            throw new Error("Not enough parking space.")
        }

        let car = { carModel, carNumber, payed: false }
        this.vehicles.push(car);

        return `The ${carModel}, with a registration number ${carNumber}, parked.`
    }

    removeCar(carNumber) {
        let searchedCar = this.vehicles.find(c => c.carNumber == carNumber)

        if (!searchedCar) {
            throw new Error("The car, you're looking for, is not found.")
        }

        if (searchedCar.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }

        this.vehicles = this.vehicles.filter(c => c.carNumber != carNumber);

        return `${carNumber} left the parking lot.`
    }

    pay(carNumber) {
        let searchedCar = this.vehicles.find(c => c.carNumber == carNumber)
        if (!searchedCar) {
            throw new Error(`${carNumber} is not in the parking lot.`)
        }

        if (searchedCar.payed == true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`)
        }

        searchedCar.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`

    }

    getStatistics(carNumber) {

        let result = [];

        if (carNumber == undefined) {
            result.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`)
            this.vehicles.sort((curr, next) => curr.carModel.localeCompare(next.carModel))
            .forEach(c=> result.push(`${c.carModel} == ${c.carNumber} - ${ c.payed==true? 'Has payed' : 'Not payed'}`))

        }else{

            let searchedCar = this.vehicles.find(c => c.carNumber == carNumber)


            result.push(`${searchedCar.carModel} == ${searchedCar.carNumber} - ${ searchedCar.payed==true? 'Has payed' : 'Not payed'}`)
        }

        return result.join('\n').trim();

    }

}

// const parking = new Parking(12);

// console.log(parking.addCar("Volvo t600", "TX3691CA"));
// console.log(parking.getStatistics());

// console.log(parking.pay("TX3691CA"));
// console.log(parking.removeCar("TX3691CA"));
