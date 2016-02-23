(function () {

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
}())