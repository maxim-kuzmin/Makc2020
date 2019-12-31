app['/mods/dummy-main/pages/list/query-panel/'] = (function () {
    var _controlQueryPanel;

    var _view = (function () {
        var _form = (function () {
            function submit() {
                _controlQueryPanel.actionClick();

                return false;
            }

            return {
                submit: submit
            }
        })();

        function hide() {
            _controlQueryPanel.hide();
        }

        function show() {
            _controlQueryPanel.show();
        }

        return {
            form: _form,
            hide: hide,
            show: show
        };
    })();

    function controlQueryPanelInitActions() {
        var values = {};

        values[_controlQueryPanel.elementFormId] = [{
            attr: {
                'onsubmit': "return app['/mods/dummy-main/pages/list/query-panel/'].view.form.submit()"
            }
        }];

        values[_controlQueryPanel.elementSwitchHideId] = [{
            attr: {
                'href': "javascript:app['/mods/dummy-main/pages/list/query-panel/'].view.hide()"
            }
        }];

        values[_controlQueryPanel.elementSwitchShowId] = [{
            attr: {
                'href': "javascript:app['/mods/dummy-main/pages/list/query-panel/'].view.show()"
            }
        }];

        app.html.set(values);
    }

    function controlQueryPanelInitFilterAndSorter(funcNext) {
        var _filter = (function () {
            var _fieldIdentifier = (function () {
                function load(funcNext) {
                    _controlQueryPanel.addFilterFieldInputText(
                        'id',
                        '',
                        'Идентификатор',
                        funcNext
                    );
                }

                return {
                    load: load
                };
            })();

            var _fieldName = (function () {
                function load(funcNext) {
                    _controlQueryPanel.addFilterFieldInputText(
                        'name',
                        '',
                        'Наименование',
                        funcNext
                    );
                }

                return {
                    load: load
                };
            })();

            function load(funcNext) {
                app.sync([
                    _fieldIdentifier.load,
                    _fieldName.load,
                    funcNext
                ]);
            }

            return {
                load: load
            };
        })();

        var _sorter = (function () {
            var _fieldIdentifier = (function () {
                function load(funcNext) {
                    _controlQueryPanel.addSortField(
                        'id',
                        'Идентификатор',
                        true,
                        funcNext
                    );
                }

                return {
                    load: load
                };
            })();

            var _fieldName = (function () {
                function load(funcNext) {
                    _controlQueryPanel.addSortField(
                        'name',
                        'Наименование',
                        false,
                        funcNext
                    );
                }

                return {
                    load: load
                };
            })();

            function load(funcNext) {
                app.sync([
                    _fieldIdentifier.load,
                    _fieldName.load,
                    funcNext
                ]);
            }

            return {
                load: load
            };
        })();

        app.sync([
            _filter.load,
            _sorter.load,
            funcNext
        ]);
    }
    
    function setup(controlQueryPanel, funcNext) {
        _controlQueryPanel = controlQueryPanel;

        controlQueryPanelInitActions();

        controlQueryPanelInitFilterAndSorter(funcNext);
    }

    function start(funcNext) {
        function render(containers) {
            app.html.setTo('{query-panel}', containers);
        }

        app['/host/controls/query-panel/'].start(
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
