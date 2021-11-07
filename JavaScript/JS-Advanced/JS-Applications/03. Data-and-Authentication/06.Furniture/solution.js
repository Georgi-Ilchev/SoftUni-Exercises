function solve() {
  const baseUrl = 'http://localhost:3030/data/furniture';
  const token = sessionStorage.getItem('auth_token');
  const furnitureList = document.getElementById('table-body'); // homeLogged.html -> 54 row

  console.log(token);
  //furniture list removing tr

  loadFurniture();

  const loginForm = document.querySelector('div form[action="/login"]'); // login.html -> 44 row
  if (loginForm) {
    loginForm.addEventListener('submit', onLoginHandler);
  }

  const registerForm = document.querySelector('div form[action="/register"]'); //login.html -> 36 row
  if (registerForm) {
    registerForm.addEventListener('submit', onRegisterHandler);
  }

  const logoutBtn = document.getElementById('logoutBtn'); // homeLogged.html -> 15 row

  console.log(logoutBtn);
  console.log('here');
  // logoutBtn.addEventListener('click', onLogoutHandler);

  const createBtn = document.querySelector('#createForm button');
  createBtn.addEventListener('click', createFurniture);



  async function onLoginHandler(e) {
    console.log('login');
    e.preventDefault();

    const formData = new FormData(e.target); // currentTarget?
    const email = formData.getItem('email');
    const password = formData.getItem('password');

    const body = JSON.stringify({
      email,
      password
    });

    try {
      const response = await fetch('http://localhost:3030/users/login', {
        methd: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body
      });

      const data = await response.json();

      if (response.ok !== true) {
        const message = data.message
          .split('Login')
          .filter(x => x !== '')
          .map(x => 'Email' + x);

        throw new Error(message);
      }

      sessionStorage.setItem('auth_token', data.accessToken);
      sessionStorage.setItem('userId', data._id);

      window.location = '/homeLogged.html';
    } catch (error) {
      alert(error.message);
    }
  }

  async function onRegisterHandler(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (password !== rePass) {
      alert('Passwords does not match');
      return;
    }

    const body = JSON.stringify({
      email,
      password
    });

    console.log('opa');

    try {
      const response = await fetch('http://localhost:3030/users/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body
      });

      const data = await response.json();

      if (response.ok !== true) {
        throw new Error(data.message);
      }

      sessionStorage.setItem('auth_token', data.accessToken);
      sessionStorage.setItem('userId', data._id);

      window.location.pathname = '06.Furniture/homeLogged.html';
    } catch (error) {
      alert(error.message);
    }
  }

  async function onLogoutHandler() {
    try {
      const response = await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
          'X-Authorization': token
        }
      });

      if (response.ok != true) {
        throw new Error('User session does not exist!');
      }

      sessionStorage.removeItem('auth_token');
      sessionStorage.removeItem('userId');
    } catch (error) {
      alert(error.message);
    }

    window.location = '/home.html';
  }

  async function loadFurniture() {
    const response = await fetch(baseUrl);
    const result = await response.json();

    result.forEach(el => {
      let trElement =
        e('tr', {},
          e('td', {},
            e('img', { src: el.img }, '')),
          e('td', {},
            e('p', {}, el.name)),
          e('td', {},
            e('p', {}, el.price)),
          e('td', {},
            e('p', {}, el.decFactor)),
          e('td', {},
            e('input', { type: 'checkbox' })));

      furnitureList.appendChild(trElement);
    });

  }

  async function createFurniture(e) {
    e.preventDefault();

    const form = e.target.parentElement;
    const formData = new FormData(form);

    let name = formData.get('name');
    let price = formData.get('price');
    let factor = formData.get('factor');
    let img = formData.get('img');

    if (name.trim() === '' ||
      price.trim() === '' ||
      isNaN(price) ||
      factor.trim() === '' ||
      img.trim() === '') {
      return;
    }

    let body = JSON.stringify({
      _ownerId: sessionStorage.getItem('userId'),
      name,
      price,
      factor,
      img,
    });

    fetch(baseUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'X-Authorization': token
      },
      body
    })
      .then(data => {
        form.reset();
        console.log('here');
      })
      .catch((err) => alert(err.message));
  }

  function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (const prop in attr) {
      if (prop === 'class') {
        element.classList.add(attr[prop])
      } else if (prop === 'disabled') {
        element.disabled = attr[prop];
      } else {
        element.setAttribute(prop, attr[prop]);
      }
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