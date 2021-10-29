function getInfo() {
    let validBusses = ["1287", "1308", "1327", "2334"];
    let stopId = document.getElementById('stopId');
    let stopInfo = document.getElementById('stopName');
    let busesUl = document.getElementById('buses');

    if (!validBusses.includes(stopId.value)) {
        stopInfo.textContent = 'Error';
        busesUl.textContent = '';
        return;
    }

    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json`;

    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            stopInfo.textContent = data.name;

            Object.keys(data.buses).forEach(key => {
                let li = document.createElement('li');
                li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;

                busesUl.appendChild(li);
            })
            stopId.value = '';
        });
}