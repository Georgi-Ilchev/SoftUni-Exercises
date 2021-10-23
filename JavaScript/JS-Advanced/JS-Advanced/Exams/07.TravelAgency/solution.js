window.addEventListener('load', solution);

function solution() {
  let name = document.getElementById('fname');
  let email = document.getElementById('email');
  let phone = document.getElementById('phone');
  let address = document.getElementById('address');
  let code = document.getElementById('code');

  let submitBtn = document.getElementById('submitBTN');
  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');

  let previewList = document.getElementById('infoPreview');
  let block = document.getElementById('block');

  submitBtn.addEventListener('click', preview);

  function preview(ev) {
    if (name.value.trim() != '' && email.value.trim() != '') {

      ev.target.disabled = true;

      previewList.innerHTML = `<li>Full Name: ${name.value.trim()}</li>
      <li>Email: ${email.value.trim()}</li>
      <li>Phone Number: ${phone.value.trim()}</li>
      <li>Address: ${address.value.trim()}</li>
      <li>Postal Code: ${code.value.trim()}</li>`;

      name.value = '';
      email.value = '';
      phone.value = '';
      address.value = '';
      code.value = '';

      editBtn.disabled = false;
      continueBtn.disabled = false;

      editBtn.addEventListener('click', editInfo);
      continueBtn.addEventListener('click', endTask);
    }
  }

  function editInfo() {
    let inputs = previewList.querySelectorAll('li');

    name.value = inputs[0].innerHTML.split(': ')[1];
    email.value = inputs[1].innerHTML.split(': ')[1];
    phone.value = inputs[2].innerHTML.split(': ')[1];
    address.value = inputs[3].innerHTML.split(': ')[1];
    code.value = inputs[4].innerHTML.split(': ')[1];

    previewList.innerHTML = '';

    editBtn.disabled = true;
    continueBtn.disabled = true;
    submitBtn.disabled = false;
  }

  function endTask() {
    block.innerHTML = `<h3>Thank you for your reservation!</h3>`;
  }

  function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (let prop in attr) {
      element[prop] = attr[prop];
    }

    for (let item of content) {
      if (typeof item == 'string' || typeof item == 'number') {
        item = document.createTextNode(item);
      }
      element.appendChild(item);
    }

    return element;
  }
}