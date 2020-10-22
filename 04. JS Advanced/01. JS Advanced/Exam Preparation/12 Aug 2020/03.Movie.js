class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalProfit = 0;
        this.totalSoldTickets = 0;
    }

    newScreening(date, hall, description) {
        let screeneing = this.getScreening(date, hall);
        if (screeneing) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`)
        }

        screeneing = { date, hall, description };
        this.screenings.push(screeneing);

        return `New screening of ${this.movieName} is added.`  //Moviename ???

    }
    endScreening(date, hall, soldTickets) {
        let screeneing = this.getScreening(date, hall);
        if (!screeneing) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`)
        }

        soldTickets = Number(soldTickets);
        let currentProfit = soldTickets * this.ticketPrice;
        this.totalProfit += currentProfit;
        this.totalSoldTickets += soldTickets

        this.screenings = this.screenings.filter(s => s != screeneing);

        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`
    }

    toString() {
        let result = [];
        result.push(`${this.movieName} full information:`)
        result.push(`Total profit: ${(this.totalProfit).toFixed(0)}$`)
        result.push(`Sold Tickets: ${this.totalSoldTickets}`)

        if (this.screenings.length > 0) {
            result.push(`Remaining film screenings:`)

            this.screenings
                .sort((curr, next) => curr.hall.localeCompare(next.hall))
                .forEach(s => result.push(`${s.hall} - ${s.date} - ${s.description}`))

        } else {
            result.push(`No more screenings!`)
        }

        return result.join('\n').trim();
    }


    getScreening(date, hall) {
        return this.screenings.find(s => s.date == date && s.hall == hall);
    }
}




// let m = new Movie('Wonder Woman 1984', '10.00');
// console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
// console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
// console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
// console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
// console.log(m.endScreening('October 3, 2020', 'Main', 78));
// console.log(m.toString());

// m.newScreening('October 4, 2020', '235', `regular`);
// m.newScreening('October 5, 2020', 'Main', `regular`);
// m.newScreening('October 3, 2020', '235', `regular`);
// m.newScreening('October 4, 2020', 'Main', `regular`);
// console.log(m.toString());



// New screening of Wonder Woman 1984 is added.
// New screening of Wonder Woman 1984 is added.
// New screening of Wonder Woman 1984 is added.
// Wonder Woman 1984 movie screening on October 2, 2020 in IMAX 3D hall has ended. Screening profit: 1500
// Wonder Woman 1984 movie screening on October 3, 2020 in Main hall has ended. Screening profit: 780
// Wonder Woman 1984 full information:
// Total profit: 2280$
// Sold Tickets: 228
// Remaining film screenings:
// IMAX 3D - October 4, 2020 - 3D
// Wonder Woman 1984 full information:
// Total profit: 2280$
// Sold Tickets: 228
// Remaining film screenings:
// 235 - October 4, 2020 - regular
// 235 - October 3, 2020 - regular
// IMAX 3D - October 4, 2020 - 3D
// Main - October 5, 2020 - regular
// Main - October 4, 2020 - regular
