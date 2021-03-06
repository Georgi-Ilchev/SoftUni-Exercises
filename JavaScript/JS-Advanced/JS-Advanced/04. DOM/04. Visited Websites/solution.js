function solve() {
  // let linkElements = document.getElementsByClassName('link-1');
  let linkElements = document.querySelectorAll('.link-1 a');

  for (const linkElement of linkElements) {
    linkElement.addEventListener('click', onLinkElementClick);
  }

  function onLinkElementClick(e) {
    let paragraphElement = e.currentTarget.nextElementSibling;
    let visitedCount = Number(paragraphElement.innerText.split(' ')[1])
    visitedCount++;

    paragraphElement.innerText = `visited ${visitedCount} times`;
  }
}