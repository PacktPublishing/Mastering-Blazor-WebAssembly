var simplemde
function initializeMarkdownEditor() {
     simplemde = new SimpleMDE();
}

function getMarkdownEditorValue() {
    if (simplemde != null)
        return simplemde.value();
    return '';
}

function setMarkdownEditorValue(text) {
    if (simplemde != null)
        simplemde.value(text);
}