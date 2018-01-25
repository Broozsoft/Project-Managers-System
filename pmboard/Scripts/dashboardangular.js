var app = angular.module("myApp", ['ngAnimate']);

app.controller("progress-thing", function ($scope) {

    var progress = $scope.progress;

    $scope.ProgressChange = function (progress, gate) {

        switch (progress) {
            case "FS":
                if (gate === "FS") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "G0":
                if (gate === "G0") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "RDB":
                if (gate === "RDB") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "G1":
                if (gate === "G1") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "R2":
                if (gate === "R2") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "R3":
                return { backgroundColor: "#b2b2b2" };
                break;
            case "R4":
                if (gate === "R4") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "G3":
                if (gate === "G3") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "R5":
                if (gate === "R5") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "R7":
                if (gate === "R7") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "R8":
                if (gate === "R8") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
            case "G4":
                if (gate === "G4") {
                    return { backgroundColor: "#b2b2b2" };
                }
                break;
        }

    };
    
})

//Controller for the project status, handles the color changing

app.controller("status-thing", function ($scope) {

    $scope.colorChange = function (status) {

        var color = status.toLowerCase();
        
        if (color === "#81c784" || color === "green") {
            return { backgroundColor: "#81c784" };
        }
        else if (color === "#fdd835" || color === "yellow") {
            return { backgroundColor: "#fdd835" };
        }
        else if (color === "#ff5252" || color === "red") {
            return { backgroundColor: "#ff5252" };
        }
        else {
            console.log(color);
            return { backgroundColor: "white" };
        }
    };
    
});