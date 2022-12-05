var simplemde
function initializeMarkdownEditor() {
     simplemde = new SimpleMDE();
}

function getMarkdownEditorValue() {
    if (simplemde != null)
        return simplemde.value();
    return '';
}

function setMarkdownEditorValue(value) {
    if (simplemde != null)
        simplemde.value(value);
}