$(document).on('show.bs.modal', '#createUserModal', function () {
    //reset and clear form
    ClearFormFields();
})

$(document).on('click', '#editUserButton', function () {
    ClearFormFields();
    PopulateEditModal(this);
})

function ClearFormFields() {
    $('[name="FirstName"]').val('');
    $('[name="LastName"]').val('');
    $('[name="Email"]').val('');
    $('[name="Cellphone"]').val('');
}
function PopulateEditModal(element) {
    var userId = $(element).data('userid');
    var firstName = $(element).data('first');
    var lastName = $(element).data('last');
    var email = $(element).data('email');
    var cellphone = $(element).data('cellphone');

    $('#editUserModal [name="UserId"]').val(userId);
    $('#editUserModal [name="FirstName"]').val(firstName);
    $('#editUserModal [name="LastName"]').val(lastName);
    $('#editUserModal [name="Email"]').val(email);
    $('#editUserModal [name="Cellphone"]').val(cellphone);
}