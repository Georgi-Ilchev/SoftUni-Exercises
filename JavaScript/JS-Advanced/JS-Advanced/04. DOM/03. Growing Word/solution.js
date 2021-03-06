function growingWord() {
  let parentElement = document.getElementById('exercise');
  let growingWordElement = parentElement.lastElementChild;

  let colorElements = document.getElementById('colors');

  if (!growingWordElement.style.fontSize) {
    growingWordElement.style.fontSize = '2px';
  } else {
    growingWordElement.style.fontSize = parseInt(growingWordElement.style.fontSize) * 2 + 'px';
  }

  let firstColorElement = colorElements.firstElementChild;
  let color = firstColorElement.innerHTML.toLowerCase();
  growingWordElement.style.color = color;

  colorElements.appendChild(firstColorElement);
}