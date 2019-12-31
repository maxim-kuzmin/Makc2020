app['/mods/dummy-main/pages/list/pagers/top/'] = (function () {
    var _controlPager;

    var _view = (function () {
        function next() {
            _controlPager.next();
        }

        function prev() {
            _controlPager.prev();
        }

        return {
            next: next,
            prev: prev
        };
    })();

    function controlPagerInitActions() {
        var values = {};

        values[_controlPager.elementNextId] = [{
            attr: {
                'href': "javascript:app['/mods/dummy-main/pages/list/pagers/top/'].view.next()"
            }
        }];

        values[_controlPager.elementPrevId] = [{
            attr: {
                'href': "javascript:app['/mods/dummy-main/pages/list/pagers/top/'].view.prev()"
            }
        }];

        app.html.set(values);
    }

    function controlPagerInitBorders() {
        app.css.add([
            _controlPager.elementId
        ], [
            'skin--css--host--control--pager--top'
        ]);
    }

    function setup(controlPager, funcNext) {
        _controlPager = controlPager;

        controlPagerInitActions();

        controlPagerInitBorders();

        funcNext();
    }

    function start(funcNext) {
        function render(containers) {
            app.html.setTo('{pager--top}', containers);
        }

        app['/host/controls/pager/'].start(
            '--list--1',
            'app--id--host--layout--body',
            '',
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
