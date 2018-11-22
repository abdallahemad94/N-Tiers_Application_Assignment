$(document).ready(
    () => {
        HideViewControls();
        HideInsertControls();
        HideDeleteControls();
    }
)

function ddlTables_Change() {
    CleartextBoxes();
    $("#ddlFilter").val("None");
    var SelectedTable = $("#ddlTables").val();
    if (SelectedTable === "None") {
        HideViewControls();
        HideInsertControls();
        HideDeleteControls();
    }
    else {
        ShowInsertControls(SelectedTable);
    }
}

function ddlFilter_Change() {
    $("txtFilterID").val("");
    var SelectedFilter = $("#ddlFilter").val();
    if (SelectedFilter === "None") {
        HideFilterOptions();
    }
    else {
        ShowFilterOptions(SelectedFilter);
    }
}

function CleartextBoxes() {
    $("input[type='text']").text("");
}

function HideViewControls() {
    $(".ViewControls").attr("visibility", "hidden");
}

function HideInsertControls() {
    $(".InsertControls").attr("visibility", "hidden");
}

function HideDeleteControls() {
    $(".DeleteControls").attr("visibility", "hidden");
}

function ShowViewControls() {
    $(".ViewControls").attr("visibility", "visible");
}

function ShowInsertControls(selectedTable) {
    switch (selectedTable) {
        case "Students":
            InsertOptions("Student");
            break;
        case "Coures":
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
    $("#lblInsertID").attr("visibility", "visible");
    $("#lblInsertName").attr("visibility", "visible");
    $("#txtInsertID").attr("visibility", "visible");
    $("#txtInsertName").attr("visibility", "visible");
    HideCourseInsertOptions();
}

function CoursesInsertOptions() {
    $("#lblInsertID").text("Course ID: ");
    $("#lblInsertName").text("Course Name: ");
    $(".InsertControls").attr("visibility", "visible");
}

function HideCourseInsertOptions() {
    $("#lblCourseDesc").attr("visibility", "hidden");
    $("#txtCourseDesc").attr("visibility", "hidden");
    $("#lblCourseInst").attr("visibility", "hidden");
    $("#txtCourseInst").attr("visibility", "hidden");
}

function HideFilterOptions() {
    $(".FilterOptions").attr("visibility", "hidden");
}

function ShowFilterOptions(selectedFilter) {
    $("#lblFilterID").text(selectedFilter + " ID: ");
    $(".FilterOptions").attr("visibility", "visible");
}