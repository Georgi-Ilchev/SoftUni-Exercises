function editElement(reference, match, replacer) {
    const content = reference.textContent;
    const matcher = RegExp(match, 'g');
    const edit = content.replace(matcher, replacer);

    reference.textContent = edit;
}