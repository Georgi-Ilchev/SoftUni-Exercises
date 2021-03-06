function attachEventsListeners() {
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    document.getElementById('daysBtn').addEventListener('click', () => { convert(+days.value * 86400) });
    document.getElementById('hoursBtn').addEventListener('click', () => { convert(+hours.value * 3600) });
    document.getElementById('minutesBtn').addEventListener('click', () => { convert(+minutes.value * 60) });
    document.getElementById('secondsBtn').addEventListener('click', () => { convert(+seconds.value) });

    function convert(sec) {
        let day = sec / 86400;
        let hour = sec / 3600;
        let minute = sec / 60;

        days.value = day;
        hours.value = hour;
        minutes.value = minute;
        seconds.value = sec;
    }
}