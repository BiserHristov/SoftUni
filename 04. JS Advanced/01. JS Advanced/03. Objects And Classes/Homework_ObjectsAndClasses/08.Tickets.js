function Tickets(array, criteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let ticketsCollection = [];

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        let [destination, price, status] = element.split('|');
        let currentTicket = new Ticket(destination, price, status);
        ticketsCollection.push(currentTicket);
    }
    function sortByCriteria(curr, next) {

        switch (criteria) {
            case 'price':
                return curr.price - next.price;
            default:
                return curr[criteria].localeCompare(next[criteria])
        }

    }


    ticketsCollection.sort(sortByCriteria)
    return ticketsCollection;


}

Tickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
)