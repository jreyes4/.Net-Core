var attempts = 0;
// generate secret number function
function GenNumber() {
    // save variables from text input and validate
    var xVal = $("#low").val();
    var yVal = $("#high").val();
    if (Validate(xVal, yVal)) {
        // if valid, turn labels green, hide error msgs
        $(".genLbl").css('color', 'green');
        $("#errMsg").hide();
        // restful call
        $.ajax({
            type: "GET",
            url: "http://localhost:55578/Service1.svc/numGen",
            contentType: "application/json",
            data: {
                x: xVal,
                y: yVal
            },
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                console.log("Secret Number: ", data);
                $(".hidden").val(data);
                if (attempts !== 0) {
                    $("#Attempts").text("Attempts: -");
                    $("#response").text("");
                    attempts = 0;
                }
            }
        })
        // alert user that a secret number has been generated
        alert("Secret Number Generated");
    }
    // user input invalid, mark labels red and show error
    else {
        console.log("Fail");
        $(".genLbl").css('color', 'red');
        $("#errMsg").show();
    }
}
        // guess secret number
function Guess() {
    // save user input to vars and validate
    var xVal = $("#guess").val();
    var yVal = $(".hidden").val();
        if (Validate(xVal, yVal)) {
            // input valid, hide err msg, text green
            $("#guessLbl").css("color", "green");
            $("#errMsg2").hide();
            // async restful call to controller
            $.ajax({
                type: "GET",
                url: "http://localhost:56060/Home/guessNumber",
                contentType: "application/json",
                data: {
                    guess: xVal,
                    number: yVal
                },
                dataType: "json",
                success: function (data, textStatus, jqXHR) {
                    // increment attempts count
                   // console for debug
                    console.log("Your guess is: ", data);
                    attempts++;
                    console.log("attempts: ", attempts);
                    // update html
                    $("#response").text("Your guess is: " + JSON.stringify(data));
                    $("#Attempts").text("Attempts: " + attempts);
                }
            })
        }
        // invalid user input, text red and show err msg
        else {
            $("#guessLbl").css("color", "red");
            $("#errMsg2").show();
        }
    }
// validate user input
function Validate(x, y) {
    // check if empty string
    if (x === "" || y === "")
        return false;
    // check if integer
    if (Number.isInteger(+x) && Number.isInteger(+y))
        return true;
    return false;
}