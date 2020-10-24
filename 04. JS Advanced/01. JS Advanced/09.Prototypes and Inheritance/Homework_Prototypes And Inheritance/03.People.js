function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = []
        }


        work() {
            let task = this.tasks.shift();
            return `${this.name} ${task}`;
            this.tasks.push(task);
        }

        collectSalary() {
            return `${this.name} received ${this.salary} this month.`
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age)
            this.tasks.push('is working on a simple task.')
        }

    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age)
            this.tasks.push('is working on a complicated task.')
            this.tasks.push('is taking time off work.')
            this.tasks.push('is supervising junior workers.')
        }

    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age)
            this.dividend = 0
            this.tasks.push('scheduled a meeting.')
            this.tasks.push('is preparing a quarterly report.')
        }

        collectSalary() {
            return `${this.name} received ${this.salary + this.dividend} this month.`
        }

    }


    return {
        Junior,
        Senior,
        Manager
    }
}

let person= solve();
let manager= new person.Manager('ivan',22);
manager.dividend=50;
manager.salary=3000;
console.log(manager.collectSalary());
console.log(manager.work());

let senior= new person.Senior('pesho',443);
senior.salary=600;
console.log(senior.collectSalary());
console.log(senior.work());
