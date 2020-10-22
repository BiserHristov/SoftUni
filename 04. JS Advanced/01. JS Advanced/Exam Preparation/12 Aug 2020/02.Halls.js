function solveClasses() {


    class Hall {
        constructor(capacity, name) {
            this.capacity = capacity;
            this.name = name;
            this.events = []
        }

        hallEvent(title) {
            let event = this.events.find(e => e.title == title);
            if (event) {
                throw new Error("This event is already added!")
            }

            event = { title }
            this.events.push(event);
            return "Event is added."
        }
        close() {
            this.events = [];
            return `${this.name} hall is closed.`
        }
        toString() {
            let result = [];
            result.push(`${this.name} hall - ${this.capacity}`)
            if (this.events.length > 0) {

                let allEvents = [];
                this.events.forEach(e => allEvents.push(e.title))
                result.push(`Events: ${allEvents.join(', ').trim()}`)
            }

            return result.join('\n').trim();
        }
    }

    class MovieTheater extends Hall {
        constructor(capacity, name, screenSize) {
            super(capacity, name)
            this.screenSize = screenSize;

        }

        close() {
            return super.close() + "Аll screenings are over."
        }

        toString() {
            let result = [];
            result.push(super.toString());
            result.push(`${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`)

            return result.join('\n').trim();
        }

    }


    class ConcertHall extends Hall {
        constructor(capacity, name) {
            super(capacity, name)

        }

        hallEvent(title, performers) {

            let message = super.hallEvent(title);
            let event = this.events.find(e => e.title == title);
            event.performers = performers;
            
            return message;

        }

        close() {
            return super.close() + "Аll performances are over."
        }

        toString() {
            let result = [];
            result.push(super.toString());
            if (this.events.length > 0) {
                let allPerformances = [];
                this.events.forEach(e => allPerformances.push(e.performers.join(', ')));
                result.push(`Performers: ${allPerformances.join(', ')}.`)
            }

            return result.join('\n').trim();
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall
    }

}

// let classes = solveClasses();
// let hall = new classes.Hall(20, 'Main');
// console.log(hall.hallEvent('Breakfast Ideas'));
// console.log(hall.hallEvent('Annual Charity Ball'));
// console.log(hall.toString());
// console.log(hall.close()); 
// --------------------------------------------------------------------------------------
// let movieHall = new classes.MovieTheater(10, 'Europe', '10m');
// console.log(movieHall.hallEvent('Top Gun: Maverick')); 
// console.log(movieHall.toString());
// --------------------------------------------------------------------------------------
// let concert = new classes.ConcertHall(5000, 'Diamond');        
// console.log(concert.hallEvent('The Chromatica Ball', ['LADY GAGA']));  
// console.log(concert.toString());
// console.log(concert.close());
// console.log(concert.toString());
// Corresponding output
// Event is added.
// Event is added.
// Main hall - 20
// Events: Breakfast Ideas, Annual Charity Ball
// Main hall is closed.
// --------------------------------------------------------------------------------------
// Event is added.
// Europe hall - 10
// Events: Top Gun: Maverick
// Europe is a movie theater with 10m screensize and 10 seats capacity.
// --------------------------------------------------------------------------------------
// Event is added.
// Diamond hall - 5000
// Events: The Chromatica Ball
// Performers: LADY GAGA.
// Diamond hall is closed.Аll performances are over.
// Diamond hall - 5000




