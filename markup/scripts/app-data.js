app.data = (function () {
    function load(path, callback, funcNext) {
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                callback(this.responseText, funcNext);
            }
        };

        xhttp.open("GET", path, true);

        xhttp.send();
    }

    return {
        load: load
    };
})();
