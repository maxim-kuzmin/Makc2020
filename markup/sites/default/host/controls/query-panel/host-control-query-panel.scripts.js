app['/host/controls/query-panel/'] = (function () {
    var _ID_ELEMENT_FILTER_FIELDS = 'app--id--host--control--query-panel--filter--fields';
    var _ID_ELEMENT_FILTER_LABEL = 'app--id--host--control--query-panel--filter--label';
    var _ID_ELEMENT_FORM = 'app--id--host--control--query-panel--form';
    var _ID_ELEMENT_SORTER_FIELDS = 'app--id--host--control--query-panel--sorter--fields';
    var _ID_ELEMENT_SORTER_LABEL = 'app--id--host--control--query-panel--sorter--label';
    var _ID_ELEMENT_SWITCH_HIDE = 'app--id--host--control--query-panel--switch--hide';
    var _ID_ELEMENT_SWITCH_SHOW = 'app--id--host--control--query-panel--switch--show';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementFilterFieldsId: _ID_ELEMENT_FILTER_FIELDS + index,
            elementFilterLabelId: _ID_ELEMENT_FILTER_LABEL + index,
            elementFormId: _ID_ELEMENT_FORM + index,
            elementSorterFieldsId: _ID_ELEMENT_SORTER_FIELDS + index,
            elementSorterLabelId: _ID_ELEMENT_SORTER_LABEL + index,
            elementSwitchHideId: _ID_ELEMENT_SWITCH_HIDE + index,
            elementSwitchShowId: _ID_ELEMENT_SWITCH_SHOW + index,
            index: index,
            isShown: false,
            actionClick: actionClick,
            addFilterFieldInputText: addFilterFieldInputText,
            addSortField: addSortField,
            hide: hide,
            show: show
        };

        var _notifications = (function () {
            var _controlNotificationError;
            var _controlNotificationSuccess;

            function getControlNotificationError() {
                return _controlNotificationError;
            }

            function getControlNotificationSuccess() {
                return _controlNotificationSuccess;
            }

            function setup(controlNotificationError, controlNotificationSuccess, funcNext) {
                _controlNotificationError = controlNotificationError;
                _controlNotificationSuccess = controlNotificationSuccess;

                funcNext();
            }

            function load(funcNext) {
                app['/host/controls/notifications/'].start(
                    index + '--query-panel',
                    _control.elementFormId,
                    setup,
                    app.html.setToEnd,
                    funcNext
                );
            }

            return {
                getControlNotificationError: getControlNotificationError,
                getControlNotificationSuccess: getControlNotificationSuccess,
                load: load
            };
        })();

        var _query = (function () {
            var _current = null;

            var _paramIsQueryPanelShown = (function () {
                var _name = 'is-query-panel-shown';
                var _value = false;

                function getName() {
                    return _name;
                }

                function getValue() {
                    return _value;
                }

                function init(query) {
                    _name += _control.index;

                    _value = query.hasParameter(_name) && query.getParameterFirstValue(_name) === 'true';
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

                _paramIsQueryPanelShown.init(_current);
            }

            return {
                getCurrent: getCurrent,
                init: init,
                paramIsQueryPanelShown: _paramIsQueryPanelShown
            };
        })();

        function actionClick() {
            app.visibility.toggle([
                _notifications.getControlNotificationError().elementId,
                _notifications.getControlNotificationSuccess().elementId
            ]);
        }

        function addFilterFieldInputText(inputAttrName, inputAttrValue, labelText, funcNext) {
            function setup(controlField, funcNext) {
                controlField.set(inputAttrName, inputAttrValue, labelText);

                funcNext();
            }

            app['/host/controls/query-panel/filter/field/input/text/'].start(
                _control.index + '--' + inputAttrName,
                _control.elementFilterFieldsId,
                setup,
                app.html.setToEnd,
                funcNext
            );
        }

        function addSortField(attrValue, text, attrSelectedIsNeeded, funcNext) {
            function setup(controlField, funcNext) {
                controlField.set(attrValue, text, attrSelectedIsNeeded);

                funcNext();
            }

            app['/host/controls/query-panel/sorter/field/'].start(
                _control.index + '--' + attrValue,
                _control.elementSorterFieldsId,
                setup,
                app.html.setToEnd,
                funcNext
            );
        }

        function hide() {
            refresh('false');
        }

        function init(funcNext) {
            _query.init();

            _control.isShown = _query.paramIsQueryPanelShown.getValue();

            if (_control.isShown) {
                app.visibility.off([
                    _control.elementSwitchShowId
                ]);
            } else {
                app.visibility.off([
                    _control.elementSwitchHideId
                ]);

                app.visibility.off([
                    _control.elementFormId
                ]);
            }

            funcSetup(_control, funcNext);
        }

        function refresh(value) {
            var query = app.query.get();

            query.parameters[_query.paramIsQueryPanelShown.getName()] = [value];

            app.query.set(query);
        }

        function show() {
            refresh('true');
        }

        app.data.load(
            'host/controls/query-panel/host-control-query-panel.template.html',
            function (data, funcNext) {
                var reElementFilterFields = new RegExp('"' + _ID_ELEMENT_FILTER_FIELDS + '"', 'g');
                var reElementFilterLabel = new RegExp('"' + _ID_ELEMENT_FILTER_LABEL + '"', 'g');
                var reElementForm = new RegExp('"' + _ID_ELEMENT_FORM + '"', 'g');
                var reElementSorterFields = new RegExp('"' + _ID_ELEMENT_SORTER_FIELDS + '"', 'g');
                var reElementSorterLabel = new RegExp('"' + _ID_ELEMENT_SORTER_LABEL + '"', 'g');
                var reElementSwitchHide = new RegExp('"' + _ID_ELEMENT_SWITCH_HIDE + '"', 'g');
                var reElementSwitchShow = new RegExp('"' + _ID_ELEMENT_SWITCH_SHOW + '"', 'g');

                data = data.replace(
                    reElementFilterFields,
                    _control.elementFilterFieldsId
                ).replace(
                    reElementFilterLabel,
                    _control.elementFilterLabelId
                ).replace(
                    reElementForm,
                    _control.elementFormId
                ).replace(
                    reElementSorterFields,
                    _control.elementSorterFieldsId
                ).replace(
                    reElementSorterLabel,
                    _control.elementSorterLabelId
                ).replace(
                    reElementSwitchHide,
                    _control.elementSwitchHideId
                ).replace(
                    reElementSwitchShow,
                    _control.elementSwitchShowId
                );

                var containers = {};

                containers[containerId] = [
                    data,
                    init,
                    _notifications.load,
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
