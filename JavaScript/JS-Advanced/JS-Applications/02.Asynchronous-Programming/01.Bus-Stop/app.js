async function getInfo() {
    const validBusses = ["1287", "1308", "1327", "2334"];
    const stopId = document.getElementById('stopId').value;
    const stopInfo = document.getElementById('stopName');
    const busesUl = document.getElementById('buses');

    if (!validBusses.includes(stopId)) {
        stopInfo.textContent = `Error`;
        busesUl.textContent = '';
        return;
    }

    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    stopInfo.textContent = 'Loading...';
    busesUl.replaceChildren();
    const res = await fetch(url);
    const data = await res.json();


    stopInfo.textContent = data.name;

    Object.keys(data.buses).forEach(id => {
        const li = document.createElement('li');
        li.textContent = `Bus ${id} arrives in ${data.buses[id]} minutes`;

        busesUl.appendChild(li);
    })

    busId = '';
}