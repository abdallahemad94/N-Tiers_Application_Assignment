﻿$(document).ready(
    () => {
        HideViewControls();
        HideInsertControls();
        HideDeleteControls();
    }
);

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
        ShowViewControls();
        ShowInsertControls(SelectedTable);
        ShowDeleteControls(SelectedTable);
        $(".FieldInfo").css("visibility", "visible");
    }
}

function ddlFilter_Change() {
    $("#txtFilterID").val("");
    var SelectedFilter = $("#ddlFilter").val();
    if (SelectedFilter === "None") {
        HideFilterOptions();
    }
    else {
        ShowFilterOptions(SelectedFilter);
    }
}

function CleartextBoxes() {
    $("input[type='text']").val("");
}

function HideViewControls() {
    $(".ViewControls").css("visibility", "hidden");
}

function HideInsertControls() {
    $(".InsertControls").css("visibility", "hidden");
}

function HideDeleteControls() {
    $(".DeleteControls").css("visibility", "hidden");
}

function ShowViewControls() {
    $(".ViewControls").css("visibility", "visible");
    $(".FilterOptions").css("visibility", "hidden");
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
    $("#lblInsertID").css("visibility", "visible");
    $("#lblInsertName").css("visibility", "visible");
    $("#txtInsertID").css("visibility", "visible");
    $("#txtInsertName").css("visibility", "visible");
    $("#btnInsert").css("visibility", "visible")
    HideCourseInsertOptions();
}

function CoursesInsertOptions() {
    $("#lblInsertID").text("Course ID: ");
    $("#lblInsertName").text("Course Name: ");
    $(".InsertControls").css("visibility", "visible");
}

function HideCourseInsertOptions() {
    $("#lblCourseDesc").css("visibility", "hidden");
    $("#txtCourseDesc").css("visibility", "hidden");
    $("#lblCourseInst").css("visibility", "hidden");
    $("#txtCourseInst").css("visibility", "hidden");
}

function HideFilterOptions() {
    $(".FilterOptions").css("visibility", "hidden");
}

function ShowFilterOptions(selectedFilter) {
    $("#lblFilterID").text(selectedFilter + " ID: ");
    $(".FilterOptions").css("visibility", "visible");
}

function ShowDeleteControls(selectedTable) {
    $("#lblDeleteID").text(selectedTable + " ID: ");
    $(".DeleteControls").css("visibility", "visible");
}

function ValidateFilterID(src, args) {
    var SelectedFilter = $("#ddlFilter").val();
    if (SelectedFilter === "None") {
        args.IsValid = true;
    }
    else {
        ValidateID(src, args);
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