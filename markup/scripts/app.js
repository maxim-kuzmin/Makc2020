app = (function () {
    var _elementIds = {
        overlay:'app--id--overlay'
    };

    function end() {
        if (!app.visibility.isHidden(_elementIds.overlay)) {
            window.setTimeout(
                function () {
                    app.visibility.off([
                        _elementIds.overlay
                    ]);
                },
                250
            );
        }
    }

    function start(route) {
        var script = app[route];

        if (script) {
            if (script.start) {
                script.start(end);
            } else {
                console.error('The script "' + route + '" has no a start function');
            }
        } else {
            console.error('The route "' + route + '" has no a script');
        }
    }

    function sync(funcs) {
        var len = funcs.length;

        if (len > 0) {
            var func = funcs[0];

            if (typeof func === 'function') {
                if (len > 1) {
                    func(function () { sync(funcs.slice(1)); });
                } else if (len > 0) {
                    func(function(){});
                }
            }
        }

        return function (funcNext) {
            funcNext();
        };
    }

    return {
        start: start,
        sync: sync
    };
})();
