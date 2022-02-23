function loadJs(sourceUrl) {
	if (sourceUrl.Length === 0) {
		console.error("Invalid source URL");
		return;
	}

	var existingElement = document.body.querySelector("script[src='" + sourceUrl + "']");
    if (existingElement != null) {
        existingElement.remove();
    }

	var tag = document.createElement('script');
	tag.src = sourceUrl;
	tag.type = "text/javascript";

	tag.onload = function () {
		console.log("Script loaded successfully");
	}

	tag.onerror = function () {
		console.error("Failed to load script");
	}

	document.body.appendChild(tag);
}