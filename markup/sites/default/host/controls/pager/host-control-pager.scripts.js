app['/host/controls/pager/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--pager';
    var _ID_ELEMENT_NEXT = 'app--id--host--control--pager--next';
    var _ID_ELEMENT_PREV = 'app--id--host--control--pager--prev';

    function start(index, containerId, key, funcSetup, funcRender, funcNext) {
        var _control = {
            elementId: _ID_ELEMENT + index,
            elementPrevId: _ID_ELEMENT_PREV + index,
            elementNextId: _ID_ELEMENT_NEXT + index,
            index: index,
            key: key,
            next: next,
            pageNumber: 1,
            prev: prev
        };

        var _query = (function () {
            var _current = null;

            var _paramPageNumber = (function () {
                var _name = 'page-number';
                var _value = 1;

                function getName() {
                    return _name;
                }

                function getValue() {
                    return _value;
                }

                function init(query) {
                    _name += _control.key;

                    if (query.hasParameter(_name)) {
                        _value = window.parseInt(query.getParameterFirstValue(_name));
                    }
                }

                return {
                    getName: getName,
                    getValue: getValue,
                    init: init
                };
            })();

            function getCurrent() {
                return _current;
            }

            function init() {
                _current = app.query.get();

                _paramPageNumber.init(_current);
            }

            return {
                getCurrent: getCurrent,
                init: init,
                paramPageNumber: _paramPageNumber
            };
        })();

        function init(funcNext) {
            _query.init();

            _control.pageNumber = _query.paramPageNumber.getValue();

            funcSetup(_control, funcNext);
        }

        function next() {
            refresh(++_control.pageNumber);
        }

        function prev() {
            if (_control.pageNumber > 1) {
                refresh(--_control.pageNumber);
            }
        }

        function refresh(value) {
            var query = app.query.get();

            query.parameters[_query.paramPageNumber.getName()] = [value];

            app.query.set(query);
        }

        app.data.load(
            'host/controls/pager/host-control-pager.template.html',
            function (data, funcNext) {
                var reElement = new RegExp('"' + _ID_ELEMENT + '"', 'g');
                var reElementNext = new RegExp('"' + _ID_ELEMENT_NEXT + '"', 'g');
                var reElementPrev = new RegExp('"' + _ID_ELEMENT_PREV + '"', 'g');

                data = data.replace(
                    reElement,
                    _control.elementId
                ).replace(
                    reElementNext,
                    _control.elementNextId
                ).replace(
                    reElementPrev,
                    _control.elementPrevId
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
