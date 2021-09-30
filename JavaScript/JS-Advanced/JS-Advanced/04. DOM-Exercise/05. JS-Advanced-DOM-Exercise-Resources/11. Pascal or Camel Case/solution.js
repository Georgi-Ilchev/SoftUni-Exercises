function solve() {
  const text = document.getElementById('text').value;
  const namingConvention = document.getElementById('naming-convention').value;

  let result = document.getElementById('result');
  let resultString = "";

  const splitted = text.split(' ');

  if (namingConvention == 'Pascal Case') {
    for (let i = 0; i < splitted.length; i++) {
      resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[i].length).toLowerCase();
    }
  } else if (namingConvention == 'Camel Case') {
    resultString += splitted[0][0].toLowerCase() + splitted[0].slice(1, splitted[0].length).toLowerCase();
    for (let i = 1; i < splitted.length; i++) {
      resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[i].length).toLowerCase();
    }
  } else {
    result.textContent = 'Error!';
    return;
  }

  result.textContent = resultString;
}