class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let [firstName, lastName, personalId] = [customer.firstName, customer.lastName, customer.personalId];

        let searchedCustomer = this.findCustomer(personalId)
        if (searchedCustomer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`)
        }

        this.allCustomers.push(customer)
        return customer;

    }

    depositMoney(personalId, amount) {
        let searchedCustomer = this.findCustomer(personalId)
        if (!searchedCustomer) {
            throw new Error(`We have no customer with this ID!`)
        }

        if (!searchedCustomer.totalMoney) {
            searchedCustomer.totalMoney = 0;
            searchedCustomer.transactions = [];
        }

        searchedCustomer.totalMoney += amount;
        searchedCustomer.transactions.push(`${searchedCustomer.firstName} ${searchedCustomer.lastName} made deposit of ${amount}$!`)

        return `${searchedCustomer.totalMoney}$`

    }
    withdrawMoney(personalId, amount) {
        let searchedCustomer = this.findCustomer(personalId)
        if (!searchedCustomer) {
            throw new Error(`We have no customer with this ID!`)
        }

        if (!searchedCustomer.totalMoney || searchedCustomer.totalMoney < amount) {
            throw new Error(`${searchedCustomer.firstName} ${searchedCustomer.lastName} does not have enough money to withdraw that amount!`)
        }
        searchedCustomer.totalMoney -= amount;
        searchedCustomer.transactions.push(`${searchedCustomer.firstName} ${searchedCustomer.lastName} withdrew ${amount}$!`)

        return `${searchedCustomer.totalMoney}$`

    }

    customerInfo(personalId) {
        let searchedCustomer = this.findCustomer(personalId);
        if (!searchedCustomer) {
            throw new Error(`We have no customer with this ID!`)
        }

        let result = [];
        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${searchedCustomer.firstName} ${searchedCustomer.lastName}`);
        result.push(`Customer ID: ${searchedCustomer.personalId}`);
        result.push(`Total Money: ${searchedCustomer.totalMoney}$`);
        result.push(`Transactions:`);

        for (let index = searchedCustomer.transactions.length - 1; index >= 0; index--) {
            const transaction = searchedCustomer.transactions[index];
            result.push(`${index + 1}. ${transaction}`);
        }







        return result.join('\n');
    }

    findCustomer(personalId) {
        return this.allCustomers.find(c => c.personalId == personalId);
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

