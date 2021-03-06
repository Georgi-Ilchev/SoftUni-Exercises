function solve(ticketDescription, sortingCriterion) {
    let tickets = [];

    ticketDescription.forEach(line => {
        let [destination, priceAsString, status] = line.split('|');
        let price = Number(priceAsString);

        tickets.push({ destination, price, status });
    });

    let sorted;
    if (sortingCriterion === 'destination') {
        sorted = tickets.sort((a, b) => a.destination.localeCompare(b.destination)
        );
    } else if (sortingCriterion === 'price') {
        sorted = tickets.sort((a, b) => a.price - b.price);

    } else {
        sorted = tickets.sort((a, b) => a.status.localeCompare(b.status)
        );
    }

    return sorted;
    //console.log(sorted);
}

console.log(solve([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(solve([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));