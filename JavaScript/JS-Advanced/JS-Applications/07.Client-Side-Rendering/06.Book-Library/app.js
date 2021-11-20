import { showCatalog } from './src/catalog.js';
import { showCreate } from './src/create.js';
import { showUpdate } from './src/update.js';
import { render } from './src/api.js';

const root = document.body;
const ctx = {
    update
};

update();

function update() {
    render([
        showCatalog(ctx),
        showCreate(ctx),
        showUpdate(ctx)
    ], root);
}