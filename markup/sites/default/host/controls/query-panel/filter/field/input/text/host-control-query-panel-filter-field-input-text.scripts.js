app['/host/controls/query-panel/filter/field/input/text/'] = (function () {
    var _ID_ELEMENT_INPUT = 'app--id--control--query-panel--filter--field--input--text--input';
    var _ID_ELEMENT_LABEL = 'app--id--control--query-panel--filter--field--input--text--label';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementInputId: _ID_ELEMENT_INPUT + index,
            elementLabelId: _ID_ELEMENT_LABEL + index,
            index: index,
            set: set
        };

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function set(inputAttrName, inputAttrValue, labelText) {
            var values = {};

            values[_control.elementLabelId] = [{
                html: labelText,
                attr: {
                    for: _control.elementInputId
                }
            }];

            values[_control.elementInputId] = [{
                attr: {
                    name: inputAttrName,
                    value: inputAttrValue
                }
            }];

            app.html.set(values);
        }

        app.data.load(
            'host/controls/query-panel/filter/field/input/text/host-control-query-panel-filter-field-input-text.template.html',
            function (data, funcNext) {
                var reElementInput =  new RegExp('"' + _ID_ELEMENT_INPUT+ '"', 'g');
                var reElementLabel =  new RegExp('"' + _ID_ELEMENT_LABEL+ '"', 'g');

                data = data.replace(
                    reElementInput,
                    _control.elementInputId
                ).replace(
                    reElementLabel,
                    _control.elementLabelId
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
