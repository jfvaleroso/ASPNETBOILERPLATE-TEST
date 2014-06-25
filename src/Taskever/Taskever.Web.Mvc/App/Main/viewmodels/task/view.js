﻿define(
    ['durandal/app', 'jquery', 'underscore', 'service!taskever/task', 'service!taskever/friendship', 'session', 'plugins/history', 'plugins/dialog'],
    function (app, $, _, taskService, friendshipService, session, history, dialogs) {
        
        return function () {
            var that = this;

            // Public fields //////////////////////////////////////////////////////

            that.task = ko.mapping.fromJS({});
            that.isDeletable = false;
            that.isEditable = false;

            // Public methods /////////////////////////////////////////////////////

            that.canActivate = function (taskId) {
                return taskService.getTask({
                    id: taskId
                }).done(function (data) {
                    ko.mapping.fromJS(data.task, that.task);
                    that.isEditable = data.isEditableByCurrentUser;
                    that.isDeletable = data.isDeletableByCurrentUser;
                });
            };

            that.deleteTask = function () {
                dialogs.showMessage(
                    that.task.title() + ' will be permanently deleted! Are you sure?',
                    'Delete the task?',
                    ['No', 'Yes']
                ).done(function (result) {
                    if (result == 'Yes') {
                        taskService.deleteTask({
                            id: that.task.id()
                        }).done(function () {
                            history.navigate('#');
                            app.trigger('te.task.delete', {
                                task: that.task
                            });
                        });
                    }
                });
            };
        };
    }
);