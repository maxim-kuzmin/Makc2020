app['/host/controls/grid/row/action/button/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--grid--row--action--button';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementId: _ID_ELEMENT + index,
            index: index,
            set: set
        };

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function set(text, onclick) {
            var values = {};

            var value = {
                html: text
            };

            if (onclick) {
                value.attr = {
                    onclick: onclick
                };
            }

            values[_control.elementId] = [value];

            app.html.set(values);
        }

        app.data.load(
            'host/controls/grid/row/action/button/host-control-grid-row-action-button.template.html',
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
