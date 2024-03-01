window.addEventListener('beforeunload', function (event) {
    const currentTime = new Date();

    const year = currentTime.getUTCFullYear();
    const month = currentTime.getUTCMonth() + 1; // Month is zero-based
    const day = currentTime.getUTCDate();
    const hours = currentTime.getUTCHours();
    const minutes = currentTime.getUTCMinutes();
    const seconds = currentTime.getUTCSeconds();

    const ampm = hours >= 12 ? 'PM' : 'AM';
    const formattedTime = `${padZero(month)}/${padZero(day)}/${year} ${padZero(hours % 12 || 12)}:${padZero(minutes)}:${padZero(seconds)} ${ampm}`;

    // Combine date and time components into a single string
    const combinedDateTime = encodeURIComponent(formattedTime);

    localStorage.setItem('appClosedAt', combinedDateTime);
});

function padZero(num) {
    return (num < 10 ? '0' : '') + num;
}

window.forcePageReload = function () {
    location.reload(true); // true indicates a hard reload, including cache clearance
}

window.triggerFileDownload = (fileName, url) => {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}

window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);


    // Open file
    //const openFileElement = document.createElement('a');
    //openFileElement.href = url;
    //openFileElement.target = '_blank';
    //openFileElement.click();

    // Download File
    const downloadFileElement = document.createElement('a');
    downloadFileElement.href = url;
    downloadFileElement.download = fileName;
    downloadFileElement.click();

    // Clean up the URL and remove the element
    URL.revokeObjectURL(url);
};

window.downloadExportFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);

    // Download File
    const downloadFileElement = document.createElement('a');
    downloadFileElement.href = url;
    downloadFileElement.download = fileName;
    downloadFileElement.click();

    // Clean up the URL and remove the element
    URL.revokeObjectURL(url);
};

window.HideQuestion = function(id)  {

    //$("ul", "li", "#"+id).each(function (i) {

    //    $(this).css({ 'display': 'none' });
    //});


    var element = $('#' + id );
    if (element) {
        element.css({ 'display': 'none' });
    }

};

window.ShowQuestion = function (id) {

    //$("ul", "li", "#" + id).each(function (i) {

    //    $(this).css({ 'display': 'block' });
    //})


    //$("li").find('#' + id).each(function () {

    //   $(this).css({ 'display': 'block' });
    //});


    var element = $('#' + id);
    if (element) {
        element.css({ 'display': 'block' });
    }

};


/*Logout Dropdown*/
document.addEventListener("click", (event) => {
        const dropdown = document.querySelector(".dropdown");

        if (!dropdown) return;

        const withinDropdown = dropdown.contains(event.target)
        const hasActiveClass = dropdown.classList.contains("active");

        if (withinDropdown) {
            dropdown.classList.toggle("active");
        } else if (!withinDropdown && hasActiveClass) {
            dropdown.classList.remove("active");
        }
    }
)