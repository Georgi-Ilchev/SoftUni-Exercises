import { deleteGame, getComments, getGameById, postComment } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (game, isOwner, onDelete, comments, showCommentBtn, onComment) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>
        <p class="text">${game.summary}</p>

        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
                ${comments.length == 0 
                    ? html`<p class="no-comment">No comments.</p>`
                    : html`${comments.map(commentTemplate)}`}
            </ul>
        </div>

        ${isOwner 
            ? html`
                <div class="buttons">
                    <a href="/edit/${game._id}" class="button">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
                </div>` 
            : null}
    </div>

     ${postCommentTemplate(showCommentBtn, onComment)}

</section>`;

const commentTemplate = (comment) => html`
<li class="comment">
    <p>Content: ${comment.comment}</p>
</li>`;

const postCommentTemplate = (showCommentBtn, onComment) => {
    if (showCommentBtn) {
        return html`
        <article class="create-comment">
            <label>Add new comment:</label>
            <form @submit=${onComment} class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>`;
    } else {
        return null;
    }
};


export async function detailsPage(ctx) {
    const [game, comments] = await Promise.all([
        getGameById(ctx.params.id),
        getComments(ctx.params.id)
    ]);

    const userData = getUserData();
    const isOwner = userData && game._ownerId == userData.id;
    const showCommentBtn = 
        userData != null &&
        isOwner == false;

    ctx.render(detailsTemplate(game, isOwner, onDelete, comments, showCommentBtn, onComment));

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete ${game.title}`);

        if (choice) {
            await deleteGame(ctx.params.id);
            ctx.page.redirect('/');
        }
    }

    async function onComment(ev){
        ev.preventDefault();
        const formData = new FormData(ev.target);
        const comment = formData.get('comment').trim();
        const gameId = ctx.params.id;

        if (comment == '') {
            return alert('Comment box should be filled!');
        }

        await postComment({comment, gameId});

        ev.target.reset();
        ctx.page.redirect('/details/' + ctx.params.id);
    }
}