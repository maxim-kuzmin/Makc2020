app['/host/controls/grid/row/field/text/'] = (function () {
    function start(index, containerId, funcSetup, funcRender, funcNext) {
        app.data.load(
            'host/controls/grid/row/field/text/host-control-grid-row-field-text.template.html',
            function(data, funcNext) {
                var _control = {
                    set: set
                };

                function set(text) {
                    var reText = new RegExp('{text}', 'g');

                    data = data.replace(reText, text);
                }

                funcSetup(_control);

                var containers = {};

                containers[containerId] = [
                    data,
                    funcNext
                ];

                funcRender(containers);
            },
            funcNext
        );
    }

    return {
        start: start
    };
})();
