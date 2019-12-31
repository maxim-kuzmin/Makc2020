app['/host/layout/footer/'] = (function () {
    var content = (function () {
        function init() {
            app.html.replace({
                'app--id--host--layout--footer--content': [
                    '{{year}}',
                    new Date().getFullYear()
                ]
            });
        }

        function load() {
            app.html.load({
                'app--id--host--layout--footer--content': [
                    'assets/host/layout/footer/asset-host-layout-footer.content.html',
                    init
                ]
            });
        }

        return {
            load: load
        };
    })();

    function start() {
        content.load();
    }

    return {
        start: start
    };
})();
