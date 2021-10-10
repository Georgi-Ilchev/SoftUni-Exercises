function ticketsCreating(description, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (const currentTicket of description) {
        let token = currentTicket.split('|');

        let destination = token[0];
        let price = Number(token[1]);
        let status = token[2];

        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    let sort = {
        'destination': (x) => x.sort((a, b) => a.destination.localeCompare(b.destination)),
        'price': (x) => x.sort((a, b) => a.price - b.price),
        'status': (x) => x.sort((a, b) => a.status.localeCompare(b.status)),
    }
    return sort[criteria](tickets);
}

ticketsCreating(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
)