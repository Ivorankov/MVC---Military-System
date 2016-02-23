var flexGenerator = (function () {
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

    return {
        generateFlexibleControl: generateFlexibleControl
    }
}())