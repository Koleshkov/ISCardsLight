function saveAsFile(fileName, byteBase64) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

//window.downloadFileFromStream = async (fileName, contentStreamReference) => {
//    const arrayBuffer = await contentStreamReference.arrayBuffer();
//    const blob = new Blob([arrayBuffer]);
//    const url = URL.createObjectURL(blob);
//    const anchorElement = document.createElement('a');
//    anchorElement.href = url;
//    anchorElement.download = fileName ?? '';
//    anchorElement.click();
//    anchorElement.remove();
//    URL.revokeObjectURL(url);

//function saveAsFile(fileName, byteBase64) {
//    var link = document.createElement('a');
//    link.download = fileName;
//    link.href = 'data:application/vnd.openxmlformats-pfficedocument.spreadsheetml.sheet;base64' + byteBase64;
//    document.body.appendChild(link);
//    link.click();
//    document.body.removeChild(link);
//}