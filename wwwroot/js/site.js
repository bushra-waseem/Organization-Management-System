$(document).ready(function () {
    console.log("✅ site.js loaded");
});

/* ================= COMMON ================= */

function hideAllSections() {
    $("#organizations, #departments, #positions, #employees").hide();
}

/* ================= DASHBOARD CARD CLICKS ================= */

$("#org-card").on("click", function () {
    showOrgIndex();
});

$("#dept-card").on("click", function () {
    showDepartments();
});

$("#position-card").on("click", function () {
    showPositions();
});

$("#employee-card").on("click", function () {
    showEmployees();
});

/* ================= ORGANIZATION ================= */

function showOrgIndex() {
    hideAllSections();
    $("#organizations").show();
    refreshOrgTable();
}

function loadOrgCreate() {
    fetch("/Organization/Create")
        .then(r => r.text())
        .then(html => $("#org-content").html(html));
}


function loadOrgEdit(id) {
    fetch(`/Organization/Edit/${id}`)
        .then(r => r.text())
        .then(html => $("#org-content").html(html));
}

function loadOrgDelete(id) {
    fetch(`/Organization/Delete/${id}`)
        .then(r => r.text())
        .then(html => $("#org-content").html(html));
}

function refreshOrgTable() {
    fetch("/Organization/List")
        .then(r => r.text())
        .then(html => $("#org-content").html(html));
}

$(document).on("submit", "#org-create-form", function (e) {
    e.preventDefault();
    $.post("/Organization/Create", $(this).serialize(), res => {
        if (res.success) showOrgIndex();
    });
});

$(document).on("submit", "#org-edit-form", function (e) {
    e.preventDefault();
    $.post("/Organization/Edit", $(this).serialize(), res => {
        if (res.success) showOrgIndex();
    });
});
$(document).on("submit", "#org-delete-form", function (e) {
    e.preventDefault();

    $.ajax({
        url: "/Organization/DeleteConfirmed",
        type: "POST",
        data: $(this).serialize(),
        success: function (res) {
            console.log("ORG DELETE RESPONSE:", res);

            if (res.success) {
                showOrgIndex();
            } else {
                $("#org-delete-error")
                    .text(res.message || "Cannot delete organization.")
                    .show();
            }
        },
        error: function () {
            $("#org-delete-error")
                .text("Server error while deleting organization.")
                .show();
        }
    });
});

/* ================= DEPARTMENT ================= */

function showDepartments() {
    hideAllSections();
    $("#departments").show();
    refreshDepartmentTable();
}

function showDepartmentCreate() {
    fetch("/Department/Create")
        .then(r => r.text())
        .then(html => $("#department-content").html(html));
}

function loadDepartmentEdit(id) {
    fetch(`/Department/Edit/${id}`)
        .then(r => r.text())
        .then(html => $("#department-content").html(html));
}

function loadDepartmentDelete(id) {
    fetch(`/Department/Delete/${id}`)
        .then(r => r.text())
        .then(html => $("#department-content").html(html));
}

function refreshDepartmentTable() {
    fetch("/Department/List")
        .then(r => r.text())
        .then(html => $("#department-content").html(html));
}

$(document).on("submit", "#dept-create-form", function (e) {
    e.preventDefault();
    $.post("/Department/Create", $(this).serialize(), res => {
        if (res.success) showDepartments();
    });
});

$(document).on("submit", "#dept-edit-form", function (e) {
    e.preventDefault();
    $.post("/Department/Edit", $(this).serialize(), res => {
        if (res.success) showDepartments();
    });
});

$(document).on("submit", "#dept-delete-form", function (e) {
    e.preventDefault();
    $.post("/Department/DeleteConfirmed", $(this).serialize(), res => {
        if (res.success) showDepartments();
        else $("#dept-delete-error").text(res.message).show();
    });
});
/* ================= POSITION ================= */

function showPositions() {
    hideAllSections();
    $("#positions").show();
    refreshPositionTable();
}

function showPositionCreate() {
    fetch("/Position/Create")
        .then(r => r.text())
        .then(html => $("#position-content").html(html));
}

function loadPositionEdit(id) {
    fetch(`/Position/Edit/${id}`)
        .then(r => r.text())
        .then(html => $("#position-content").html(html));
}

function loadPositionDelete(id) {
    fetch(`/Position/Delete/${id}`)
        .then(r => r.text())
        .then(html => $("#position-content").html(html));
}

function refreshPositionTable() {
    fetch("/Position/List")
        .then(r => r.text())
        .then(html => $("#position-content").html(html));
}

/* ================= FORM SUBMITS ================= */

// CREATE
$(document).on("submit", "#position-create-form", function (e) {
    e.preventDefault();

    $.post("/Position/Create", $(this).serialize(), res => {
        if (res.success) {
            showPositions();
        }
    });
});

// EDIT
$(document).on("submit", "#position-edit-form", function (e) {
    e.preventDefault();

    $.post("/Position/Edit", $(this).serialize(), res => {
        if (res.success) {
            showPositions();
        }
    });
});

// POSITION DELETE
$(document).on("submit", "#position-delete-form", function (e) {
    e.preventDefault();

    $.ajax({
        url: "/Position/DeleteConfirmed",
        type: "POST",
        data: $(this).serialize(),
        success: function (res) {
            if (res.success) {
                refreshPositionTable();
            } else {
                $("#position-delete-error")
                    .text(res.message || "Cannot delete position.")
                    .show();
            }
        },
        error: function () {
            $("#position-delete-error")
                .text("Server error while deleting position.")
                .show();
        }
    });
});


/* ================= EMPLOYEE ================= */

function showEmployees() {
    hideAllSections();
    $("#employees").show();
    refreshEmployeeTable();
}

function showEmployeeCreate() {
    fetch("/Employee/Create")
        .then(r => r.text())
        .then(html => $("#employee-content").html(html));
}

function loadEmployeeEdit(id) {
    fetch(`/Employee/Edit/${id}`)
        .then(r => r.text())
        .then(html => $("#employee-content").html(html));
}

function loadEmployeeDelete(id) {
    fetch(`/Employee/Delete/${id}`)
        .then(r => r.text())
        .then(html => $("#employee-content").html(html));
}

function refreshEmployeeTable() {
    fetch("/Employee/List")
        .then(r => r.text())
        .then(html => $("#employee-content").html(html));
}

// CREATE
$(document).on("submit", "#employee-create-form", function (e) {
    e.preventDefault();
    $.post("/Employee/Create", $(this).serialize(), res => {
        if (res.success) showEmployees();
    });
});

// EDIT
$(document).on("submit", "#employee-edit-form", function (e) {
    e.preventDefault();
    $.post("/Employee/Edit", $(this).serialize(), res => {
        if (res.success) showEmployees();
    });
});

// DELETE
$(document).on("submit", "#employee-delete-form", function (e) {
    e.preventDefault();
    $.post("/Employee/DeleteConfirmed", $(this).serialize(), res => {
        if (res.success) showEmployees();
        else $("#employee-delete-error").text(res.message).show();
    });
});
