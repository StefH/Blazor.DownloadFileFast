export function BlazorDownloadFileFast7Up(name, contentType, content) {
    // Create the URL
    const file = new File([content], name, { type: contentType });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = name;
    a.target = "_self";
    a.click();

    // We don't need to keep the url, let's release the memory
    URL.revokeObjectURL(exportUrl);

    return true;
}