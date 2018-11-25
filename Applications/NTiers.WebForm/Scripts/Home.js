$(document).ready(
    () => {
        if (document.cookie) {
            var SelectedTable = GetCookie("Table");
            var SelectedFilter = GetCookie("Filter");

            if (SelectedTable) {
                $("#ddlTables").val(SelectedTable);
                ddlTables_Change();
                setTimeout("__doPostBack('ddlTables', '\')", 0);

                if (SelectedFilter) {
                    $("#ddlFilter").val(SelectedFilter);
                    ddlFilter_Change();
                }
            }
        }
        else {
            HideViewControls();
            HideInsertControls();
        }
    }
);

// #region Tables drop down list events and methods
function ddlTables_Change() {
    CleartextBoxes();
    ClearValidationControls();
    $("#ddlFilter").val("None"); //reset filter

    var SelectedTable = $("#ddlTables").val();

    if (SelectedTable === "None") {
        HideViewControls();
        HideInsertControls();
    }
    else {
        ShowViewControls();
        ShowInsertControls(SelectedTable);
        HideFilterOptions();
        $(".FieldInfo").css("visibility", "visible");
    }
    SetCookie("Table", SelectedTable);
}

function CleartextBoxes() {
    $("input[type='text']").val("");
}

function ClearValidationControls() {
    $(".ValidationControls").css("visibility", "hidden");
}
// #endregion

// #region Filters drop down list events and methods
function ddlFilter_Change() {
    $("#txtFilterID").val("");
    var SelectedFilter = $("#ddlFilter").val();
    if (SelectedFilter === "None") {
        HideFilterOptions();
    }
    else {
        ShowFilterOptions(SelectedFilter);
    }
    SetCookie("Filter", SelectedFilter);
}

function ShowFilterOptions(selectedFilter) {
    $("#lblFilterID").text(selectedFilter + " ID: ");
    $(".FilterOptions").css("visibility", "visible");
}

function HideFilterOptions() {
    $(".FilterOptions").css("visibility", "hidden");
}
// #endregion

// #region View Controls methods and events
function HideViewControls() {
    $(".ViewControls").css("visibility", "hidden");
}

function ShowViewControls() {
    $(".ViewControls").css("visibility", "visible");
}
// #endregion

// #region Insert Controls methods and events
function HideInsertControls() {
    $(".InsertControls").css("visibility", "hidden");
}

function ShowInsertControls(selectedTable) {
    switch (selectedTable) {
        case "Students":
            InsertOptions("Student");
            break;
        case "Courses":
            CoursesInsertOptions();
            break;
        case "Instructors":
            InsertOptions("Instructor");
            break;
        case "Enrollments":
            InsertOptions("Enrollment");
            break;
    }
}

function InsertOptions(text) {
    $("#lblInsertID").text(text +" ID: ");
    $("#lblInsertName").text(text + " Name: ");
    if (text == "Enrollment") {
        $("#lblInsertID").text("Course ID: ");
        $("#lblInsertName").text("Studentd ID: ");
    }
    $(".InsertControls").css("visibility", "visible");
    HideCourseInsertOptions();
}

function CoursesInsertOptions() {
    $("#lblInsertID").text("Course ID: ");
    $("#lblInsertName").text("Course Name: ");
    $(".InsertControls").css("visibility", "visible");
}

function HideCourseInsertOptions() {
    $(".CourseInsert").css("visibility", "hidden");
}
// #endregion

// #region User input validation methods
function ValidateFilterID(src, args) {
    var SelectedFilter = $("#ddlFilter").val();
    if (SelectedFilter === "None") {
        args.IsValid = true;
    }
    else {
        ValidateID(src, args);
    }
}

function ValidateCourseInst(src, args) {
    var SelectedTable = $("#ddlTables").val();
    if (SelectedTable === "Courses") {
        ValidateID(src, args);
    }
    else {
        args.IsValid = true;
    }
}

function ValidateID(src, args) {
    var pattern = /^\d+$/;
    var text = args.Value;
    if (text !== "") {
        if (pattern.test(text)) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
    else {
        args.IsValid = false;
    }
}

function ValidateName(src, args) {
    var SelectedTable = $("#ddlTables").val();

    if (SelectedTable === "Enrollments") {
        $("#ValidateInsertName").text("Please enter a valid number!");
        ValidateID(src, args);
    }
    else {
        $("#ValidateInsertName").text("Please enter a name!");
        args.IsValid = (args.Value.length > 0) ? true : false;
    }
}

// #endregion

// #region Cookies Methods
function SetCookie(cookieName, cookieValue) {
    var date = new Date();
    date.setHours(date.getHours() + 1);
    document.cookie = cookieName + "=" + cookieValue + "; expires=" + date.toUTCString();;
}

function GetCookie(cookieName) {
    var pattern = new RegExp(cookieName + "=(\\w+);?");
    if (document.cookie.match(pattern) != null) {
        var value = (document.cookie.match(pattern)[1]) ? document.cookie.match(pattern)[1] : "None";
        return value;
    }
    return null;
}
// #endregion