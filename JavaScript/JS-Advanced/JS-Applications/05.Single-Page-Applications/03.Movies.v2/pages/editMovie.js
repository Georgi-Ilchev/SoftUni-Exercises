let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView() {
    return section;
}

let editMoviePage = {
    initialize,
    getView
};

export default editMoviePage;