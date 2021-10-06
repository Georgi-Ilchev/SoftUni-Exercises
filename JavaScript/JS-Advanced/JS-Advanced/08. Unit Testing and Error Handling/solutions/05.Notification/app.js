function notify(message) {
  const result = document.querySelector('#notification');
  
  result.style.display = 'block';
  result.textContent = message;

  result.addEventListener('click', () => {
    result.style.display = 'none';
  })
}