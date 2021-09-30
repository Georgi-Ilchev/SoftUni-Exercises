function solve() {
  const correctAnswers = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];
  let correctAnswered = 0;
  let index = 0;

  Array
    .from(document.querySelectorAll('.answer-text'))
    .map((x) => x.addEventListener('click', answerChecking));

  function answerChecking(ev) {
    if (correctAnswers.includes(ev.target.innerHTML)) {
      correctAnswered++;
    }

    let currentQuestion = document.querySelectorAll('section')[index];
    currentQuestion.style.display = 'none';

    if (document.querySelectorAll('section')[index + 1] !== undefined) {
      let nextQuestion = document.querySelectorAll('section')[index + 1];
      nextQuestion.style.display = 'block';
      index++;
    } else {
      document.querySelector('#results').style.display = 'block';

      if (correctAnswered !== 3) {
        document.querySelector('#results h1').textContent = `You have ${correctAnswered} right answers`;
      } else {
        document.querySelector('#results h1').textContent = `You are recognized as top JavaScript fan!`;
      }
    }
  }
}
