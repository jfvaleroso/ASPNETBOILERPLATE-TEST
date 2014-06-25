﻿//TODO: Move to framework?
requirejs.config({
    paths: {
        'text': '../../Scripts/text',
        'durandal': '../../Scripts/durandal',
        'plugins': '../../Scripts/durandal/plugins',
        'transitions': '../../Scripts/durandal/transitions',
        'service':  abp.appPath + 'Abp/Framework/scripts/libs/requirejs/plugins/service'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', function () { return ko;});
define('moment', function () { return moment; });
define('underscore', function () { return _; });

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'durandal/viewEngine', 'session', 'durandal/activator', 'knockout'], function (system, app, viewLocator, viewEngine, session, activator, ko) {
    //system.debug(true); //TODO: remove in production code

    //TODO: Move to framework?
    viewEngine.convertViewIdToRequirePath = function (viewId) {
        return this.viewPlugin + '!' + abp.appPath + 'AbpAppView/Load?viewUrl=/App/Main/' + viewId + '.cshtml';
    };

    //TODO: Is that good?
    //Assume true if not false
    activator.defaults.interpretResponse = function (value) {
        if (system.isObject(value)) {
            value = value.can == undefined ? true : value.can;
        }

        if (system.isString(value)) {
            return ko.utils.arrayIndexOf(this.affirmations, value.toLowerCase()) !== -1;
        }

        return value == undefined ? true : value;
    };

    app.title = 'Task Ever';

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    session.start().then(function () {
        app.start().then(function () {
            viewLocator.useConvention();
            app.setRoot('viewmodels/layout', 'entrance');
        });
    });
});