app['/host/controls/query-panel/sorter/field/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--query-panel--sorter--field';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementId: _ID_ELEMENT + index,
            index: index,
            set: set
        };

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function set(attrValue, text, attrSelectedIsNeeded) {
            var values = {};

            var value = {
                html: text,
                attr: {
                    value: attrValue
                }
            };

            if (attrSelectedIsNeeded === true) {
                value.attr.selected = '';
            }

            values[_control.elementId] = [value];

            app.html.set(values);
        }

        app.data.load(
            'host/controls/query-panel/sorter/field/host-control-query-panel-sorter-field.template.html',
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
