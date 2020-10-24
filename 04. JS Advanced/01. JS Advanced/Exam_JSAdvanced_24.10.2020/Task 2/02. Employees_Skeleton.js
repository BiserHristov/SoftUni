function solveClasses() {

    class Developer {

        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let task = {
                id,
                name: taskName,
                priority
            }

            if (priority == 'high') {
                this.tasks.unshift(task)

            } else {
                this.tasks.push(task)
            }

            return `Task id ${id}, with ${priority} priority, has been added.`

        }

        doTask() {
            let task = this.tasks.shift();

            if (!task) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`
            }

            return task.name
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`
        }

        reviewTasks() {
            let result = [];
            result.push(`Tasks, that need to be completed:`)

            this.tasks.forEach(t => result.push(`${t.id}: ${t.name} - ${t.priority}`))

            return result.join('\n').trim();;
        }

    }




    class Junior extends Developer {

        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName)
            this.baseSalary = 1000 + bonus;
            this.experience = experience;

        }

        learn(years) {
            this.experience += years;
        }

    }


    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName)
            this.baseSalary = this.baseSalary + bonus;
            this.experience = experience + 5;
        }

        changeTaskPriority(taskId) {
            let task = this.tasks.find(t => t.id == taskId)
            this.tasks = this.tasks.filter(t => t.id != taskId)

            if (task.priority == 'high') {
                task.priority = 'low'
                this.tasks.push(task)
            }
            else {
                task.priority = 'high'
                this.tasks.unshift(task)
            }

            return task;

        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}
// let classes = solveClasses();

// const developer = new classes.Developer("Jonathan", "Joestar");
// console.log(developer.getSalary())
// console.log(developer.addTask(1, "Inspect bug", "low"))
// developer.addTask(2, "Update repository", "high");
// console.log(developer.reviewTasks())

// developer.doTask();
// developer.doTask();
// console.log(developer.doTask())
