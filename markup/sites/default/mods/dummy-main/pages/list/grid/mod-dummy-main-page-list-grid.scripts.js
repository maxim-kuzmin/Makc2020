app['/mods/dummy-main/pages/list/grid/'] = (function () {
    var _controlsRow = [];

    var _view = (function () {
        function onDelete(index) {
            _controlsRow[index].actionClick();
        }

        return {
            onDelete: onDelete
        };
    })();

    function setup(controlGrid, funcNext) {
        var _row = (function () {
            var _actions = (function () {
                function create(controlRow, index) {
                    return (function () {
                        var _actionDelete = (function () {
                            function setup(controlAction, funcNext) {
                                controlAction.set(
                                    'Удалить',
                                    "app['/mods/dummy-main/pages/list/grid/'].view.onDelete(" + index + ")"
                                );

                                funcNext();
                            }

                            function load(funcNext) {
                                app['/host/controls/grid/row/action/button/'].start(
                                    controlRow.index + '--delete',
                                    controlRow.elementActionsId,
                                    setup,
                                    app.html.setToEnd,
                                    funcNext
                                );
                            }

                            return {
                                load: load
                            };
                        })();

                        var _actionEdit = (function () {
                            function setup(controlAction, funcNext) {
                                controlAction.set(
                                    'Изменить',
                                    "javascript:app['/'].pages.mods.modDummyMain.item.edit.load()"
                                );

                                funcNext();
                            }

                            function load(funcNext) {
                                app['/host/controls/grid/row/action/link/'].start(
                                    controlRow.index + '--edit',
                                    controlRow.elementActionsId,
                                    setup,
                                    app.html.setToEnd,
                                    funcNext
                                );
                            }

                            return {
                                load: load
                            };
                        })();

                        function load(funcNext) {
                            return app.sync([
                                _actionEdit.load,
                                _actionDelete.load,
                                funcNext
                            ]);
                        }

                        return {
                            load: load
                        };
                    })();
                }

                return {
                    create: create
                };
            })();

            var _fields = (function () {
                function create(controlRow, index) {
                    return (function () {
                        function setup(controlFields, funcNext) {
                            controlFields.setIdentifier(index);

                            if (index === 2) {
                                controlFields.setOneToMany();

                            } else {
                                controlFields.setOneToMany(
                                    'Один-ко-многим ' + index,
                                    'javascript:void(' + index + ')'
                                );
                            }

                            if (index === 2) {
                                controlFields.setManyToMany();
                            } else {
                                controlFields.setManyToMany([
                                    {
                                        text: 'Многие-ко-многим 1',
                                        href: 'javascript:void(1)'
                                    },
                                    {
                                        text: 'Многие-ко-многим 2',
                                        href: 'javascript:void(2)'
                                    },
                                    {
                                        text: 'Многие-ко-многим 3',
                                        href: 'javascript:void(3)'
                                    }
                                ]);
                            }

                            funcNext();
                        }

                        function load(funcNext) {
                            app['/mods/dummy-main/pages/list/grid/row/fields/'].start(
                                controlRow.index,
                                controlRow.elementFieldsId,
                                setup,
                                funcNext
                            );
                        }

                        return {
                            load: load
                        };
                    })();
                }

                return {
                    create: create
                };
            })();

            function create(index) {
                return (function () {
                    function setup(controlRow, funcNext) {
                        _controlsRow[index] = controlRow;

                        var actions = _actions.create(controlRow, index);

                        var fields = _fields.create(controlRow, index);

                        if (index === 1) {
                            app.css.add([
                                controlRow.elementId
                            ], [
                                'skin--css--host--control--grid__first-child'
                            ]);
                        }

                        controlRow.setTitle(
                            'Сущность ' + index,
                            "javascript:app['/'].pages.mods.modDummyMain.item.view.load()"
                        );

                        app.sync([
                            fields.load,
                            actions.load,
                            funcNext
                        ]);
                    }

                    function load(funcNext) {
                        app['/host/controls/grid/row/'].start(
                            controlGrid.index + '--' + index,
                            controlGrid.elementId,
                            setup,
                            app.html.setToEnd,
                            funcNext
                        );
                    }

                    return {
                        load: load
                    };
                })();
            }

            return {
                create: create
            };
        })();

        var _rows = (function () {
            var _row1 = _row.create(1);
            var _row2 = _row.create(2);
            var _row3 = _row.create(3);

            function init(funcNext) {
                app.css.add([
                    controlGrid.elementId
                ], [
                    'skin--css--host--layout--body--part_last-child'
                ]);

                funcNext();
            }

            function load(funcNext) {
                return app.sync([
                    init,
                    _row1.load,
                    _row2.load,
                    _row3.load,
                    funcNext
                ]);
            }

            return {
                load: load
            };
        })();

        _rows.load(funcNext);
    }

    function start(funcNext) {
        function render(containers) {
            app.html.setTo('{grid}', containers);
        }

        app['/host/controls/grid/'].start(
            '--list',
            'app--id--host--layout--body',
            setup,
            render,
            funcNext
        );
    }

    return {
        start: start,
        view: _view
    };
})();
