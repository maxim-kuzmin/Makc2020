app.page = (function () {
    function create(path) {
        function load(parameters) {
            var query = app.query.create(parameters);

            query.paramPath.set(path);

            app.query.set(query);
        }

        return {
            path: path,
            load: load
        };
    }

    return {
        create: create
    };
})();
