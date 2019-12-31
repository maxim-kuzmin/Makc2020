app['/host/layout/header/'] = (function () {
    var _languageSelector = (function () {
        function load() {
            app.html.load({
                'app--id--host--layout--header--language-selector': [
                    'host/controls/language-selector/host-control-language-selector.template.html'
                ]
            });
        }

        return {
            load: load
        };
    })();

    function start() {
        _languageSelector.load();
    }

    return {
        start: start
    };
})();
