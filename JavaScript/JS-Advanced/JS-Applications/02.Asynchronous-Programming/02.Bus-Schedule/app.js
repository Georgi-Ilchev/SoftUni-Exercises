function solve() {
    const baseUrl = `http://localhost:3030/jsonstore/bus/schedule/`;
    let stopId = 'depot';
    let stopName;

    const info = document.getElementById('info');

    function changeButton() {
        const departBtn = document.getElementById('depart');
        const arriveBtn = document.getElementById('arrive');

        if (departBtn.disabled) {
            departBtn.disabled = false;
            arriveBtn.disabled = true;
        } else {
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        }
    }

    async function depart() {
        const url = baseUrl + stopId;

        try {
            const res = await fetch(url);
            if (res.status != 200) {
                throw new Error(`Error`);
            }

            const data = await res.json();

            info.textContent = `Next stop ${data.name}`;
            stopId = data.next;
            stopName = data.name;
        } catch (error) {
            info.textContent = error;
        }

        changeButton();
    }

    function arrive() {
        info.textContent = `Arriving at ${stopName}`;
        changeButton();
    }

    return {
        depart,
        arrive
    };
}

let result = solve();