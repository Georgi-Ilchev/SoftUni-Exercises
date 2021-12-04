import { createGame, editGame, getGameById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const editTemplate = (game, onSubmit) => html`
<section id="edit-page" class="auth">
    <form @submit=${onSubmit} id="edit">
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" .value=${game.title}>

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" .value=${game.category}>

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${game.maxLevel}>

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" .value=${game.imageUrl}>

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary" .value=${game.summary}></textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>`;

export async function editPage(ctx) {
    const game = await getGameById(ctx.params.id);
    const userData = getUserData();

    if (game._ownerId != userData.id) {
        ctx.page.redirect('/');
        return;
    }

    ctx.render(editTemplate(game, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        const title = formData.get('title').trim();
        const category = formData.get('category').trim();
        const maxLevel = formData.get('maxLevel').trim();
        const imageUrl = formData.get('imageUrl').trim();
        const summary = formData.get('summary').trim();

        if (title == '' || category == '' || maxLevel == ''
            || imageUrl == '' || summary == '') {
            return alert('All fields are required!');
        }

        await editGame(game._id, { title, category, maxLevel, imageUrl, summary });
        ctx.page.redirect('/details/' + game._id);
    }
}