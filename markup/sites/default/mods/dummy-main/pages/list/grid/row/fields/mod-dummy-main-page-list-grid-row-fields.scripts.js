app['/mods/dummy-main/pages/list/grid/row/fields/'] = (function () {
    var _ID_ELEMENT_IDENTIFIER = 'mod--dummy-main--page--list--grid--row--field--identifier';
    var _ID_ELEMENT_MANY_TO_MANY = 'mod--dummy-main--page--list--grid--row--field--many-to-many';
    var _ID_ELEMENT_ONE_TO_MANY = 'mod--dummy-main--page--list--grid--row--field--one-to-many';

    function start(index, containerId, funcSetup, funcNext) {
        var _control = {
            elementIdentifierId: _ID_ELEMENT_IDENTIFIER + index,
            elementManyToManyId: _ID_ELEMENT_MANY_TO_MANY + index,
            elementOneToManyId: _ID_ELEMENT_ONE_TO_MANY + index,
            index: index,
            setIdentifier: setIdentifier,
            setManyToMany: setManyToMany,
            setOneToMany: setOneToMany
        };

        function init(funcNext) {
            funcSetup(_control, funcNext);
        }

        function setIdentifier(text) {
            function setup(controlField) {
                controlField.set(text);
            }

            app['/host/controls/grid/row/field/text/'].start(
                index + '--identifier',
                _control.elementIdentifierId,
                setup,
                app.html.setToEnd
            );
        }

        function setManyToMany(values) {
            if (values) {
                var len = values.length;

                if (len > 0) {
                    var funcs = [];

                    for (var i = 0; i < len; i++) {
                        funcs.push(
                            (function () {
                                var currentIndex = i;

                                return function (funcNext) {
                                    function setup(controlField, funcNext) {
                                        var value = values[currentIndex];

                                        controlField.set(value.text, value.href);

                                        if (currentIndex < len - 1) {
                                            app.css.add([
                                                controlField.elementId
                                            ], [
                                                'skin--css--core--content--comma'
                                            ]);
                                        }

                                        funcNext();
                                    }

                                    app['/host/controls/grid/row/field/link/'].start(
                                        index + '--many-to-many' + currentIndex,
                                        _control.elementManyToManyId,
                                        setup,
                                        app.html.setToEnd,
                                        funcNext
                                    );
                                };
                            })()
                        );
                    }

                    app.sync(funcs);
                }
            } else {
                app['/host/controls/grid/row/field/nones/'].start(
                    _control.elementManyToManyId,
                    app.html.setToEnd
                );
            }
        }

        function setOneToMany(text, href) {
            function setup(controlField, funcNext) {
                controlField.set(text, href);

                funcNext();
            }

            if (text) {
                app['/host/controls/grid/row/field/link/'].start(
                    index + '--one-to-many',
                    _control.elementOneToManyId,
                    setup,
                    app.html.setToEnd
                );
            } else {
                app['/host/controls/grid/row/field/none/'].start(
                    _control.elementOneToManyId,
                    app.html.setToEnd
                );
            }
        }

        app.data.load(
            'mods/dummy-main/pages/list/grid/row/fields/mod-dummy-main-page-list-grid-row-fields.template.html',
            function (data, funcNext) {
                var reElementIdentifier =  new RegExp('"' + _ID_ELEMENT_IDENTIFIER+ '"', 'g');
                var reElementManyToMany =  new RegExp('"' + _ID_ELEMENT_MANY_TO_MANY+ '"', 'g');
                var reElementOneToMany =  new RegExp('"' + _ID_ELEMENT_ONE_TO_MANY+ '"', 'g');

                data = data.replace(
                    reElementIdentifier,
                    _control.elementIdentifierId
                ).replace(
                    reElementManyToMany,
                    _control.elementManyToManyId
                ).replace(
                    reElementOneToMany,
                    _control.elementOneToManyId
                );

                var containers = {};

                containers[containerId] = [
                    data,
                    init,
                    funcNext
                ];

                app.html.set(containers);
            },
            funcNext
        );
    }

    return {
        start: start
    }
})();
