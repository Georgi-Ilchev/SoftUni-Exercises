function loadRepos() {
	let repos = document.getElementById('repos');
	let username = document.getElementById('username');
	let url = `https://api.github.com/users/${username.value}/repos`;

	fetch(url)
		.then(response => {
			// console.log(response);
			if (response.ok === false) {
				throw new Error(`${response.status} ${response.statusText}`)
			}
			return response.json();
		})
		.then(handleResponse)
		.catch(handleError);

	function handleResponse(data) {
		repos.innerHTML = '';

		for (const repo of data) {
			const liElement = document.createElement('li');
			liElement.innerHTML = `<a href="${repo.html_url}">
	${repo.full_name}
</a>`;

			repos.appendChild(liElement);
		}
	}

	function handleError(error) {
		repos.innerHTML = '';
		repos.textContent = `${error.message}`;
	}
}