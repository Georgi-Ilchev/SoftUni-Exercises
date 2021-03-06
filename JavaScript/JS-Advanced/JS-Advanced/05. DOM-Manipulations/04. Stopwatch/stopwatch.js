function stopwatch() {
    let timerElement = document.getElementById('time');
    let startButtonElement = document.getElementById('startBtn');
    let stopButtonElement = document.getElementById('stopBtn');
    let interval;

    //start
    startButtonElement.addEventListener('click', function (e) {
        timerElement.textContent = '00:00';

        stopButtonElement.removeAttribute('disabled');
        e.currentTarget.setAttribute('disabled', true);

        interval = setInterval(function () {
            let currentTime = timerElement.textContent;
            let [minutes, seconds] = currentTime.split(':');
            minutes = Number(minutes);
            seconds = Number(seconds);

            seconds++;

            if (seconds > 59) {
                minutes++;
                seconds = 0;
            }
            timerElement.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
        }, 1000);
    });

    //stop
    stopButtonElement.addEventListener('click', function (e) {
        clearInterval(interval);

        e.currentTarget.setAttribute('disabled', true);
        startButtonElement.removeAttribute('disabled');
    });
}