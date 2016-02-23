(function () {
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
                flexGenerator.generateFlexibleControl(html, 'Mission', 'mission-flex', 'mission-flex-pin-button', 'mission-flex-hold-button');
                googleMap.initialize();
                $mission.off();
            }).then(function () {
                $("#complete-mission-btn").click(function () {
                    $.post('/Troops/Mission/CompleteMission').then(function () {
                        $("#mission-flex").remove();
                        $mission.on();
                    })
                })
            })
    })

    $user.click(function () {
        $.get('/Troops/User/UserDetails/?userId=' + userId).then(function (html) {
            flexGenerator.generateFlexibleControl(html, 'User', 'user-flex', 'user-flex-pin-button', 'user-flex-hold-button');
            $user.off();
        })
    })

    $squad.click(function () {
        $.get('/Troops/Squad/SquadDetails/?userId=' + userId).then(function (html) {
            flexGenerator.generateFlexibleControl(html, 'Squad', 'squad-flex', 'squad-flex-pin-button', 'squad-flex-hold-button');
            $squad.off();
        })
    })

    $platoon.click(function () {
        $.get('/Troops/Platoon/PlatoonDetails?userId=' + userId).then(function (html) {
            flexGenerator.generateFlexibleControl(html, 'Platoon', 'platoon-flex', 'platoon-flex-pin-button', 'platoon-flex-hold-button');

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
        flexGenerator.generateFlexibleControl(chatBox, 'Chat', 'chat-flex', 'chat-flex-pin-button', 'chat-flex-hold-button');
        $("#chat-box").show();
        $chat.off();
    })
    var chached = "NaNaNaNa";
    $message.click(function () {
        $.get('/Troops/Message/Message').then(function (html) {
            flexGenerator.generateFlexibleControl(html, 'Message', 'message-flex', 'message-flex-pin-button', 'message-flex-hold-button');
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

            var $sendingMessageContent = $("#message-to-send-content");

            $("#send-message-btn-test").click(function () {
                var data = {};
                var SendInput = {};
                data.SendInput = SendInput;
                data.SendInput.Content = $sendingMessageContent.val();
                var form = $('#__AjaxAntiForgeryForm');
                data.__RequestVerificationToken = $('input[name="__RequestVerificationToken"]', form).val();
                $.post("/Troops/Message/SendMessage", data)
                    .then(function (response) {
                        alert(response);
                        $sendingMessageContent.val("");
                    })
            })
        })


    })
}())