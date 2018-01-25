$(function () {
    //Status drag-and-drop
    $(".draggable").draggable({
        revert: "valid"
    });

    $(".draggable2").draggable({
        revert: "valid"
    });

    $(".draggable3").draggable({
        revert: "valid"
    });

    $("#schedule-table").on("click", ".disableButton", function () {

        console.log("dsds");
        var $element = $(this).parent("td");

        $element.droppable('enable');
        if ($element.hasClass('status-full')) {
            $element.removeClass("status-full");
        }
        else if ($element.hasClass('status-am')) {
            $element.removeClass("status-am");
        }
        else if ($element.hasClass('status-pm')) {
            $element.removeClass("status-pm");
        }

        var divId = $(this).parent("td").attr('id');
        removeStatus(divId);

        $element.removeClass('dropped');

        $(this).remove();
    });

    function addStatus(ui, day) {
        if (ui.draggable.hasClass("draggable")) {
            day.addClass('status-full');

            if (!day.hasClass("ui-droppable-disabled")) {
                day.append('<div class="full circle disableButton"></div>');
            }
        }
        else if (ui.draggable.hasClass("draggable2")) {
            day.addClass('status-am');

            if (!day.hasClass("ui-droppable-disabled")) {
                day.append('<div class="am circle disableButton"></div>');
            }
        }
        else if (ui.draggable.hasClass("draggable3")) {
            day.addClass('status-pm');

            if (!day.hasClass("ui-droppable-disabled")) {
                day.append('<div class="pm circle disableButton"></div>');
            }
        }
    }
    
    $(".monday").droppable({
        drop: function (event, ui) {
            var day = $(this);

            ui.draggable.addClass('dropped');

            addStatus(ui, day);

            ui.draggable.data('droppedin', day);
            day.droppable('disable');

            var divId = this.id;
            var status = returnStatus(ui);
            setStatus(status, divId);
        }
    });

    $(".tuesday").droppable({
        drop: function (event, ui) {
            var day = $(this);

            ui.draggable.addClass('dropped');

            addStatus(ui, day);

            ui.draggable.data('droppedin', day);
            day.droppable('disable');

            var divId = this.id;
            var status = returnStatus(ui);
            setStatus(status, divId);
        }
    });

    $(".wednesday").droppable({
        drop: function (event, ui) {
            var day = $(this);

            ui.draggable.addClass('dropped');

            addStatus(ui, day);

            ui.draggable.data('droppedin', day);
            day.droppable('disable');

            var divId = this.id;
            var status = returnStatus(ui);
            setStatus(status, divId);
        }
    });

    $(".thursday").droppable({
        drop: function (event, ui) {
            var day = $(this);

            ui.draggable.addClass('dropped');

            addStatus(ui, day);

            ui.draggable.data('droppedin', day);
            day.droppable('disable');

            var divId = this.id;
            var status = returnStatus(ui);
            setStatus(status, divId);
        }
    });

    $(".friday").droppable({
        drop: function (event, ui) {
            var day = $(this);

            ui.draggable.addClass('dropped');

            addStatus(ui, day);

            ui.draggable.data('droppedin', day);
            day.droppable('disable');

            var divId = this.id;
            var status = returnStatus(ui);
            setStatus(status, divId);
        }
    });

    function returnStatus(magnet) {
        if (magnet.draggable.hasClass('full')) {
            return 'full';
        }
        else if (magnet.draggable.hasClass('am')) {
            return 'am';
        }
        else if (magnet.draggable.hasClass('pm')) {
            return 'pm';
        }
    }

    function setStatus(status, divId) {
        var splitDiv = divId.split(" ");
        var projectmanagerId = splitDiv[1];
        var day = splitDiv[0];

        $.ajax({
            type: "POST",
            url: "/Dashboard/SetStatus",
            data: {
                pmId: projectmanagerId,
                status: status,
                day: day
            },
            success: function (result) {

                alert("Status updated");

            }
        });
    }

    function removeStatus(divId) {
        var splitDiv = divId.split(" ");
        var projectmanagerId = splitDiv[1];
        var day = splitDiv[0];

        $.ajax({
            type: "POST",
            url: "/Dashboard/RemoveStatus",
            data: {
                pmId: projectmanagerId,
                day: day
            },
            success: function (result) {

                alert("Status removed");

            }
        });
    }


    //Progress drag-and-drop

    $(".draggable4").draggable({
        revert: "valid"
    });

    $(".FS").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "FS";
                var divId = this.id;
                setProgress(progress, divId);
            }
            
        }
    });

    $(".G0").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "G0";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".RDB").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "RDB";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".G1").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "G1";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R2").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');
                
                addProg(ui, gate);
                
                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R2";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".G2").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "G2";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R3").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R3";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R4").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R4";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".G3").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "G3";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R5").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R5";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R7").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R7";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".R8").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "R8";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".G4").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "G4";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });

    $(".END").droppable({
        drop: function (event, ui) {
            var gate = $(this);

            if (ui.draggable.hasClass('prog')) {
                ui.draggable.addClass('dropped');

                addProg(ui, gate);

                ui.draggable.data('droppedin', gate);
                gate.droppable('disable');

                var progress = "END";
                var divId = this.id;
                setProgress(progress, divId);
            }
        }
    });
    
    function setProgress(progress, divId) {
        var splitDiv = divId.split(" ");
        var projectId = splitDiv[1];
        var gate = splitDiv[0];

        var progressScope = "#currentProgress_" + projectId;

        var currentProgress = $(progressScope).val();

        var check;

            switch (gate) {
                case "FS":
                    if (currentProgress === "G0" || currentProgress === "RDB" || currentProgress === "G1" || currentProgress === "R2" || currentProgress === "G2" || currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "G0":
                    if (currentProgress === "RDB" || currentProgress === "G1" || currentProgress === "R2" || currentProgress === "G2" || currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "RDB":
                    if (currentProgress === "G1" || currentProgress === "R2" || currentProgress === "G2" || currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "G1":
                    if (currentProgress === "R2" || currentProgress === "G2" || currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R2":
                    if (currentProgress === "G2" || currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "G2":
                    if (currentProgress === "R3" || currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R3":
                    if (currentProgress === "R4" || currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R4":
                    if (currentProgress === "G3" || currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "G3":
                    if (currentProgress === "R5" || currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R5":
                    if (currentProgress === "R7" || currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R7":
                    if (currentProgress === "R8" || currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "R8":
                    if (currentProgress === "G4" || currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "G4":
                    if (currentProgress === "END") {
                        check = false;
                    }
                    else {
                        check = true;
                    }
                    break;
                case "END":
                        check = false;
                    break;
            }

            if (check === true) {
                $.ajax({
                    type: "GET",
                    url: "/Dashboard/SetProgress",
                    data: {
                        pId: projectId,
                        progress: gate
                    },
                    success: function (result) {

                        alert("Progress successfully updated.");
                        location.reload();

                    },
                    error: function (jqXHR, exception) {
                        var msg = '';
                        if (jqXHR.status === 0) {
                            msg = 'Not connect.\n Verify Network.';
                        } else if (jqXHR.status === 404) {
                            msg = 'Requested page not found. [404]';
                        } else if (jqXHR.status === 500) {
                            //msg = 'Internal Server Error [500]';
                            msg = 'Progress successfully updated.';
                        } else if (exception === 'parsererror') {
                            msg = 'Requested JSON parse failed.';
                        } else if (exception === 'timeout') {
                            msg = 'Time out error.';
                        } else if (exception === 'abort') {
                            msg = 'Ajax request aborted.';
                        } else {
                            msg = 'Uncaught Error.\n' + jqXHR.responseText;
                        }
                        alert(msg);
                        location.reload();
                    }
                });
            }
            else {
                alert("You can't go backwards in terms of progress...");
            }
        }
    

    function addProg(ui, gate) {
        if (ui.draggable.hasClass("draggable4")) {
            gate.addClass('prog-set');

            if (!gate.hasClass("ui-droppable-disabled")) {
                gate.append('<div class="prog circle disableButton"></div>');
            }
        }
    }

    
    $("#basicallyEverything").droppable();
});