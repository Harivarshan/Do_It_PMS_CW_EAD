window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful");
    }
    if (type === "failed") {
        toastr.error(message, "Operation Failed");
    }
}