class VeterinaryClinic {

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.currentWorkload = 0;
        this.totalProfit = 0
        this.totalPets = 0
    }



    newCustomer(ownerName, newPetName, newKind, newProcedures) {
        if (this.currentWorkload >= this.capacity) {
            throw new Error("Sorry, we are not able to accept more patients!")
        }

        let owner = this.clients.find(c => c.name == ownerName)

        if (!owner) {
            let item = {
                name: ownerName,
                pets: []
            }

            this.clients.push(item);
            let pet = { petName: newPetName, kind: newKind.toLowerCase(), procedures: newProcedures }
            owner = this.clients.find(c => c.name == ownerName)
            owner.pets.push(pet);

        }
        else {
            let searchedPet = owner.pets.find(p => p.petName == newPetName)
            if (searchedPet) {
                if (searchedPet.procedures.length != 0) {
                    throw new Error(`This pet is already registered under ${ownerName} name! ${searchedPet.petName} is on our lists, waiting for ${searchedPet.procedures.join(', ')}.`)
                }
                else {

                    searchedPet.procedures = newProcedures;
                }

            } else {
                let pet = { petName: newPetName, kind: newKind.toLowerCase(), procedures: newProcedures }
                owner = this.clients.find(c => c.name == ownerName)
                owner.pets.push(pet);
            }
        }





        //  this.clients[ownerName].pets.push(pet);
        this.workload++;
        return `Welcome ${newPetName}!`
    }

    onLeaving(ownerName, newPetName) {
        let owner = this.clients.find(c => c.name == ownerName)
        if (!owner) {
            return "Sorry, there is no such client!"
        }

        let searchedPet = owner.pets.find(p => p.petName == newPetName);
        let isEmpty = searchedPet.procedures.length == 0;
        if (!searchedPet || isEmpty) {
            return `Sorry, there are no procedures for ${newPetName}!`
        }

        this.totalProfit += searchedPet.procedures.length * 500.00;
        this.workload--;
        searchedPet.procedures = [];

        return `Goodbye ${newPetName}. Stay safe!`

    }

    toString() {
        let count = 0
        this.clients.forEach(cl => {
            cl.pets.forEach(pet => {
                if (pet.procedures.length != 0) {
                    count++;
                }
            })
        });
        
        let percentage = Math.floor(((count * 100) / this.capacity));
        let result = [];
        result.push(`${this.clinicName} is ${percentage}% busy today!`)
        result.push(`Total profit: ${this.totalProfit.toFixed(2)}$`)

        this.clients.sort((curr, next) => curr.name.localeCompare(next.name))
            .forEach((c => {
                result.push(`${c.name} with:`)
                c.pets.sort((a, b) => a.petName.localeCompare(b.petName))
                    .forEach(pet => {
                        result.push(`---${pet.petName} - a ${pet.kind} that needs: ${pet.procedures.join(', ')}`)
                    })
            }))


        return result.join('\n').trim()
    }
}



let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());







