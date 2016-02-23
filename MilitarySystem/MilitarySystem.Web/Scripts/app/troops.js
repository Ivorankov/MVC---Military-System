﻿(function(){
function generateFlexibleControl(html, tabElementName, flexControlId, flexPinButtonId, flexHoldButtonId) {

            //Create the pin button
            var pinToTabButton = $("<button />")
                .addClass('btn-floating btn-small red')
                .text('Pin')
                .attr("id", flexPinButtonId);

            var holdButton = $("<button />")
                .addClass('btn-floating btn-small green')
                .text('Hold')
                .attr("id", flexHoldButtonId);

            //Container for button + content
            var borderElement = $("<div />").addClass("flexible-box")
                .attr("id", flexControlId);

            //Append button + content
            borderElement.append(pinToTabButton);
            borderElement.append(holdButton);
            borderElement.append(html);

            //Fancyyy
            $(borderElement).draggable({
                snap: true
            });

            //Append entire thing to the body
            $("#content").append(borderElement);

            //Pin to tab button click event
            $("#" + flexPinButtonId).on('click', function (ev) {
                $("#" + flexControlId).hide();

                var tabItemContainer = $("<li/>");

                var tabItemElement = $("<div />")
                    .addClass('chip')
                    .addClass('light-blue')
                    .addClass('white-text')
                    .addClass('tab-item')
                    .text(tabElementName);

                tabItemContainer.html(tabItemElement);
                $("#test").append(tabItemContainer);

                tabItemContainer.on('click', function () {
                    $("#" + flexControlId).show();
                    tabItemContainer.remove();
                })
            })

            $("#" + flexHoldButtonId).on('click', function (ev) {
                var $button = $("#" + flexHoldButtonId);
                var $flexContainer = $("#" + flexControlId);
                if ($button.hasClass("green")) {
                    $flexContainer.draggable("disable");
                    $button.removeClass("green")
                           .addClass("red");
                } else {
                    $flexContainer.draggable("enable");
                    $button.removeClass("red")
                           .addClass("green");
                }

            })
        }

        function initialize() {
            var lat = $("#Lat").attr("data-lat");
            var lgn = $("#Lgn").attr("data-lgn");
            var myLatlng = new google.maps.LatLng(lat, lgn);
            var mapOptions = {
                zoom: 8,
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.TERRAIN
            };
            var map = new google.maps.Map(document.getElementById("map"),
                mapOptions);

            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: 'Hello World!'
            });

            //marker.SetMap(map);

        }
        var chat;
        function initChat() {
            var rooms = [];

            $.connection.hub.start();

            chat = $.connection.chat;

            $('#send-message').click(function () {

                var msg = $('#message-to-server').val();

                chat.server.sendMessage(msg);
            });

            $("#join-room").click(function () {

                var room = $('#room').val();

                chat.server.joinRoom(room)
            });



            $('#send-message-to-room').click(function () {

                var msg = $('#room-message').val();

                chat.server.sendMessageToRoom(msg, rooms);
            });
            chat.client.addMessage = addMessage;
            chat.client.joinRoom = joinRoom;

        }
        function addMessage(message) {
            $('#messages').append('<div>' + message + '</div>');
        }

        function joinRoom(room) {
            $('#currentRooms').append('<div>' + room + '</div>');
        }
        initChat();
        //Click events for flext controls
        var $user = $("#user");
        var $squad = $("#squad");
        var $platoon = $("#platoon");
        var $chat = $("#chat");
        var $message = $("#message");
        var $mission = $("#mission");
        var userId = $("#user-id").text();
        $mission.click(function () {
            $.get('/Troops/Mission/Mission?userId=' + userId)
                .then(function (html) {
                    generateFlexibleControl(html, 'Mission', 'mission-flex', 'mission-flex-pin-button', 'mission-flex-hold-button');
                    initialize();
                    $mission.off();
                }).then(function () {
                    alert();
                    $("#complete-mission-btn").click(function () {
                        $.post('/Troops/Mission/CompleteMission').then(function () {
                            $mission.remove();
                        })
                    })
                })
        })

        $user.click(function () {
            $.get('/Troops/User/UserDetails/?userId='+ userId).then(function (html) {
                generateFlexibleControl(html, 'User', 'user-flex', 'user-flex-pin-button', 'user-flex-hold-button');
                $user.off();
            })
        })

        $squad.click(function () {
            $.get('/Troops/Squad/SquadDetails/?userId=' + userId).then(function (html) {
                generateFlexibleControl(html, 'Squad', 'squad-flex', 'squad-flex-pin-button', 'squad-flex-hold-button');
                $squad.off();
            })
        })

        $platoon.click(function () {
            $.get('/Troops/Platoon/PlatoonDetails?userId=' + userId).then(function (html) {
                generateFlexibleControl(html, 'Platoon', 'platoon-flex', 'platoon-flex-pin-button', 'platoon-flex-hold-button');

                $platoon.off();
            }).then(function () {
                $("button[data-squadId]").click(function (ev) {
                    var $target = $(ev.target);
                    var id = $target.attr("data-squadId");
                    $.get("/Troops/Mission/AssignMission", { squadId: id })
                        .then(function (data) {
                            $("#content").append(data);

                            $("#send-mission-btn").click(function () {
                                var data = {};
                                data.Info = $("#info-value").val();
                                data.Lgn = $("#lgn-value").val();
                                data.Lat = $("#lat-value").val();
                                data.SquadId = $("#squadId-value").val();
                                var form = $('#__AjaxAntiForgeryForm');
                                data.__RequestVerificationToken = $('input[name="__RequestVerificationToken"]', form).val();
                                $.post("/Troops/Mission/AssignMission", data)
                                    .then(function (response) {
                                        alert(response);
                                        $("#mission-add-box").remove();
                                        $("#squads-details-box").find("[data-squadId='" + 4 + "']").remove();
                                    })

                            })
                        })
                })
            })
        })

        $chat.click(function () {
            var chatBox = $("#chat-box").removeClass("hidden");
            generateFlexibleControl(chatBox, 'Chat', 'chat-flex', 'chat-flex-pin-button', 'chat-flex-hold-button');
            $("#chat-box").show();
            $chat.off();
        })
        var chached = "NaNaNaNa";
        $message.click(function () {
            $.get('/Troops/Message/Message').then(function (html) {
                generateFlexibleControl(html, 'Message', 'message-flex', 'message-flex-pin-button', 'message-flex-hold-button');
                $message.off();
            }).then(function () {
                $("div[data-userId]").click(function (ev) {
                    if (chached !== "NaNaNaNa") {
                        chached.removeClass("blue white-text");
                    }

                    var $target = $(ev.target);
                    $target.addClass("blue white-text");
                    chached = $target;
                    var content = $target.attr("data-userId");
                    $("#message-content").html(content);

                })

                $("#send-message-btn-test").click(function () {
                    var data = {};
                    var SendInput = {};
                    data.SendInput = SendInput;
                    data.SendInput.Content = $("#message-to-send-content").val();
                    $.post("/Troops/Message/SendMessage", data)
                        .then(function (response) {
                            alert(response);
                        })
                })
            })


        })
}())