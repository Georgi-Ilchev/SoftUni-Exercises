let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView() {
    return section;
}

let addMoviePage = {
    initialize,
    getView
};

export default addMoviePage;