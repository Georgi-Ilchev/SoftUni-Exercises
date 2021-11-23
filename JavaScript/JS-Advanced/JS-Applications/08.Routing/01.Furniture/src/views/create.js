import { createItem } from '../api/data.js';
import { html } from '../lib.js';

const createTemplate = (onSubmit, errorMsg, errors) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control' + (errors.make ? ' is-invalid' : '')} id="new-make" type="text" name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (errors.model ? ' is-invalid' : '')} id="new-model" type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (errors.year ? ' is-invalid' : '')} id="new-year" type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (errors.description ? ' is-invalid' : '')} id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (errors.price ? ' is-invalid' : '')} id="new-price" type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (errors.img ? ' is-invalid' : '')} id="new-image" type="text" name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Create" />
        </div>
    </div>
</form>`;

export function createPage(ctx) {
    update(null, {});

    async function onSubmit(ev) {
        ev.preventDefault();
        const formData = [...(new FormData(ev.target)).entries()];
        const data = formData.reduce((a, [key, val]) => Object.assign(a, { [key]: val.trim() }), {});

        const missing = formData.filter(([k, v]) => k != 'material' && v.trim() == '');

        try {
            if (missing.length > 0) {
                const errors = missing.reduce((a, [k]) => Object.assign(a, { [k]: true }), {});
                throw {
                    error: new Error('Please fill all mandatory fields!'),
                    errors
                };
            }

            if (data.make.length < 4 || data.model.length < 4) {
                console.log(data.make);
                console.log(data.model);
                return alert('Make and Model should be 4 symbols at least!');
            }

            if (data.description.length < 10) {
                console.log(data.description);
                return alert('Description should be 10 symbols at least!');
            }

            if (data.img.length == 0) {
                console.log(data.img);
                return alert('Image is required!');
            }

            data.year = Number(data.year);
            data.price = Number(data.price);

            if (data.year < 1950 || data.year > 2050) {
                return alert('Year should be between 1950 and 2050');
            }

            if (data.price < 0) {
                return alert('Price should be a positive number');
            }

            const result = await createItem(data);
            ev.target.reset();
            ctx.page.redirect('/details/' + result._id);
        } catch (err) {
            const message = err.message || err.error.message;
            update(message, err.errors || {});
        }
    }

    function update(errorMsg, errors) {
        ctx.render(createTemplate(onSubmit, errorMsg, errors));
    }
}