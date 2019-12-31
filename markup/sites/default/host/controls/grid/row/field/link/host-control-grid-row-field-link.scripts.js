app['/host/controls/grid/row/field/link/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--grid--row--field--link';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementId: _ID_ELEMENT + index,
            index: index,
            set: set
        };

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function set(text, href) {
            var values = {};

            var value = {
                html: text
            };

            if (href) {
                value.attr = {
                    href: href
                };
            }

            values[_control.elementId] = [value];

            app.html.set(values);
        }

        app.data.load(
            'host/controls/grid/row/field/link/host-control-grid-row-field-link.template.html',
            function(data, funcNext) {
                var reElement =  new RegExp('"' + _ID_ELEMENT+ '"', 'g');

                data = data.replace(
                    reElement,
                    _control.elementId
                );

                var containers = {};

                containers[containerId] = [
                    data,
                    init,
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
