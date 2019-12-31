app['/host/controls/grid/row/field/none/'] = (function () {
    function start(containerId, funcRender, funcNext) {
        app.data.load(
            'host/controls/grid/row/field/none/host-control-grid-row-field-none.template.html',
            function(data, funcNext) {
                var containers = {};

                containers[containerId] = [
                    data,
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
