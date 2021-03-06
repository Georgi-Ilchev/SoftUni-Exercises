function attachEventsListeners() {
    let button = document.getElementById('convert');
    button.addEventListener('click', convert);

    let input = document.getElementById('inputDistance');
    let output = document.getElementById('outputDistance');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    let basedRatesInMeter = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254,
    }

    function convert() {
        let rawValue = input.value;

        // if (rawValue === '') {
        //     return;
        // }

        let value = Number(rawValue);
        // if (isNaN(value)) {
        //     return;
        // }

        let from = basedRatesInMeter[inputUnits.value];
        let to = basedRatesInMeter[outputUnits.value];

        // if (!from || !to) {
        //     return;
        // }

        let result = value * from / to;

        output.value = result;
    }
}