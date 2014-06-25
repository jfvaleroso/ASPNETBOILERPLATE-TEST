﻿define(["jquery", "knockout", 'plugins/dialog', 'service!taskever/task', 'service!taskever/friendship', 'session'],
    function ($, ko, dialogs, taskService, friendshipService, session) {
        return function () {
            var that = this;

            // Public fields //////////////////////////////////////////////////////

            that.emailAddress = ko.observable('');
            that.message = ko.observable('');

            // Public methods /////////////////////////////////////////////////////

            that.activate = function (activateData) {
                if (!activateData) {
                    return;
                }

                if (activateData.message) {
                    that.message(activateData.message);
                }

                if (activateData.emailAddress) {
                    that.emailAddress(activateData.emailAddress);
                }
            };

            that.attached = function (view, parent) {
                $(view).find("form").validate({
                    submitHandler: function () {
                        abp.ui.setBusy($(view), {
                            promise: friendshipService.sendFriendshipRequest({
                                emailAddress: that.emailAddress()
                            }).done(function (result) {
                                if (result.status == taskever.friendshipStatus.Accepted) {
                                    abp.notify.info("Accepted friendship!");
                                } else {
                                    abp.notify.info("Sent friendship request!");
                                }

                                dialogs.close(that);
                            })
                        });
                    }
                });
            };

            that.cancel = function () {
                dialogs.close(that);
            };
        };
    });