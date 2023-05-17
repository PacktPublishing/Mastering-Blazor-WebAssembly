function showAlert(name) {
    alert('Hello ' + name);
}


function callStaticCsharpMethod() {
    // DotNet is a built-in object in Blazor
    DotNet.invokeMethodAsync('BooksStore', 'Sum', 3, 5)
        .then(data => {
            console.log('3 + 5 = ' + data);
        });
}

function triggerOnWindowResized(dotnetObjRef) {
    // Subscribe to the window.onresize event and trigger a method that will trigger the .NET method and pass the width and height as a parameters to it
    window.onresize = function () {
        dotnetObjRef.invokeMethodAsync('OnWindowResized', window.innerWidth, window.innerHeight);
    }
}